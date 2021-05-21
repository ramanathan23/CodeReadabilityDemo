using CodeReadabilityDemo.Contracts;
using CodeReadabilityDemo.StoreModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReadabilityDemo.PromotionModule
{
    public class PromotionService_Final : IPromotionService
    {
        private readonly IStoreService storeService = null;
        public PromotionService_Final(IStoreService storeService)
        {
            this.storeService = storeService;
        }
        public Promotion GetEligiblePromotion(Customer customer)
        {
            var eligiblePromotion = Promotion.None;

            if (customer.IsExistingCustomer().IsBirthdayFallsOnThisMonthButNotToday().IsNotNull())
                eligiblePromotion = Promotion.Birthday;

            if (customer.IsBirthdayToday().IsFirstVisit().IsNotNull())
                eligiblePromotion = Promotion.Birthday | Promotion.FirstVisit;

            if (customer.IsCustomerVisitedTheStoreWithin30Days()
                .IsCustomerAgeGreaterThanOrEqualto55().IsNotNull())
                eligiblePromotion = Promotion.ElderPeople;

            if (customer.IsCustomerRevisitingStoreGreaterThan365Days().IsNotNull())
                eligiblePromotion = Promotion.RevisitAfter365Days;

            if (this.storeService.GetStoreAuthorizedSpecialOccasions()
                                 .IsAnySpecialOccasionToday().IsNotNull() ||
                                 customer.IsExistingCustomer()
                                         .IsWeddingAniversaryToday().IsNotNull())
                eligiblePromotion = Promotion.SpecialOccasion;

            return eligiblePromotion;
        }
    }
}
