using CodeReadabilityDemo.Contracts;
using System;

namespace CodeReadabilityDemo.PromotionModule
{
    public class PromotionService_V2 : IPromotionService
    {
        public Promotion GetEligiblePromotion(Customer customer)
        {
            var eligiblePromotion = Promotion.None;
            if (customer != null)
            {
                var today = DateTime.Now;

                if (customer.BirthDate != null && customer.BirthDate.Month == today.Month
                    && customer.BirthDate.Day != today.Day
                    && customer.RegisteredDate != null && customer.RegisteredDate.Date < today.Date)
                    eligiblePromotion = Promotion.Birthday;

                if (customer.BirthDate != null && customer.BirthDate.Month == today.Month
                    && customer.BirthDate.Day == today.Day && customer.LastVisitedAtStore == null)
                    eligiblePromotion = Promotion.Birthday | Promotion.FirstVisit;

                if (customer.BirthDate != null && (today.Year - customer.BirthDate.Year) >= 55 
                    && customer.LastVisitedAtStore != null 
                    && DateTime.Now.AddDays(-30).Date <= customer.LastVisitedAtStore.GetValueOrDefault().Date)
                    eligiblePromotion = Promotion.ElderPeople;
            }

            return eligiblePromotion;
        }
    }
}
