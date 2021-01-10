using LordsMobileAPIv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        public static LordsMobileAPI.Adress adress = new LordsMobileAPI.Adress(true);
        static void Main(string[] args)
        {
            LordsMobileAPI.User user = new LordsMobileAPI.User(adress);
            LordsMobileAPI.Barrack barrack = new LordsMobileAPI.Barrack(adress);
            Console.WriteLine("====== User Info =======");
            Console.WriteLine("Gems: " + user.Gems);
            Console.WriteLine("Power: " + user.Power);
            Console.WriteLine("Stamina: " + user.Stamina);
            Console.WriteLine("Energy: " + user.Energy);
            Console.WriteLine("===== Barrack Info =====");
            Console.WriteLine("Total army: " + barrack.Army);
            Console.WriteLine("========================");
            Console.ReadLine();
        }
    }
}
