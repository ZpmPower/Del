using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService
{
    class Box
    {
        List<Item> items_ = new List<Item>() ;
        List<Box> boxes_ = new List<Box>();
        public List<Item> getItems ()
        {
            return items_;
        }
        public List<Box> getBoxes()
        {
            return boxes_;
        }
        public void addItem(Item item)
        {
            items_.Add(item);
        }
        public void addBox(Box box)
        {
            boxes_.Add(box);
        }
    }
}
