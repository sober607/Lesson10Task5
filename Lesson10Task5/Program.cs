using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace Lesson10Task5
{
    class Program
    {
        static void Main(string[] args)
        {


            List<string> billLines = System.IO.File.ReadLines("bill.txt", Encoding.ASCII).ToList();

            PrintUsBill();
            Console.WriteLine(new string('-', 10));
            PrintLocalBill();

            Console.ReadLine();

            void PrintUsBill()
            {
                DateTime myDate = DateTime.Parse(Convert.ToString(billLines[0]));


                string us = myDate.ToString("U", new CultureInfo("en-US"));

                RegionInfo usRegion = new RegionInfo("en-US");
                Console.WriteLine(us);
                int i = 1;
                decimal summ = 0;
                Console.WriteLine("Bill");
                do
                {
                    Console.WriteLine($"{billLines[i]} - {usRegion.CurrencySymbol}{billLines[i + 1]}");
                    summ = Convert.ToDecimal(billLines[i + 1]);
                    i += 2;

                }
                while (i < billLines.Count);
                Console.WriteLine($"Total amount: {usRegion.CurrencySymbol}{summ}");
            }

            void PrintLocalBill()
            {
                DateTime myDate = DateTime.Parse(Convert.ToString(billLines[0]));
                string local = myDate.ToString("U", CultureInfo.CurrentCulture);

                RegionInfo localRegion = RegionInfo.CurrentRegion;
                Console.WriteLine(local);
                int i = 1;
                decimal summ = 0;
                Console.WriteLine("Рахунок");
                do
                {
                    Console.WriteLine($"{billLines[i]} - {localRegion.CurrencySymbol}{billLines[i + 1]}");
                    summ = Convert.ToDecimal(billLines[i + 1]);
                    i += 2;

                }
                while (i < billLines.Count);
                Console.WriteLine($"Загальна сума: {localRegion.CurrencySymbol}{summ}");
            }
        }
    }
}
