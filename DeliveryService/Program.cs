﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            //first
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
            //second
            Box b5 = new Box();
            Box b6 = new Box();
            b5.addBox(b6);
            Item i7 = new Item(100);
            b5.addItem(i7); 

            Parcel p1 = new Parcel(b1);
            Parcel p2 = new Parcel(b5);
            Console.WriteLine(p2.getWeight());
            DeliveryService deliveryService;
            deliveryService = DeliveryService.getInstance("MyService", 3, 3, 3);
            Console.WriteLine(deliveryService.Name);
            //deliveryService.showPark();
            Client c1 = new Client("Vadim", "Kalishuk", "Bogdanovich", "+380962345588");
            Client c2 = new Client("Vladka", "Swit", "Alexseevich", "+380956745588");
            deliveryService.sendParcel(c1, c2, p1);
            deliveryService.sendParcel(c2, c1, p2);
            deliveryService.showPark();
            deliveryService.startDelivery();
            deliveryService.showPark();
            c2.showNumbers();
            //Console.WriteLine(c2.info());
            deliveryService.receiveParcel(c2, c2.getNumberAt(0));
            deliveryService.receiveParcel(c1, c1.getNumberAt(0));
        }
    }
}
