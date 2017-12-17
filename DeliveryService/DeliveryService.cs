using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService
{
    public class DeliveryService
    {
        private static DeliveryService instance;
        Delivery delivery;
        List<Tuple<Client,Client,Parcel>> parcelsClients;
        public string Name { set; get; }
        private DeliveryService(string name, int c, int t, int m)
        {
            delivery = new Delivery(c,t,m);
            Name = name;
            parcelsClients = new List<Tuple<Client, Client, Parcel>>();
        }

        public static DeliveryService getInstance(string name, int c, int t, int m)
        {
            if (instance == null)
                instance = new DeliveryService(name,c, t, m);
            return instance;
        }
        public Delivery getDelivery()
        {
            return delivery;
        }
        public void showPark()
        {
            Console.WriteLine(delivery.showPark());
        }
        public void sendParcel(Client client1, Client client2, Parcel parcel)
        {
            string parcelNumber = generateId();
            parcel.setNumber(parcelNumber);
            parcelsClients.Add(new Tuple<Client, Client, Parcel>(client1, client2, parcel));

            if (parcel.getWeight() < 15 && parcel.getWeight() > 0)
                delivery.setTransport(toLoadMoto(delivery.getMotos(),parcel));
            if (parcel.getWeight() > 15 && parcel.getWeight() < 50)
                delivery.setTransport(toLoadCar(delivery.getCars(), parcel));
            if (parcel.getWeight() >= 50)
                delivery.setTransport(toLoadTruck(delivery.getTrucks(), parcel));

            delivery.loadTransport(parcel);
            sendNumber(client2,parcel.getNumber());
        } 
        public void startDelivery()
        {
            Console.Write("Parcels: ");
            List<Car> cars = delivery.getCars();
            List<Truck> trucks = delivery.getTrucks();
            List<Motocycle> motos= delivery.getMotos();
            foreach (Car c in cars)
            {
                foreach (Parcel p in c.getTrunk())
                Console.Write(p.getNumber() + " ");
            }
            foreach (Truck t in trucks)
            {
                foreach (Parcel p in t.getTrunk())
                    Console.Write(p.getNumber() + " ");
            }
            foreach (Motocycle m in motos)
            {
                foreach (Parcel p in m.getTrunk())
                    Console.Write(p.getNumber() + " ");
            }
            Console.Write("was delivered succesfull\n");
            delivery.clearPark();
        }
        public string generateId()
        {
            long i = 1; foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            string s = string.Format("{0:d8}", i - DateTime.Now.Millisecond);
            s = s.Remove(9);
            s = s.Remove(0, 1);
            return s;
            
        }
        public void sendNumber(Client client, string number)
        {
            client.addNumber(number);
        }
        public void receiveParcel(Client client, string number)
        {
            if (number.Length == 8)
            {
                foreach (Tuple<Client,Client,Parcel> t in parcelsClients)
                {
                    if (t.Item2 == client && t.Item3.getNumber() == number)
                    {
                        client.getParcel(t.Item3);
                        parcelsClients.Remove(t);
                        Console.WriteLine(client.info() + " received parcel : " + number);
                        return;
                    }
                }
            }
            else Console.WriteLine("Parcel number must have size = 8");
        }
        
        public Car toLoadCar(List<Car> cars, Parcel parcel)
        {
            int i;
            for (i=0; i<cars.Capacity;i++)
                if (cars[i].getCapacity().currentCapacity + parcel.getWeight() <= cars[i].getCapacity().totalCapacity)
                    break;
            return cars[i];
        }
        public Truck toLoadTruck(List<Truck> trucks, Parcel parcel)
        {
            int i;
            for (i = 0; i < trucks.Capacity; i++)
                if (trucks[i].getCapacity().currentCapacity + parcel.getWeight() <= trucks[i].getCapacity().totalCapacity)
                    break;
            return trucks[i];
        }
        public Motocycle toLoadMoto(List<Motocycle> motos, Parcel parcel)
        {
            int i;
            for (i = 0; i < motos.Capacity; i++)
                if (motos[i].getCapacity().currentCapacity + parcel.getWeight() <= motos[i].getCapacity().totalCapacity)
                    break;
            return motos[i];
        }
    }
}
