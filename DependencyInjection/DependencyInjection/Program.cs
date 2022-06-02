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

            container.AddSingletonCreation<Ingredient>();
            container.AddTransientCreation<Pie>();
            container.AddTransientCreation<Breakfast>();
            container.AddTransientCreation<DayFood>();
            
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

            var breakfast = container.GetObject<Breakfast>();
            breakfast.ShowBreakfastInfo();

            var dayFood = container.GetObject<DayFood>();
            dayFood.ShowFoodInfo();

            container.AddSingletonCreation<A>();
            container.AddTransientCreation<B>();
            container.AddTransientCreation<C>();
            var a = container.GetObject<A>();
        }
    }
}