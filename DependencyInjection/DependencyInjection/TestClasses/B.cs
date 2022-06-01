using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DependencyInjection.TestClasses
{
    internal class B
    {
        private A a;
        public B(A a)
        {
            this.a = a;
        }
    }
}
