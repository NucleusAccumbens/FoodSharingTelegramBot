using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.DataAccessLayer.Enums
{
    public enum Cities
    {
        Batumi,
        Tbilisi
    }

    public enum Languages
    {
        Russian,
        English,
        Georgian
    }

    public class UserEnumParser
    {
        public string CityToString(Cities city)
        {
            if (city == Cities.Tbilisi) return "Тбилиси";
            else return "Батуми";
        }

        public string LanguageToString(Languages language)
        {
            if (language == Languages.Russian) return "Русский";
            if (language == Languages.English) return "English";
            else return "🇬🇪 ქართული 🇬🇪";
        }
    }
}
