using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_8.Personal_Exception
{
    public class Personal_Exception : Exception
    {
        public Personal_Exception() : base("My first exception is awesome!!!") { }
    }
}
