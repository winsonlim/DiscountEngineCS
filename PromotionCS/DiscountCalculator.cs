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

            switch (Promo.Name) {
                case "multi":
                    foreach (OrderItem item in items) {
                        for (int i = 0; i < item.Quantity; i++) {
                            // +1 to get first item as index 1.
                            if (Promo.EveryRepeatedItem == 0) {
                                // No discounts
                                break;
                            }

                            if ((i + 1) % Promo.EveryRepeatedItem == 0) {
                                // Calculate discounted price
                                var originalPrice = item.Product.Price;

                                var discount = originalPrice * Promo.Discount;
                                order.Discount += discount;
                            }
                        }
                    }

                    break;
                    case "progressive":
                        foreach (OrderItem item in items) {
                            if (item.Quantity > 2) {
                                // 20% whole cart
                                for (int i = 0; i < item.Quantity; i++) {
                                    var originalPrice = item.Product.Price;

                                    var discount = originalPrice * Promo.Discount;
                                    order.Discount += discount;
                                }
                            }
                            else
                            {   
                                // 10% discount first item only
                                for (int i = 0; i < item.Quantity; i++)
                                {
                                    var originalPrice = item.Product.Price;
                                    var discount = 0.0;
                                    if (i == 0) {
                                        discount = originalPrice * Promo.Discount;
                                    }
                                    
                                    order.Discount += discount;
                                }
                            }

                        }
                    break;
            }

            return order;
        }
    }

}
