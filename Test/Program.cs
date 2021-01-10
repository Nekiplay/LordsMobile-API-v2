using LordsMobileAPIv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        public static LordsMobileAPI.Adress adress = new LordsMobileAPI.Adress(false);
        static void Main(string[] args)
        {
            LordsMobileAPI.User lords = new LordsMobileAPI.User(adress);
            Console.WriteLine("Стамина: " + lords.Stamina);
            Console.WriteLine("Энергия: " + lords.Energy);
            Console.ReadLine();
        }
    }
}
