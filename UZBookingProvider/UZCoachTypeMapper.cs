using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITR.UZBookingProvider
{
    class UZCoachTypeMapper
    {
        private static Dictionary<CoachType, string> _coachTypesPerLetters;

        private static Dictionary<string, string> _coachIdsPerLetters;

        static UZCoachTypeMapper() {
            _coachTypesPerLetters = new Dictionary<CoachType, string> {
                {CoachType.Platzkart, "П" },
                {CoachType.Coupe, "К" },
                {CoachType.Lux, "Л" },
                {CoachType.Seat1, "С1" },
                {CoachType.Seat2, "С2" }
            };
            _coachIdsPerLetters = new Dictionary<string, string> {
                {"4", "П" },
                {"3", "К" },
                {"1", "Л" }
            };
        }

        public static CoachType GetCoachType(string id) {
            var letter = GetCoachLetter(id);
            var typesPerLetters = _coachTypesPerLetters.Where(it => it.Value == letter);
            if (typesPerLetters.Any()) {
                return typesPerLetters.First().Key;
            }
            return CoachType.Seat;
        }

        public static string GetCoachLetter(CoachType coachType) {
            return _coachTypesPerLetters[coachType];
        }

        public static string GetCoachLetter(string id) {
            var letter = "";
            if (_coachIdsPerLetters.TryGetValue(id, out letter)) {
                return letter;
            }
            return "С";
        }
    }
}
