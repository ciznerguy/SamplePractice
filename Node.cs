using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePractice
{

    public class Node<T>
    {
        private T value;
        private Node<T> next;

        //-----------------------------------
        //constructors
        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }
        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }
        //-----------------------------------
        //getters
        public T GetValue()
        {
            return this.value;
        }
        public Node<T> GetNext()
        {
            return this.next;
        }
        //-----------------------------------
        //setters
        public void SetValue(T value)
        {
            this.value = value;
        }
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
        //-----------------------------------
        //return true if this.next is not null, else returns false
        public bool HasNext()
        {
            return (this.next != null);
        }
        //-----------------------------------
        //ToString
        public override string ToString()
        {
            return value + "-->>" + next;
        }

    }

}
