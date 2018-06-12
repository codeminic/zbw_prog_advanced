using System;
using System.Collections.Generic;

namespace _1._1_UmbauGenerics {
    public class MySortedList<T> : MyList<T> where T : IComparable {

        private Node<T> head;

        /// <summary>
        /// A simple, unoptimized sort algorithm that orders list elements from lowest to highest.
        /// </summary>
        public void BubbleSort() {
            if (head?.Next == null) {
                return;
            }

            bool swapped;
            do {
                Node<T> previous = null;
                Node<T> curr = head;
                swapped = false;
                while (curr.next != null) {
                    IComparable comp = curr.Data as IComparable;
                    if (comp == null) {
                        throw new Exception("data-object must implement IComparable");
                    }

                    if (comp.CompareTo(curr.next.Data) > 0) {
                        Node<T> tmp = curr.next;
                        curr.next = curr.next.next;
                        tmp.next = curr;

                        if (previous == null) {
                            head = tmp;
                        } else {
                            previous.next = tmp;
                        }

                        previous = tmp;
                        swapped = true;
                    } else {
                        previous = curr;
                        curr = curr.next;
                    }
                } // end while
            } while (swapped);
        }
    }
}