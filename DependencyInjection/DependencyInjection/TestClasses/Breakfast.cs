using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.TestClasses
{
    internal class Breakfast
    {
        public Pie MainDish;
        public Breakfast(Pie pie)
        {
            MainDish = pie;
        }

        public void ShowBreakfastInfo()
        {
            Console.WriteLine("The breakfast consists of " + MainDish.Name);
        }
    }
}
