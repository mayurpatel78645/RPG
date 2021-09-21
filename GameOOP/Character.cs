using System;
using System.Collections.Generic;
using System.Text;

namespace GameOOPTry2
{
    abstract class Character
    {
        public string Name;
        public int HP;
        public int CurrentHP;
        public int XP;

        public Character(string name, int HP, int XP)
        {
            this.Name = name;
            this.HP = HP;
            this.XP = XP;
            this.CurrentHP = HP;
        }

        public abstract int attack();
        public abstract int defend();
    }
}
