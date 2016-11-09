using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZBookingProvider
{
    interface IToken
    {
       string Value { get; }

       void DecodeToken(string encodeString);
    }
}
