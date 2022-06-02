using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DependencyInjection.TestClasses
{
    internal class B
    {
        private C c;

        public B(Breakfast k, C c)
        {
            this.c = c;
        }
    }
}
