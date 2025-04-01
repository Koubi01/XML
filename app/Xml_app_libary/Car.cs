
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace Xml_app_libary
{
    
    public class Car
    {
        public string Brand { get; set; }
        public string Name { get; set; }
        [XmlIgnore]
        public DateTime DateOfSale { get; set; }        
        public double Price { get; set; }
        public double DPH { get; set; }

        [XmlElement("DateOfSale")]
        public string FormatedDateOfSale
        {
            get => DateOfSale.ToString("d.MM.yyyy", CultureInfo.GetCultureInfo("cs-CZ"));
            set => DateOfSale = DateTime.ParseExact(value, "d.M.yyyy",CultureInfo.GetCultureInfo("cs-CZ"));
        }

        public string FormatedName => $"{Brand} {Name}";
        public string FormatedPrice => Price.ToString("N0", new CultureInfo("de-DE")) + ",-";


        public Car() { }
        public Car(string brand, string name, DateTime date, Double price, double DPH)
        {
            Brand = brand;
            Name = name;
            DateOfSale = date;
            Price = price;
            this.DPH = DPH;
        }
        public bool IsWeekend()
        {
            if(DateOfSale.DayOfWeek == DayOfWeek.Sunday || DateOfSale.DayOfWeek == DayOfWeek.Saturday)
            {
                return true;
            }
            return false;
        }

        public static List<Car> LoadCars(string filePath)
        {
            var cars = new List<Car>();
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) 
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
                using (StreamReader sr = new StreamReader(fs)) 
                {
                    cars = (List<Car>)serializer.Deserialize(sr);
                }
            }
            return cars;
        }
    }

}
