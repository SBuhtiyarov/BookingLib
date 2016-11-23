
namespace UZBookingProvider.Http.Security
{
    interface IToken
    {
       string Value { get; }

       void DecodeToken(string encodeString);
    }
}
