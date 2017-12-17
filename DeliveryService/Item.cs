using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService
{
    class Item
    {
        int weight_;
        public int Weight
        {
            get => weight_;
            set => weight_ = value;
        }
        public Item(int w) { weight_ = w; }
    }
}
