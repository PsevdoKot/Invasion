using System.Collections;
using System.Collections.Generic;

namespace Invasion.Domain
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public readonly T Value;
        public readonly SinglyLinkedList<T> Previous;
        public readonly int Length;

        public SinglyLinkedList(T value, SinglyLinkedList<T> previous = null)
        {
            Value = value;
            Previous = previous;
            Length = previous?.Length + 1 ?? 1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return Value;
            var pathItem = Previous;
            while (pathItem != null)
            {
                yield return pathItem.Value;
                pathItem = pathItem.Previous;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public SinglyLinkedList<T> Reverse()
        {
            var result = new SinglyLinkedList<T>(Value);
            var previous = Previous;
            while (previous != null)
            {
                result = new SinglyLinkedList<T>(previous.Value, result);
                previous = previous.Previous;
            }
            return result;
        }
    }
}
