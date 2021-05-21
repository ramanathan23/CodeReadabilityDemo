using CodeReadabilityDemo.Contracts;
using CodeReadabilityDemo.StoreModule;
using System;
using System.Linq;

namespace CodeReadabilityDemo.PromotionModule
{
    public class PromotionService_V3 : IPromotionService
    {
        private readonly IStoreService storeService = null;
        public PromotionService_V3(IStoreService storeService)
        {
            this.storeService = storeService;
        }
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

                if (customer.BirthDate != null && (today.Year - customer.BirthDate.Year) >= 55 &&
                    customer.LastVisitedAtStore != null && today.AddDays(-30).Date <= customer.LastVisitedAtStore.GetValueOrDefault().Date)
                    eligiblePromotion = Promotion.ElderPeople;

                if (customer.LastVisitedAtStore != null && customer.LastVisitedAtStore.GetValueOrDefault().AddDays(365).Date < today.Date)
                    eligiblePromotion = Promotion.RevisitAfter365Days;

                var specialOccasions = this.storeService.GetStoreAuthorizedSpecialOccasions();
                if (specialOccasions.Any(i => i.Date.Day == today.Day && i.Date.Month == today.Month)
                    || (customer.RegisteredDate.Date < today.Date && customer.WeddingDate != null &&
                        customer.WeddingDate.GetValueOrDefault().Month == today.Month
                        && customer.WeddingDate.GetValueOrDefault().Day == today.Day))
                    eligiblePromotion = Promotion.SpecialOccasion;
            }

            return eligiblePromotion;
        }
    }
}
