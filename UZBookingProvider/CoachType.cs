using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZBookingProvider
{
    enum CoachType
    {
        Platzkart,
        Coupe,
        Lux,
        Seat1,
        Seat2,
        Any = Platzkart | Coupe | Lux | Seat1 | Seat2
    }

    //TODO: possible to use attributes or something else instead type with static field
    class CoachTypes
    {
        public static Dictionary<CoachType, string> Mapping;
        
        static CoachTypes() {
            Mapping = new Dictionary<CoachType, string> {
                {CoachType.Platzkart, "П" },
                {CoachType.Coupe, "К" },
                {CoachType.Lux, "Л" },
                {CoachType.Seat1, "С1" },
                {CoachType.Seat2, "С2" }
            };
        }     
    }
}
