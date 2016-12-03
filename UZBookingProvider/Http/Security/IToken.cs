
namespace CITR.UZBookingProvider.Http.Security
{
    interface IToken
    {
        bool IsInitialized { get; }

        string Value { get; }

        void DecodeToken(string encodeString);
    }
}