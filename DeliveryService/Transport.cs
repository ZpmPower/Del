using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService
{
    interface ILoader
    {
        void load(Parcel parcel);
    }
    abstract class Transport : ILoader
    {
        protected Capacity capacity = new Capacity();
        protected List<Parcel> trunk = new List<Parcel>();
        public void load(Parcel parcel)
        {
            if (capacity.currentCapacity < capacity.totalCapacity)
            {
                trunk.Add(parcel);
                capacity.currentCapacity += parcel.getWeight();
                Console.WriteLine(String.Format("Current cap: {0}\nTotal cap: {1}", capacity.currentCapacity,capacity.totalCapacity));
            }
        }
    }
    class Capacity
    {
        public int totalCapacity { set; get; }
        public int currentCapacity { set; get; }
    }
    class Car : Transport
    {
        public Car(int cap)
        {
            capacity.totalCapacity = cap;
        }
        
    }
    class Truck : Transport
    {
        public Truck(int c)
        {
            capacity.totalCapacity = c;
        }
    }
    class Motocycle : Transport
    {
        public Motocycle(int c)
        {
            capacity.totalCapacity = c;
        }
    }
    class Delivery
    {
        private ILoader loader_;
        List<Car> cars;
        List<Truck> trucks;
        List<Motocycle> motos;
        public Delivery(int c, int t, int m)
        {
            Random rnd = new Random();
            cars = new List<Car>();
            for (int i=0;i<c;i++)
            {
                cars.Add(new Car(rnd.Next(200, 300)));
            }
            trucks = new List<Truck>();
            for (int i = 0; i < t; i++)
            {
                trucks.Add(new Truck(rnd.Next(300, 350)));
            }
            motos = new List<Motocycle>();
            for (int i = 0; i < m; i++)
            {
                motos.Add(new Motocycle(rnd.Next(80, 150)));
            }
        }
        public List<Car> getCars() { return cars; }
        public List<Truck> getTrucks() { return trucks; }
        public List<Motocycle> getMotos() { return motos; }
        

        public void setTransport(ILoader transport)
        {
            loader_ = transport;
        }
        public void loadTransport(Parcel parcel)
        {
            loader_.load(parcel);
        }
    }
}
