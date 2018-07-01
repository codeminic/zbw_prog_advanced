﻿using System;
using System.Collections.Generic;

namespace _1._2_DotNetList {
    public class Person : IComparable<Person> {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Person(string name, int age) {
            Name = name;
            Age = age;
        }

        public int CompareTo(Person p) {
            if (p != null) {
                return Age - p.Age;
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
            string[] names = new string[] {"Franscoise", "Bill", "Li", "Sandra", "Gunnar", "Alok", "Hiroyuki", "Maria", "Alessandro", "Raul"};
            int[] ages = new int[] {45, 19, 28, 23, 18, 9, 108, 72, 30, 35};

            // System.Collections.Generic.List<T> abfüllen
            List<Person> list = new List<Person>();
            for (int x = 0; x < names.Length; x++) {
                list.Add(new Person(names[x], ages[x]));
            }

            // TODO: Sortiere die Liste nach dem Personennamen.
            list.Sort(ComparePersonsByName);

            // TODO: Geben Sie die Liste der Personen aus, deren Alter >= 30 ist.  
            list.FindAll(p => p.Age >= 30).ForEach(Console.WriteLine);

            Console.ReadKey();
        }

        private static int ComparePersonsByName(Person p1, Person p2)
        {
            return p1.CompareTo(p2);
        }
    }
}