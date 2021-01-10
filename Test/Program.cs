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
        public static LordsMobileAPI.Adress adress = new LordsMobileAPI.Adress(Debug: true, Fast: true); // Find adress
        static void Main(string[] args)
        {
            LordsMobileAPI.User user = new LordsMobileAPI.User(adress: adress); // User information
            LordsMobileAPI.Barrack barrack = new LordsMobileAPI.Barrack(adress: adress); // Barrack information
            LordsMobileAPI.Asylum asylum = new LordsMobileAPI.Asylum(adress: adress); // Barrack information
            LordsMobileAPI.Guild guild = new LordsMobileAPI.Guild(adress: adress); // Guild information
            Console.WriteLine("====== User Info =======");
            Console.WriteLine("Gems: " + user.Gems);
            Console.WriteLine("Power: " + user.Power);
            Console.WriteLine("Stamina: " + user.Stamina);
            Console.WriteLine("Energy: " + user.Energy);
            Console.WriteLine("===== Guild Info =====");
            Console.WriteLine("Power: " + guild.Power);
            Console.WriteLine("Gifts: " + guild.Gifts);
            Console.WriteLine("Handles not pressed: " + guild.Hands);
            Console.WriteLine("===== Barrack Info =====");
            Console.WriteLine("Total army: " + barrack.Army);
            Console.WriteLine("===== Asylum Info =====");
            Console.WriteLine("Army: " + asylum.Army);
            Console.WriteLine("========================");
            Console.ReadLine();
        }
    }
}
