using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.TestClasses
{
    internal class Pie
    {
        public string Name;
        private Ingredient MainIngredient; 
        public Pie(Ingredient ingredient)
        {
            MainIngredient = ingredient;
            Name = ingredient.Name + " pie";
        }

        public void ShowPieInfo()
        {
            Console.WriteLine("The pie '" + Name+ "' is made of " + MainIngredient.GetIngredientInfo());
        }
    }
}
