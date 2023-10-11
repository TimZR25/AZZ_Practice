using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Prac3_3
{
    public class FoodProduct : IComparable
    {
        private string _name = "NULL";
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == string.Empty) throw new ArgumentNullException("Неправильно указано имя продукта");
                _name = value;
            }
        }

        private double _weight;
        public double Weight
        {
            get { return _weight; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Неправильно указана масса продукта");
                _weight = value;
            }
        }

        private double _temperature;
        public double Temperature
        {
            get { return _temperature; }
            set
            {
                if ((value <= -30) || (value >= 110)) throw new ArgumentOutOfRangeException("Неправильно указана температура продукта");
                _temperature = value;

                Status = ProductStatus.NORMAL;
                if (_temperature >= MaxTemperature) Status = ProductStatus.OVERHEATED;
                if (_temperature <= MinTemperature) Status = ProductStatus.FROSTBITTEN;
            }
        }

        private double _maxTemperature;
        public double MaxTemperature
        {
            get { return _maxTemperature; }
            private set
            {
                if ((value <= -30) || (value >= 110)) throw new ArgumentOutOfRangeException("Неправильно указана максимальная температура продукта");
                _maxTemperature = value;
            }
        }

        private double _minTemperature;
        public double MinTemperature
        {
            get { return _minTemperature; }
            private set
            {
                if ((value <= -30) || (value >= 110)) throw new ArgumentOutOfRangeException("Неправильно указана минимальная температура продукта");
                _minTemperature = value;
            }
        }

        private ProductStatus _status;
        public ProductStatus Status
        {
            get { return _status; }
            private set
            {
                _status = value;
            }
        }

        private double _heatCapacity;
        public double HeatCapacity
        {
            get { return _heatCapacity; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Неправильно указана теплоемкость продукта");
                _heatCapacity = value;
            }
        }

        public FoodProduct(string name = "NULL", double weight = 0, double temperature = 0, double maxTemperature = 0,
            double minTemperature = 0, double heatCapacity = 0)
        {
            Name = name;
            Weight = weight;
            Temperature = temperature;
            HeatCapacity = heatCapacity;
            MaxTemperature = maxTemperature;
            MinTemperature = minTemperature;
        }

        public FoodProduct(FoodProduct foodProduct)
        {
            Name = foodProduct.Name;
            Weight = foodProduct.Weight;
            Temperature = foodProduct.Temperature;
            HeatCapacity = foodProduct.HeatCapacity;
            MaxTemperature = foodProduct.MaxTemperature;
            MinTemperature = foodProduct.MinTemperature;
        }

        public void Print()
        {
            int maxSymbolLenght = 25;
            bool isEvenNumber = (maxSymbolLenght - Name.Length) % 2 == 0;
            int symbolsPerSide = isEvenNumber ? (maxSymbolLenght - Name.Length) / 2 : (maxSymbolLenght - Name.Length) / 2 + 1;

            Console.WriteLine(new string('-', symbolsPerSide) + Name + new string('-', symbolsPerSide));
            Console.WriteLine($"Масса: {Weight:0.00} кг");
            Console.WriteLine($"Температура: {Temperature:0.00} °C");
            Console.WriteLine($"Статус: {Status}");

            if (isEvenNumber == false) Console.WriteLine(new string('-', maxSymbolLenght + 1) + "\n");
            else Console.WriteLine(new string('-', maxSymbolLenght) + "\n");
        }

        public void TransferThermalEnergy(double thermalEnergy)
        {
            if (thermalEnergy == 0) return;
            Temperature = thermalEnergy / HeatCapacity;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) throw new ArgumentException("NULL");
            if (obj is FoodProduct)
            {
                FoodProduct f = (FoodProduct)obj;
                return (int)(f.Temperature - this.Temperature);
            }
            return -1;
        }
    }
    public enum ProductStatus
    {
        NORMAL, OVERHEATED, FROSTBITTEN
    }
}
