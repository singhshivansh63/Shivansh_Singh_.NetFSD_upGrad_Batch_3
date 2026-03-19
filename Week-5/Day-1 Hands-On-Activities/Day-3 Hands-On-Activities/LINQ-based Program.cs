using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Product
    {
        public int ProCode { get; set; }
        public string ProName { get; set; }
        public string ProCategory { get; set; }
        public double ProMrp { get; set; }

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ProCode=1001,ProName="Colgate-100gm",ProCategory="FMCG",ProMrp=55 },
                new Product{ProCode=1002,ProName="Colgate-50gm",ProCategory="FMCG",ProMrp=30 },
                new Product{ProCode=1009,ProName="DaburRed-100gm",ProCategory="FMCG",ProMrp=50 },
                new Product{ProCode=1006,ProName="DaburRed-50gm",ProCategory="FMCG",ProMrp=28 },
                new Product{ProCode=1008,ProName="Himalaya Neem Face Wash",ProCategory="FMCG",ProMrp=70 },
                new Product{ProCode=1007,ProName="Niviea Face Wash",ProCategory="FMCG",ProMrp=120 },
                new Product{ProCode=1010,ProName="Daawat-Basmati",ProCategory="Grain",ProMrp=130 },
                new Product{ProCode=1011,ProName="Delhi Gate-Basmati",ProCategory="Grain",ProMrp=120 },
                new Product{ProCode=1014,ProName="Saffola-Oil",ProCategory="Edible-Oil",ProMrp=160 },
                new Product{ProCode=1016,ProName="Fortune-Oil",ProCategory="Edible-Oil",ProMrp=150 },
                new Product{ProCode=1018,ProName="Nescafe",ProCategory="FMCG",ProMrp=70 },
                new Product{ProCode=1019,ProName="Bru",ProCategory="FMCG",ProMrp=90},
                new Product{ProCode=1015,ProName="Parachut",ProCategory="Edible-Oil",ProMrp=60}
            };
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Product productObj = new Product();
            List<Product> products = productObj.GetProducts();

           
            Console.WriteLine(" Problem 1 ");
            var result1 = from p in products
                          where p.ProCategory == "FMCG"
                          select p;
            foreach (var p in result1)
                Console.WriteLine($"  {p.ProCode}  {p.ProName}  {p.ProCategory}  {p.ProMrp}");

           
            Console.WriteLine("\n Problem 2 ");
            var result2 = from p in products
                          where p.ProCategory == "Grain"
                          select p;
            foreach (var p in result2)
                Console.WriteLine($"  {p.ProCode}  {p.ProName}  {p.ProCategory}  {p.ProMrp}");

            
            Console.WriteLine("\n Problem 3 ");
            var result3 = from p in products
                          orderby p.ProCode ascending
                          select p;
            foreach (var p in result3)
                Console.WriteLine($"  {p.ProCode}  {p.ProName}  {p.ProCategory}  {p.ProMrp}");

            
            Console.WriteLine("\n Problem 4 ");
            var result4 = from p in products
                          orderby p.ProCategory ascending
                          select p;
            foreach (var p in result4)
                Console.WriteLine($"  {p.ProCode}  {p.ProName}  {p.ProCategory}  {p.ProMrp}");

            
            Console.WriteLine("\n  Problem 5 ");
            var result5 = from p in products
                          orderby p.ProMrp ascending
                          select p;
            foreach (var p in result5)
                Console.WriteLine($"  {p.ProCode}  {p.ProName}  {p.ProCategory}  {p.ProMrp}");

           
            Console.WriteLine("\n Problem 6 ");
            var result6 = from p in products
                          orderby p.ProMrp descending
                          select p;
            foreach (var p in result6)
                Console.WriteLine($"  {p.ProCode}  {p.ProName}  {p.ProCategory}  {p.ProMrp}");

            
            Console.WriteLine("\n Problem 7 ");
            var result7 = from p in products
                          group p by p.ProCategory;
            foreach (var group in result7)
            {
                Console.WriteLine($"\n  Category: {group.Key}");
                foreach (var p in group)
                    Console.WriteLine($"    {p.ProCode}  {p.ProName}  {p.ProMrp}");
            }

            
            Console.WriteLine("\n  Problem 8 ");
            var result8 = from p in products
                          group p by p.ProMrp;
            foreach (var group in result8)
            {
                Console.WriteLine($"\n  MRP: {group.Key}");
                foreach (var p in group)
                    Console.WriteLine($"    {p.ProCode}  {p.ProName}  {p.ProCategory}");
            }

             
            Console.WriteLine("\n Problem 9 ");
            double maxFmcgMrp = (from p in products
                                 where p.ProCategory == "FMCG"
                                 select p.ProMrp).Max();
            var result9 = from p in products
                          where p.ProCategory == "FMCG" && p.ProMrp == maxFmcgMrp
                          select p;
            foreach (var p in result9)
                Console.WriteLine($"  {p.ProCode}  {p.ProName}  {p.ProCategory}  {p.ProMrp}");

            
            Console.WriteLine("\n  Problem 10 ");
            int result10 = (from p in products select p).Count();
            Console.WriteLine($"  Total Products: {result10}");

             
            Console.WriteLine("\n  Problem 11 ");
            int result11 = (from p in products
                            where p.ProCategory == "FMCG"
                            select p).Count();
            Console.WriteLine($"  Total FMCG Products: {result11}");

            
            Console.WriteLine("\n  Problem 12 ");
            double result12 = (from p in products select p.ProMrp).Max();
            Console.WriteLine($"  Max MRP: {result12}");

             
            Console.WriteLine("\n  Problem 13 ");
            double result13 = (from p in products select p.ProMrp).Min();
            Console.WriteLine($"  Min MRP: {result13}");

             
            Console.WriteLine("\n  Problem 14 ");
            bool result14 = products.All(p => p.ProMrp < 30);
            Console.WriteLine($"  All products below Rs.30: {result14}");
 
            Console.WriteLine("\n  Problem 15 ");
            bool result15 = products.Any(p => p.ProMrp < 30);
            Console.WriteLine($"  Any product below Rs.30: {result15}");

            Console.ReadKey();
        }
    }
}