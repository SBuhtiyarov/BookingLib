using System.Configuration;

namespace UZProvider
{
    public class UZAPIConfig
    {
        #region Methods: Protected

        protected virtual void GetUZAPIFromConfiguration() {
            var appSettings = ConfigurationManager.AppSettings;
            Culture = appSettings["UZCulture"];
            Host = appSettings["UZHost"];
            StationsURI = appSettings["UZStations"];
            TrainsURI = appSettings["UZTrains"];
            CoachesURI = appSettings["UZCoaches"];
            PlacesURI = appSettings["UZPlaces"];
            CardURI = appSettings["UZCard"];
        }

        #endregion

        #region Fields: Public

        public string Culture { get; protected set; }

        public string Host { get; protected set; }

        public string StationsURI { get; protected set; }

        public string TrainsURI { get; protected set; }

        public string CoachesURI { get; protected set; }

        public string PlacesURI { get; protected set; }

        public string CardURI { get; protected set; }

        #endregion

        #region Constructors: Public

        public UZAPIConfig() {
            GetUZAPIFromConfiguration();
        }

        public UZAPIConfig(string culture, string host, string stationsURI,
            string trainsURI, string coachesURI, string placesURI, string cardURI) {
            Culture = culture;
            Host = host;
            StationsURI = stationsURI;
            TrainsURI = trainsURI;
            CoachesURI = coachesURI;
            PlacesURI = placesURI;
            CardURI = cardURI;
        }

            #endregion
    }
}
