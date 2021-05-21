using CodeReadabilityDemo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReadabilityDemo.PromotionModule
{
    public static class SpecialOccasionPromotionRules
    {
        public static IEnumerable<SpecialOccasion> IsAnySpecialOccasionToday(this IEnumerable<SpecialOccasion> specialOccasions)
        {
            var today = DateTime.Now;
            if (specialOccasions != null && specialOccasions.Count() > 0
                && specialOccasions.Any(i => i.Date.Day == today.Day && i.Date.Month == today.Month))
                    return specialOccasions;
            return null;
        }
    }
}
