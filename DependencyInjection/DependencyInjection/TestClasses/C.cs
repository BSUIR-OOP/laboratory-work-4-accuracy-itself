using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.TestClasses
{
    internal class C
    {
        private A a;
        public C(Breakfast c, A a)
        {
            //this.a = a;
        }
    }
}
