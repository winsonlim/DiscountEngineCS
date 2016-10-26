using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionCS
{
    public class DiscountCalculator
    {
        public Promotion Promo { get; set; }


        public DiscountCalculator(Promotion promotion)
        {
            Promo = promotion;
        }

        public Order CalculateDiscount(Order order)
        {
            //your implementation here

            var items = order.Items;

            for (int i = 0; i < items.Count; i++) {
                var eachItem = items[i];

                if (i+1 % Promo.EveryRepeatedItem == 0) {
                    var originalPrice = eachItem.Product.Price;

                    var discount = originalPrice * Promo.Discount;

                }
            
            }

            // order.Discount=100.00;

            return order;
        }
    }

}
