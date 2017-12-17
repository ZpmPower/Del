using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService
{
    public class Parcel
    {
        Box mainBox;
        int weight_;
        string number;
        public Parcel(Box box)
        {
            mainBox = new Box();
            if (box.getBoxes().Count > 0 && box.getItems().Count > 0 )
            {
                mainBox = box;
            }
            calcWeightParcel();
        }
        public void setNumber(string s)
        {
            if (s.Length == 8)
            {
                number = s;
            }
        }
        public string getNumber()
        {
            return number;
            
        }
        public int getWeight()
        {
            return weight_;
        }
        public void calcWeightParcel()
        {
            weight_ = mainBox.caclWeightBox(mainBox);
        }

    }
}
