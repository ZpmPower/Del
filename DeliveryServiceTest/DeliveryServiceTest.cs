using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeliveryService
{
    [TestClass]
    public class DeliveryServiceTest
    {
        [TestMethod]
        public void boxWeight()
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
        [TestMethod]
        public void parkCount()
        {
            int expected = 5;
            Delivery delivery = new Delivery(1, 2, 2);
            Tuple<int, int, int> allCount = delivery.getCountPark();
            int actual = allCount.Item1 + allCount.Item2 + allCount.Item3;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void isUnique()
        {
            DeliveryService deliveryService;
            deliveryService = DeliveryService.getInstance("MyService", 1, 2, 3);
            string number1 = deliveryService.generateId();
            string number2 = deliveryService.generateId();
            Assert.AreNotEqual(number1, number2);
        }
        [TestMethod]
        public void sendingCode()
        {
            Client c1 = new Client("Evgeniy", "Emelyanov", "Sergeevich", "+380963245576");
            DeliveryService deliveryService;
            deliveryService = DeliveryService.getInstance("MyService", 1, 2, 1);
            string expected = deliveryService.generateId();
            deliveryService.sendNumber(c1, expected);
            Assert.AreEqual(expected, c1.getNumberAt(0));
        }
        [TestMethod]
        public void choosingTrasport()
        {
            Box b5 = new Box();
            Box b6 = new Box();
            b5.addBox(b6);
            Item i7 = new Item(100);
            b5.addItem(i7);
            Parcel p1 = new Parcel(b5);
            Client c1 = new Client("Evgeniy", "Emelyanov", "Sergeevich", "+380963245576");
            Client c2 = new Client("Alex", "Kukishev", "Alexeevich", "+380553245576");
            Type expected = new Truck(500).GetType();
            DeliveryService deliveryService;
            deliveryService = DeliveryService.getInstance("MyService", 1, 2, 1);
            deliveryService.sendParcel(c1, c2, p1);
            Type actual = deliveryService.getDelivery().getLoader().GetType();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void carWeightTest()
        {
            Box b5 = new Box();
            Box b6 = new Box();
            b5.addBox(b6);
            Item i7 = new Item(100);
            b5.addItem(i7);
            Parcel p1 = new Parcel(b5);
            Car car = new Car(250);
            int expected = 100;
            car.load(p1);
            int actual = car.getCapacity().currentCapacity;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void carTrunkTest()
        {
            Box b5 = new Box();
            Box b6 = new Box();
            b5.addBox(b6);
            Item i7 = new Item(100);
            b5.addItem(i7);
            Parcel p1 = new Parcel(b5);
            Car car = new Car(250);
            car.load(p1);
            int expected = 0;
            int actual = car.getTrunk().IndexOf(p1);
            Assert.AreEqual(expected, actual);
        }
    }
}
