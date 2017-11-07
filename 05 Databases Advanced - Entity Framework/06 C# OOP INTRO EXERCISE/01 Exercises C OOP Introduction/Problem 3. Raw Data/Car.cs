namespace Problem_3.Raw_Data
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        internal Car()
        {
            this.tires = new Tire[4];
        }
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
            :this()
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return this.engine;
            }
            set
            {
                this.engine = value;
            }
        }

        public Cargo Cargo
        {
            get
            {
                return this.cargo;
            }
            set
            {
                this.cargo = value;
            }
        }

        public Tire [] Tires
        {
            get
            {
                return this.tires;
            }
            set
            {
                if(tires.Length!=4)
                {
                    throw new System.Exception();
                }
                this.tires = value;
            }
        }

        public override string ToString()
        {
            return $"{this.model}";
        }
    }
}
