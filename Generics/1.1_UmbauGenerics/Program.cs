using System;

namespace _1._1_UmbauGenerics {
    public class Person : IComparable {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Person(string name, int age) {
            Name = name;
            Age = age;
        }

        public int CompareTo(object p) {
            if (p is Person pers) {
                return Age - pers.Age;
            }

            throw new Exception("p has wrong type");
        }

        public override string ToString() {
            return Name + ":" + Age;
        }
    }

    class Program {
        static void Main(string[] args) {
            // Datenstrukturen erstellen
            string[] names = {"Franscoise", "Bill", "Li", "Sandra", "Gunnar", "Alok", "Hiroyuki", "Maria", "Alessandro", "Raul"};
            int[] ages = {45, 19, 28, 23, 18, 9, 108, 72, 30, 35};

            // MySortedList abfüllen
            MySortedList<Person> list = new MySortedList<Person>();
            for (int x = 0; x < names.Length; x++) {
                list.Add(new Person(names[x], ages[x]));
            }

            // MySortedList ausgeben vor Sortierung
            Console.WriteLine("Unsorted List:");
            foreach (Person p in list) {
                Console.WriteLine(p.ToString());
            }

            // MySortedList sortieren
            list.BubbleSort();

            // MySortedList ausgeben nach Sortierung
            Console.WriteLine();
            Console.WriteLine("Sorted List:");
            foreach (Person p in list) {
                Console.WriteLine(p.ToString());
            }

            Console.ReadKey();
        }
    }
}