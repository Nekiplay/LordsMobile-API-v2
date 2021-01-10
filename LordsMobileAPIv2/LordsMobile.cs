using System.Linq;
using System;
using Process.NET.Memory;
using Process.NET.Patterns;
using Process.NET;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LordsMobileAPIv2
{
    public class LordsMobileAPI
    {
        public class User
        {
            public Adress Adress;
            public User(Adress adress)
            {
                this.Adress = adress;
            }
            public int Stamina
            {
                get
                {
                    System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                    var process = new ProcessSharp(game, MemoryType.Remote);
                    int stamina = process.Memory.Read<int>(Adress.Stamina);

                    return stamina;
                }
            }
            public int Energy
            {
                get
                {
                    System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                    var process = new ProcessSharp(game, MemoryType.Remote);
                    int stamina = process.Memory.Read<int>(Adress.Energy);

                    return stamina;
                }
            }
            //public long IGG_ID
            //{
            //    get
            //    {
            //        System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
            //        var process = new ProcessSharp(game, MemoryType.Remote);
            //        long stamina = process.Memory.Read<long>(Adress.IGGID);
            //
            //        return stamina;
            //    }
            //}
        }
        public class Adress
        {
            public Adress(bool debug = false)
            {
                /* Stamina */
                System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                if (game != null)
                {
                    Jupiter.MemoryModule m = new Jupiter.MemoryModule("Lords Mobile");
                    var x = m.PatternScan("C0 D6 ?? ?? ?? 02 00 00 00 00 00 00 00 00 00 00 1D 00 38");
                    if (x.Count() == 1)
                    {
                        this.Stamina = x.First() + 0x18;
                        if (debug)
                            Console.WriteLine("Stamina Adress: " + Stamina.ToString("X"));
                    }
                    /* Energy */
                    var x2 = m.PatternScan("4E BE FA 5F 00 00 00 00 C6 06 00 00 00 00 00 00 00 00 00 00 02");
                    if (x2.Count() == 1)
                    {
                        this.Energy = x2.First() - 0x18;
                        if (debug)
                            Console.WriteLine("Energy Adress: " + Energy.ToString("X"));
                    }
                }
            }
            public IntPtr Stamina;
            public IntPtr Energy;
        }
    }
}