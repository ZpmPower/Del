using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService
{
    public interface ILoader
    {
        void load(Parcel parcel);
    }
    public abstract class Transport : ILoader
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
        public string show()
        {
            return this.GetType().ToString() + " " + "Current: " + capacity.currentCapacity + " " + "total: " + capacity.totalCapacity;
        }
        public Capacity getCapacity() { return capacity; }
        public List<Parcel> getTrunk() { return trunk; }
    }
    public class Capacity
    {
        public int totalCapacity { set; get; }
        public int currentCapacity { set; get; }
    }
    public class Car : Transport
    {
        public Car(int cap)
        {
            capacity.totalCapacity = cap;
        }
        
    }
    public class Truck : Transport
    {
        public Truck(int c)
        {
            capacity.totalCapacity = c;
        }
    }
    public class Motocycle : Transport
    {
        public Motocycle(int c)
        {
            capacity.totalCapacity = c;
        }
    }
    public class Delivery
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
        public Tuple<int,int,int> getCountPark()
        {
            return new Tuple<int, int, int>(cars.Count, trucks.Count, motos.Count);
        }
        public string getParcels(List<Parcel> parcels)
        {
            string result = "";
            if (parcels.Count > 0)
            {
                foreach (Parcel p in parcels) result += p.getNumber() + " ";
            }
            return result;
        }
        public string showPark()
        {
            string result = "Cars:\n";
            foreach (Car c in cars)
            {
                result += c.show() + " " + "Parcels: ";
                result += getParcels(c.getTrunk()) + '\n';
            }
            result += "Trucks:\n";
            foreach (Truck t in trucks)
            {
                result += t.show() + " " + "Parcels: ";
                result += getParcels(t.getTrunk()) + '\n';
            }
            result += "Motos:\n";
            foreach (Motocycle m in motos)
            {
                result += m.show() + " " + "Parcels: ";
                result += getParcels(m.getTrunk()) + '\n';
            }
            return result;
        }
        public void clearPark()
        {
            foreach (Car c in cars)
            {
                c.getCapacity().currentCapacity = 0;
                c.getTrunk().Clear();
            }
            foreach (Truck t in trucks)
            {
                t.getCapacity().currentCapacity = 0;
                t.getTrunk().Clear();
            }
            foreach (Motocycle m in motos)
            {
                m.getCapacity().currentCapacity = 0;
                m.getTrunk().Clear();
            }
        }

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
