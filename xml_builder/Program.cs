using System.Globalization;
using System.Xml.Serialization;

namespace xml_builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            using (FileStream fs = new FileStream("cars.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splits = line.Split(";");
                        if (splits.Length >= 4)
                        {
                            Car newCar = new Car(splits[0], splits[1], DateTime.Parse(splits[2], CultureInfo.GetCultureInfo("cs-CZ")), double.Parse(splits[3], CultureInfo.GetCultureInfo("de-DE")), double.Parse(splits[4]));
                            cars.Add(newCar);
                        }
                    }
                }
                foreach (Car car in cars)
                {
                    Console.WriteLine(car.Name + " | " + car.Price + " | " + car.DateOfSale.ToString("d.MM.yyyy"));
                }
            }

            using (FileStream fs = new FileStream("cars.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite)) 
            {
                
                XmlSerializer sr = new XmlSerializer(typeof(List<Car>));
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sr.Serialize(sw, cars);
                }                
            }
            
        }
    }
}
