using DependencyInjection.DependencyInjectionLibrary;
using DependencyInjection.TestClasses;
using System.Text;

namespace DependencyInjection
{
    class Program
    {
        static void Main()
        {
            var container = new DependencyInjectionContainer();

            container.AddTransientCreation<Ingredient>();
            container.AddSingletonCreation<Pie>();

            var pie = container.GetObject<Pie>();
            pie.Name = "piiiie";
            pie.ShowPieInfo();

            var pie2 = container.GetObject<Pie>();
            pie2.ShowPieInfo();

            var ingredient1 = container.GetObject<Ingredient>();
            ingredient1.Name = "not Chocolate";
            Console.WriteLine(ingredient1.Name);

            var ingredient2 = container.GetObject<Ingredient>();    
            Console.WriteLine(ingredient2.Name);
        }
    }
}