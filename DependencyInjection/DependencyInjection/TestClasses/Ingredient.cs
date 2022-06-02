using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.TestClasses
{
    internal class Ingredient
    {
        public string Name;
        //public Pie MyPie;
        public Ingredient()
        {
            //MyPie = pie;
            Name = "Chocolate"; 
        }

        public string GetIngredientInfo()
        {
            return Name;
        }
    }
}
