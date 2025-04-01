using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xml_app_libary
{
    public class CarData
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double PriceDPH { get; set; }

        public string FormatedPrice => Price.ToString( new CultureInfo("de-DE"));
        public string FormatedPriceDPH => PriceDPH.ToString(new CultureInfo("de-DE"));

        public static List<CarData> AllCarData(List<Car> cars)
        {
            List<CarData> carDatas = new List<CarData>();
            foreach (Car car in cars)
            {
                if (car.IsWeekend())
                {
                    var existingCar = carDatas.FirstOrDefault(x => x.Name == car.FormatedName);

                    if (existingCar != null)
                    {
                        existingCar.Price += car.Price;
                        existingCar.PriceDPH += (car.Price * (1 + Math.Max(car.DPH, 0) / 100));
                    }
                    else
                    {
                        carDatas.Add(new CarData { Name = car.FormatedName, Price = car.Price, PriceDPH = (car.Price * (1 + Math.Max(car.DPH, 0) / 100)) });
                    }
                }

            }
            return carDatas;
        }
    }
}
