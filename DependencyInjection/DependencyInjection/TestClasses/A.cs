using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.TestClasses
{
    internal class A
    {
        private B b;
        public A(B b)
        { 
            this.b = b; 
        }
    }
}
