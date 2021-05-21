using CodeReadabilityDemo.Contracts;
using CodeReadabilityDemo.PromotionModule;
using CodeReadabilityDemo.StoreModule;
using System;
using System.Collections.Generic;

namespace CodeReadabilityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IPromotionService promotionService = new PromotionService_Final(new StoreService());
            foreach (var customer in GetCustomers())
            {
                var promotion = promotionService.GetEligiblePromotion(customer);
                Console.WriteLine($"Case: {customer.Name} | Promotion: { promotion.ToString() }");
            }
            Console.Read();
        }

        private static IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer () {
                    Name = "BirthDay In Current Month",
                    BirthDate = DateTime.Now.AddYears(-30).AddDays(2),
                    RegisteredDate = DateTime.Now.AddYears(-1),
                    LastVisitedAtStore = DateTime.Now.AddDays(-10)
                },
                new Customer () {
                    Name = "BirthDay In Current Month - Registered Today",
                    BirthDate = DateTime.Now.AddYears(-30).AddDays(2),
                    RegisteredDate = DateTime.Now,
                    LastVisitedAtStore = DateTime.Now.AddDays(-10)
                },
                new Customer () {
                    Name ="Birthday today - First Visit",
                    BirthDate = DateTime.Now,
                    RegisteredDate = DateTime.Now,
                    LastVisitedAtStore = null
                },
                new Customer () {
                    Name ="Birthday today - Second Visit on same day",
                    BirthDate = DateTime.Now,
                    RegisteredDate = DateTime.Now,
                    LastVisitedAtStore = DateTime.Now
                },
                new Customer () {
                    Name = "Age Greater than 55 - Visiting the store within 30 days",
                    BirthDate = DateTime.Now.AddYears(-60),
                    LastVisitedAtStore = DateTime.Now.AddDays(-20)
                },
                new Customer () {
                    Name = "Age Greater than 55 - Visiting the store more than 30 days",
                    BirthDate = DateTime.Now.AddYears(-60),
                    LastVisitedAtStore = DateTime.Now.AddDays(-40)
                },
                new Customer () {
                    Name = "Revisiting the store more than a year",
                    LastVisitedAtStore = DateTime.Now.AddDays(-400)
                },
                new Customer () {
                    Name = "Visiting the Store on occassion - Existing Customer",
                    WeddingDate = new DateTime(2019, DateTime.Now.Month, DateTime.Now.Day),
                    RegisteredDate = DateTime.Now.AddDays(-10)
                },
                new Customer () {
                    Name = "Visiting the Store on occassion - New Customer",
                    WeddingDate = new DateTime(2019, DateTime.Now.Month, DateTime.Now.Day),
                    RegisteredDate = DateTime.Now
                }
            };
        }
    }
}
