namespace _1._1_UmbauGenerics
{
    public class Node<T> {
        public Node<T> next;
        private T data;

        public Node(T t) {
            next = null;
            data = t;
        }

        public Node<T> Next {
            get { return next; }
            set { next = value; }
        }

        public T Data {
            get { return data; }
            set { data = value; }
        }
    }
}