using System.Collections.Generic;

namespace C_and_ASP.NET
{
    internal class AppDbContext
    {
        public AppDbContext()
        {
        }

        public IEnumerable<object> Articles { get; internal set; }
    }
}