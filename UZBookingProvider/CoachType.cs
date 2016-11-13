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
        Seat,
        Any = Platzkart | Coupe | Lux | Seat
    }
}
