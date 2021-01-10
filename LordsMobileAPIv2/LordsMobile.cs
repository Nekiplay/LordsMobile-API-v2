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
        public class Asylum
        {
            public Adress Adress;
            public Asylum(Adress adress)
            {
                this.Adress = adress;
            }
            public int Army
            {
                get
                {
                    if (Adress.AsylumArmyCount != IntPtr.Zero)
                    {
                        System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                        var process = new ProcessSharp(game, MemoryType.Remote);
                        int stamina = process.Memory.Read<int>(Adress.AsylumArmyCount);

                        return stamina;
                    }
                    else { return -1; }
                }
            }
            public int Hands
            {
                get
                {
                    if (Adress.GuildHands != IntPtr.Zero)
                    {
                        System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                        var process = new ProcessSharp(game, MemoryType.Remote);
                        int stamina = process.Memory.Read<int>(Adress.GuildHands);

                        return stamina;
                    }
                    else { return -1; }
                }
            }
        }

        public class Guild
        {
            public Adress Adress;
            public Guild(Adress adress)
            {
                this.Adress = adress;
            }
            public int Power
            {
                get
                {
                    if (Adress.GuildPower != IntPtr.Zero)
                    {
                        System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                        var process = new ProcessSharp(game, MemoryType.Remote);
                        int stamina = process.Memory.Read<int>(Adress.GuildPower);

                        return stamina;
                    }
                    else { return -1; }
                }
            }
            public int Gifts
            {
                get
                {
                    if (Adress.GuildPresents != IntPtr.Zero)
                    {
                        System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                        var process = new ProcessSharp(game, MemoryType.Remote);
                        int stamina = process.Memory.Read<int>(Adress.GuildPresents);

                        return stamina;
                    }
                    else { return -1; }
                }
            }
            public int Hands
            {
                get
                {
                    if (Adress.GuildHands != IntPtr.Zero)
                    {
                        System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                        var process = new ProcessSharp(game, MemoryType.Remote);
                        int stamina = process.Memory.Read<int>(Adress.GuildHands);

                        return stamina;
                    }
                    else { return -1; }
                }
            }
        }
        public class Barrack
        {
            public Adress Adress;
            public Barrack(Adress adress)
            {
                this.Adress = adress;
            }
            public int Army
            {
                get
                {
                    if (Adress.BarrackArmy != IntPtr.Zero)
                    {
                        System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                        var process = new ProcessSharp(game, MemoryType.Remote);
                        int stamina = process.Memory.Read<int>(Adress.BarrackArmy);

                        return stamina;
                    }
                    else { return -1; }
                }
            }
        }
        public class User
        {
            public Adress Adress;
            public User(Adress adress)
            {
                this.Adress = adress;
            }
            public int Gems
            {
                get
                {
                    if (Adress.Gems != IntPtr.Zero)
                    {
                        System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                        var process = new ProcessSharp(game, MemoryType.Remote);
                        int stamina = process.Memory.Read<int>(Adress.Gems);

                        return stamina;
                    }
                    else { return -1; }
                }
            }
            public int Stamina
            {
                get
                {
                    if (Adress.Stamina != IntPtr.Zero)
                    {
                        System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                        var process = new ProcessSharp(game, MemoryType.Remote);
                        int stamina = process.Memory.Read<int>(Adress.Stamina);

                        return stamina;
                    } else { return -1; }
                }
            }
            public int Energy
            {
                get
                {
                    if (Adress.Energy != IntPtr.Zero)
                    {
                        System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                        var process = new ProcessSharp(game, MemoryType.Remote);
                        int stamina = process.Memory.Read<int>(Adress.Energy);

                        return stamina;
                    }
                    else { return -1; }
                }
            }
            public int Power
            {
                get
                {
                    if (Adress.Power != IntPtr.Zero)
                    {
                        System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                        var process = new ProcessSharp(game, MemoryType.Remote);
                        int power = process.Memory.Read<int>(Adress.Power);

                        return power;
                    }
                    else { return -1; }
                }
            }
        }
        public class Adress
        {
            public Adress(bool Debug = false, bool Fast = true)
            {
                if (!Fast)
                    Find(Debug);
                else 
                    Find2(Debug);

            }
            public void Find2(bool debug)
            {
                System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                if (game != null)
                {
                    Jupiter.MemoryModule m = new Jupiter.MemoryModule("Lords Mobile");
                    /* Stamina */
                    var x = m.PatternScan("C0 D6 ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 1D 00 38");
                    if (x.Count() == 1)
                    {
                        this.Stamina = x.First() + 0x18;
                        if (debug)
                            Console.WriteLine("Stamina Adress: " + Stamina.ToString("X"));
                    }
                    if (this.Stamina != IntPtr.Zero)
                    {
                        this.Gems = this.Stamina + 0x44;
                        if (debug)
                            Console.WriteLine("Gems Adress: " + Gems.ToString("X"));
                        this.Energy = this.Stamina + 0x150;
                        if (debug)
                            Console.WriteLine("Energy Adress: " + Energy.ToString("X"));
                        this.Power = this.Stamina + 0xB8;
                        if (debug)
                            Console.WriteLine("Power Adress: " + Power.ToString("X"));
                        this.BarrackArmy = this.Stamina + 0x908;
                        if (debug)
                            Console.WriteLine("Barrack army Adress: " + BarrackArmy.ToString("X"));
                        this.GuildHands = IntPtr.Subtract(this.Stamina, 0x153C8);
                        if (debug)
                            Console.WriteLine("Guild hands Adress: " + GuildHands.ToString("X"));
                        this.GuildPower = IntPtr.Add(this.Stamina, 0x200);
                        if (debug)
                            Console.WriteLine("Guild power Adress: " + GuildPower.ToString("X"));
                        this.GuildPresents = IntPtr.Add(this.Stamina, 0xBC28);
                        if (debug)
                            Console.WriteLine("Guild presents Adress: " + GuildPresents.ToString("X"));

                    }
                }
            }
            public void Find(bool debug)
            {
                System.Diagnostics.Process game = System.Diagnostics.Process.GetProcessesByName("Lords Mobile").FirstOrDefault();
                if (game != null)
                {
                    Jupiter.MemoryModule m = new Jupiter.MemoryModule("Lords Mobile");
                    /* Stamina */
                    var x = m.PatternScan("C0 D6 ?? ?? ?? 02 ?? 00 00 00 00 00 00 00 00 00 1D 00 38");
                    if (x.Count() == 1)
                    {
                        this.Stamina = x.First() + 0x18;
                        if (debug)
                            Console.WriteLine("Stamina Adress: " + Stamina.ToString("X"));
                    }
                    /* Energy */
                    //var x2 = m.PatternScan("?? ?? FA 5F 00 00 00 00 C6 06 00 00 00 00 00 00 00 00 00 00 02");
                    //if (x2.Count() == 1)
                    //{
                    //    this.Energy = x2.First() - 0x18;
                    //    if (debug)
                    //        Console.WriteLine("Energy Adress: " + Energy.ToString("X"));
                    //}
                    /* Power */
                    if (this.Stamina != IntPtr.Zero)
                    {
                        this.Energy = this.Stamina + 0x150;
                        Console.WriteLine("Energy Adress: " + Energy.ToString("X"));
                        this.Power = this.Stamina + 0xB8;
                        Console.WriteLine("Power Adress: " + Power.ToString("X"));
                    }
                    //var x3 = m.PatternScan("03 00 1E 00 10 00 00 0A 0F 00 0C 00 00 00 00 00 50 ?? FA 5F");
                    //if (x3.Count() == 1)
                    //{
                    //    this.Power = x3.First() - 0x18;
                    //    if (debug)
                    //        Console.WriteLine("Power Adress: " + Power.ToString("X"));
                    //}
                    /* Barrack Army */
                    var x4 = m.PatternScan("00 00 00 00 00 00 00 00 80 F1 9C 98 02 02 00 00 00 F1 9C 98 02 02");
                    if (x4.Count() == 1)
                    {
                        this.BarrackArmy = x4.First() - 0x18;
                        if (debug)
                            Console.WriteLine("Barrack army Adress: " + BarrackArmy.ToString("X"));
                    }
                }
            }
            public IntPtr Gems = IntPtr.Zero;
            public IntPtr Stamina = IntPtr.Zero;
            public IntPtr Energy = IntPtr.Zero;
            public IntPtr Power = IntPtr.Zero;
            public IntPtr BarrackArmy = IntPtr.Zero;
            public IntPtr GuildPower = IntPtr.Zero;
            public IntPtr GuildPresents = IntPtr.Zero;
            public IntPtr GuildHands = IntPtr.Zero;
            public IntPtr AsylumArmyCount = IntPtr.Zero;
        }
    }
}