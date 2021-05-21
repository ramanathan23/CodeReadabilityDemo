using CodeReadabilityDemo.Contracts;
using System;

namespace CodeReadabilityDemo.PromotionModule
{
    public class PromotionService_V1 : IPromotionService
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
            }

            return eligiblePromotion;
        }
    }
}
