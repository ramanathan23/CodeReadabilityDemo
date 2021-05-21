using CodeReadabilityDemo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReadabilityDemo.PromotionModule
{
    public static class CustomerPromotionRules
    {
        public static bool IsNotNull(this object obj) => obj != null;
        public static Customer IsExistingCustomer(this Customer customer) 
        {
            if (customer != null && customer.RegisteredDate != null && customer.RegisteredDate.Date < DateTime.Now.Date)
                return customer;
            return null;
        }

        public static Customer IsBirthdayFallsOnThisMonthButNotToday(this Customer customer)
        {
            var today = DateTime.Now;
            if (customer != null && customer.BirthDate != null && customer.BirthDate.Month == today.Month
                    && customer.BirthDate.Day != today.Day)
                return customer;
            return null;
        }

        public static Customer IsBirthdayToday(this Customer customer)
        {
            var today = DateTime.Now;
           if(customer != null && customer.BirthDate != null && customer.BirthDate.Month == today.Month
                    && customer.BirthDate.Day == today.Day)
                         return customer;
            return null;
        }

        public static Customer IsFirstVisit(this Customer customer)
        {
            if(customer != null && customer.LastVisitedAtStore == null)
                return customer;
            return null;
        }

        public static Customer IsCustomerVisitedTheStoreWithin30Days(this Customer customer)
        {
            if(customer!= null && customer.LastVisitedAtStore != null 
                && DateTime.Now.AddDays(-30).Date <= customer.LastVisitedAtStore.GetValueOrDefault().Date)
                   return customer;
            return null;
        }

        public static Customer IsCustomerAgeGreaterThanOrEqualto55(this Customer customer)
        {
            if (customer != null && customer.BirthDate != null
                && (DateTime.Now.Year - customer.BirthDate.Year) >= 55)
                return customer;
            return null;
        }

        public static Customer IsCustomerRevisitingStoreGreaterThan365Days(this Customer customer)
        {
            if (customer != null && customer.LastVisitedAtStore != null && customer.LastVisitedAtStore.GetValueOrDefault().AddDays(365).Date < DateTime.Now.Date)
                return customer;
            return null;
        }

        public static Customer IsWeddingAniversaryToday(this Customer customer)
        {
            var today = DateTime.Now;
            if (customer!= null && customer.WeddingDate != null && customer.WeddingDate.GetValueOrDefault().Month == today.Month
                        && customer.WeddingDate.GetValueOrDefault().Day == today.Day)
                return customer;
            return null;
        }
    }
}
