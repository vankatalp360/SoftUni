namespace Problem_1.Class_Box
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
                    throw new Exception("Not allowed negative or zero value!");
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
                    throw new Exception("Not allowed negative or zero value!");
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
                    throw new Exception("Not allowed negative or zero value!");
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
