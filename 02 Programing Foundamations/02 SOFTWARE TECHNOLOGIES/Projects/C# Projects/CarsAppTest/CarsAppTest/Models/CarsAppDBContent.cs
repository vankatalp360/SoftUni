namespace CarsAppTest.Models
{
    using System.Data.Entity;

    public class CarsAppDBContent : DbContext
    {

        public CarsAppDBContent()
            : base("name=CarsAppDBContent")
        {
        }
        public virtual DbSet<Car> Cars { get; set; }
    }
}
