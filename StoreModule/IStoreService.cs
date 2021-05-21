using CodeReadabilityDemo.Contracts;
using System.Collections.Generic;

namespace CodeReadabilityDemo.StoreModule
{
    public interface IStoreService
    {
        IEnumerable<SpecialOccasion> GetStoreAuthorizedSpecialOccasions();
    }
}
