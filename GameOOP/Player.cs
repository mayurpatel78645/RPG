using System;
using System.Collections.Generic;
using System.Text;

namespace GameOOPTry2
{
    class Player : Character
    {
        public int RunicAttackCount;
        public int ArmorPowerCount;
        public int Gold, RestsLeft, HealthStones;
        public static Random rnd = new Random();
        public string[] RunicAttacks = new string[] { "Njrod's Tempest", "Meteoric Slam", "Breath of Thamur", "Rage" };
        public string[] Armors = new string[] { "Valkyrie Set", "Ivaldi's Endless Mist", "Armor of Ares", "Armor of Zeus"};
        public Player(string name) : base(name, 100, 0)
        {
            this.RunicAttackCount = 0;
            this.ArmorPowerCount = 0;
            this.Gold = 5;
            this.RestsLeft = 1;
            this.HealthStones = 0;
            ChooseTrait();
        }

        public override int attack()
        {
            return rnd.Next(0, (XP/4 + RunicAttackCount * 3 + 3) + XP/ 10 + RunicAttackCount * 2 + ArmorPowerCount + 1);
        }

        public override int defend()
        {
            return rnd.Next(0, (XP/4 + ArmorPowerCount * 3 +3) + XP/10 + ArmorPowerCount * 2 + RunicAttackCount + 1 );
        }

        public void ChooseTrait()
        {
            Console.Clear();
            Game.PrintHeading("Choose a trait:");
            Console.WriteLine($"1. {RunicAttacks[RunicAttackCount]}");
            Console.WriteLine($"2. {Armors[ArmorPowerCount]}");

            int input = Game.ReadInput("->", 2);
            Console.Clear();

            if (input == 1)
            {
                Game.PrintHeading($"You chose {RunicAttacks[RunicAttackCount]}");
                RunicAttackCount++;
            }
            else
            {
                Game.PrintHeading($"You chose {Armors[ArmorPowerCount]}");
                ArmorPowerCount++;
            }
            Game.AnyKeyToContinue();
        }
    }
}
