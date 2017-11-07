
namespace Problem_2.Class_Box_Validation
{
    using System;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public double CalcSurfaceArea()
        {
            return 2 * (this.length * this.width + this.length * this.height + this.width * this.height);
        }

        public double CalcLateralSurfaceArea()
        {
            return 2 * (this.length * this.height + this.width * this.height);
        }

        public double CalcVolume()
        {
            return this.length * this.width * this.height;
        }
    }
}
