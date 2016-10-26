﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PromotionCS
{
    public class Order
    {
        public double Discount { get; set; }

        public List<OrderItem> Items { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
        }

        public double TotalPrice
        {
            get
            {
                double total = 0;
                foreach (OrderItem item in Items)
                {
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        total += item.Product.Price;
                    }
                }

                return total;
            }
        }

        public double DiscountedPrice
        {
            get
            {
                double total = 0;
                foreach (OrderItem item in Items)
                {
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        total += item.Product.Price;
                    }
                }

                return total - Discount;
            }
        }

        public void Add(Product product, int qty)
        {
            OrderItem oi = GetOrderItem(product.Sku);

            if (oi == null)
            {
                oi = new OrderItem();
                oi.Product = product;
                oi.Quantity = qty;
                Items.Add(oi);
                SortBySku();
            }
            else
            {
                oi.Quantity += qty;
            }

        }

        public OrderItem GetOrderItem(string sku)
        {
            return Items.Find(o => o.Product.Sku == sku);
        }

        public void SortBySku()
        {
            Items.Sort(delegate(OrderItem item1, OrderItem item2)
            {
                return item1.Product.Sku.CompareTo(item2.Product.Sku);
            });
        }   

    }

    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
