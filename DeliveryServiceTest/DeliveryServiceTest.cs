using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeliveryService
{
    [TestClass]
    public class DeliveryServiceTest
    {
        [TestMethod]
        public void boxWeight1()
        {
            //arrange
            Box b5 = new Box();
            Box b6 = new Box();
            b5.addBox(b6);
            Item i7 = new Item(100);
            b5.addItem(i7);
            int expected = 100;
            //actual
            int actual = b5.caclWeightBox(b5);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void parcelWeight()
        {
            //arrange
            Box main = new Box();
            Box b1 = new Box();
            Box b2 = new Box();
            Box b3 = new Box();
            Box b4 = new Box();
            b1.addItem(new Item(1));
            b1.addBox(b2);
            b2.addItem(new Item(2));
            b2.addItem(new Item(3));
            b3.addItem(new Item(4));
            b3.addItem(new Item(5));
            b1.addBox(b3);
            b3.addBox(b4);
            b4.addItem(new Item(5));
            int expected = 20;
            //actual
            Parcel p = new Parcel(b1);
            p.calcWeightParcel();
            int actual = p.getWeight();
             //assert
             Assert.AreEqual(expected, actual);
        }
    }
}
