namespace _5.Storage_Box
{
    using System;
    using System.Collections;
    using System.Linq;

    public class Box<T>
    {
        private T[] data;
        private int count;

        public Box()
        {
            this.data = new T[4];
            this.Count = 0;

        }

        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                if (this.data.Length<value)
                {
                    throw new IndexOutOfRangeException("Collection is full.");
                }
                this.count = value;
            }
        }
            
        public T[] Data
        {
            get
            {
                return this.data;
            }
            private set
            {
                if (this.data.Length==this.Count)
                {
                    var newData = new T[this.data.Length * 2];
                    this.data.CopyTo(newData, 0);
                    this.data = newData;
                }
                this.data = value;
            }
        }

        public void Add(T element)
        {
            this.Data[this.Count] = element;
            this.Count++;
        }

        public T Remove()
        {
            int index = this.Count - 1;
            T element = this.data[index];
            this.Data[index] = default(T);
            this.Count--;
            return element;
        }

        public override string ToString()
        {
            return string.Join(", ", this.Data.Take(this.Count));
        }
    }
}
