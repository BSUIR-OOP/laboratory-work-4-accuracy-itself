using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.TestClasses
{
    internal class DayFood
    {
        private Breakfast MainMeal;
        public DayFood(Breakfast meal)
        {
            MainMeal = meal;
        }

        public void ShowFoodInfo()
        {
            Console.WriteLine("Day consists of " + MainMeal.MainDish.Name);
        }
    }
}
