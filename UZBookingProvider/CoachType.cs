using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UZBookingProvider.DataAccess;

namespace UZBookingProvider
{
    enum CoachType
    {
        Platzkart,
        Coupe,
        Lux,
        Seat1,
        Seat2,
        Seat = Seat1 | Seat2,
        Any = Platzkart | Coupe | Lux | Seat1 | Seat2
    }
}
