using DependencyInjection.TestClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    internal class Pie
    {
        public string Name;
        private Ingredient MainIngredient; 
        public Pie(Ingredient ingredient)
        {
            MainIngredient = ingredient;
        }

        public void ShowPieInfo()
        {
            Console.WriteLine("The pie '" + Name+ "' is made of " + MainIngredient.GetIngredientInfo());
        }
    }
}
