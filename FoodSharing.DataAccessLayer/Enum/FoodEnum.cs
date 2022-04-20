using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.DataAccessLayer.Enum
{
    public enum FoodCategory
    {
        PlantBasedRawFoods,
        VeganFoods,
        Grocery,
        PlourProducts,
        Sweet,
        Other
    }

    public class FoodEnumParser
    {
        public string FoodCategoryToString(FoodCategory category)
        {
            if (category == FoodCategory.PlantBasedRawFoods) return "Сырая растительная пища";
            if (category == FoodCategory.VeganFoods) return "Веган продукты";
            if (category == FoodCategory.Grocery) return "Бакалея";
            if (category == FoodCategory.PlourProducts) return "Мучные изделия";
            if (category == FoodCategory.Sweet) return "Сладости";
            else return "Другое";
        }
    }
}
