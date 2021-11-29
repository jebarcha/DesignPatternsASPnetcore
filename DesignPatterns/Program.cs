using DesignPatterns.BuilderPattern;
using DesignPatterns.DependencyInjectionPattern;
using DesignPatterns.FactoryPattern;
using DesignPatterns.Models;
using DesignPatterns.RepositoryPattern;
using DesignPatterns.StatePattern;
using DesignPatterns.Strategy;
using DesignPatterns.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestSingletonPattern();
            //TestFactoryPattern();
            //TestDependencyInjectionPattern();
            //TestRepositoryPattern3();
            //TestUnitOfWorkPattern();
            //TestStrategyPattern();
            //TestBuilderPattern();

            TestStatePattern();


        }
        static void TestStatePattern()
        {
            var customerContext = new CustomerContext();
            Console.WriteLine(customerContext.GetState());
            customerContext.Request(100);
            Console.WriteLine(customerContext.GetState());

            customerContext.Request(50);
            Console.WriteLine(customerContext.GetState());

            customerContext.Request(100);
            Console.WriteLine(customerContext.GetState());

            customerContext.Request(50);
            Console.WriteLine(customerContext.GetState());

            customerContext.Request(50);
            Console.WriteLine(customerContext.GetState());

        }
        static void TestBuilderPattern()
        {
            var builder = new PreparedAlcoholicDrinkConcreteBuilder();
            var barmanDirector = new BarmanDirector(builder);

            barmanDirector.PreparePinaColada();

            var preparedDrink = builder.GetPreparedDrink();
            Console.WriteLine(preparedDrink.Result);
        }

        static void TestStrategyPattern()
        {
            var context = new Context(new CarStrategy());
            context.Run();

            context.Strategy = new MotoStrategy();
            context.Run();

            context.Strategy = new BiciStrategy();
            context.Run();
        }
        static void TestRepositoryPattern1()
        {
            // in package management console (from menu - tools - Nuget package manager - Package manager console ):
            //Scaffold-DbContext "Server=JEBARCHA-PC\SQLEXPRESS; Database=DesignPatterns; Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

            using (var context = new DesignPatternsContext())
            {
                var lst = context.Beers.ToList();
                foreach (var beer in lst)
                {
                    Console.WriteLine(beer.Name);
                }
            }
        }
        static void TestUnitOfWorkPattern()
        {
            using (var context = new DesignPatternsContext())
            {
                var unitOfWork = new UnitOfWork(context);
                
                var beers = unitOfWork.Beers;
                var beer = new Models.Beer()
                {
                    Name = "Fuller",
                    Style = "Porter"
                };
                beers.Add(beer);

                var brands = unitOfWork.Brands;
                var brand = new Brand()
                {
                    Name = "Fuller"
                };
                brands.Add(brand);

                unitOfWork.Save();
            }
        }
        static void TestRepositoryPattern2()
        {
            // in package management console (from menu - tools - Nuget package manager - Package manager console ):
            //Scaffold-DbContext "Server=JEBARCHA-PC\SQLEXPRESS; Database=DesignPatterns; Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force

            using (var context = new DesignPatternsContext())
            {
                var beerRepository = new BeerRepository(context);
                var beer = new Models.Beer();
                beer.Name = "Corona";
                beer.Style = "Pilsner";
                beerRepository.Add(beer);
                beerRepository.Save();

                foreach (var b in beerRepository.Get())
                {
                    Console.WriteLine(b.Name);
                }
            }
        }
        static void TestRepositoryPattern3()
        {
            using (var context = new DesignPatternsContext())
            {
                var beerRepository = new Repository<Models.Beer>(context);
                var beer = new Models.Beer() { Name = "Fuller", Style = "Strong Ale" };
                beerRepository.Add(beer);
                beerRepository.Save();

                foreach (var b in beerRepository.Get())
                {
                    Console.WriteLine(b.Name);
                }

                var brandRepository = new Repository<Models.Brand>(context);
                var brand = new Brand();
                brand.Name = "Fuller";
                brandRepository.Add(brand);
                brandRepository.Save();

                foreach (var br in brandRepository.Get())
                {
                    Console.WriteLine(br.Name);
                }
            }
        }
        static void TestDependencyInjectionPattern()
        {
            var beer = new DependencyInjectionPattern.Beer("Pikantus", "Erdinger");
            var drinkWithBeer = new DrinkWithBeer(10, 1, beer);
            drinkWithBeer.Build();
        }
        static void TestFactoryPattern()
        {
            SaleFactory storeSaleFactory = new StoreSaleFactory(20);
            ISale sale1 = storeSaleFactory.GetSale();
            sale1.Sell(100);

            SaleFactory internetSaleFactory = new InternetSaleFactory(10);
            ISale sale2 = internetSaleFactory.GetSale();
            sale2.Sell(100);
        }

        static void TestSingletonPattern()
        {
            //var singleton = Singleton.Singleton.Instance;
            var log = Singleton.Log.Instance;
            log.Save("Test1...");

            var log2 = Singleton.Log.Instance;
            log2.Save("Test2..");
        }
    }
}
