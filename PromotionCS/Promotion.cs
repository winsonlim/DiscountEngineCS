using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionCS
{
    public class Promotion
    {
        public double Discount { get; set; }
        public string Name { get; set; }
        public int EveryRepeatedItem { get; set; }


        public Promotion(string name, double discount, int everyRepeatedItem)
        {
            Discount = discount;
            Name = name;
            EveryRepeatedItem = everyRepeatedItem;
        }
    }
}
