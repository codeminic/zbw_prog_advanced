using System.Collections;

namespace _1._1_UmbauGenerics {
    public class MyList<T> : IEnumerable {

        protected Node<T> head;
        protected Node<T> current = null;

        public MyList() {
            head = null;
        }

        public void Add(T t) {
            var n = new Node<T>(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator GetEnumerator() {
            Node<T> curr = head;
            while (curr != null) {
                yield return curr.Data;
                curr = curr.Next;
            }
        }
    }
}