using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace xml_builder
{
    public class Car
    {
        public string Brand {  get; set; } 
        public string Name { get; set; }
        [XmlIgnore]
        public DateTime DateOfSale { get; set; }
        [XmlElement("DateOfSale")]
        public string FormatedDateOfSale 
        {
            get => DateOfSale.ToString("d.MM.yyyy", CultureInfo.GetCultureInfo("cs-CZ"));
            set => DateOfSale = DateTime.Parse("d.MM.yyyy", CultureInfo.GetCultureInfo("cs-CZ"));
        } 
        public double Price { get; set; }
        public double DPH   { get; set; }

        public Car() { }
        public Car(string brand,string name,  DateTime date, Double price, double DPH) 
        {
            Brand = brand;
            Name = name;
            DateOfSale = date;
            Price = price;
            this.DPH = DPH;
        }
    }
}
