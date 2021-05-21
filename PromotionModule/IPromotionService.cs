using CodeReadabilityDemo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReadabilityDemo.PromotionModule
{
    public interface IPromotionService
    {
        Promotion GetEligiblePromotion(Customer customer);
    }
}
