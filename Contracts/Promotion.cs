using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReadabilityDemo.Contracts
{
    [Flags]
    public enum Promotion
    {
        None = 1,
        ElderPeople = 2,
        FirstVisit = 4,
        RevisitAfter365Days = 6,
        Birthday = 8,
        SpecialOccasion = 10
    }
}
