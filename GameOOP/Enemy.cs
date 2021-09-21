using System;
using System.Collections.Generic;
using System.Text;

namespace GameOOPTry2
{
    class Enemy : Character
    {
        int PlayerXp;
        public static Random random = new Random();
        public Enemy(string name, int PlayerXp) : base(name, random.Next(PlayerXp + PlayerXp/3+5), random.Next((PlayerXp/4 + 2) + 1))
        {
            this.PlayerXp = PlayerXp;
        }

        public override int attack()
        {
            return random.Next((PlayerXp/4 + 1) + XP/4 + 3);
        }

        public override int defend()
        {
            return random.Next((PlayerXp/4 + 1) + XP/4);
        }
    }
}
