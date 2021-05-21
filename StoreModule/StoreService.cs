using CodeReadabilityDemo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReadabilityDemo.StoreModule
{
    public class StoreService : IStoreService
    {
        public IEnumerable<SpecialOccasion> GetStoreAuthorizedSpecialOccasions()
        {
            return new List<SpecialOccasion>
            {
                new SpecialOccasion()
                {
                    Occasion = "StoreAnniversary",
                    Date = new DateTime(1953, 5, 1)
                },
                new SpecialOccasion()
                {
                    Occasion = "NewYear",
                    Date = new DateTime(DateTime.Now.Year, 1, 1)
                }
            };
        }
    }
}
