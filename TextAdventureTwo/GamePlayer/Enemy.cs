using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureTwo.GamePlayer
{
    public class Enemy : Npc
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Defense { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }



        public Enemy(string name, Dictionary<string, string[]> dialog, int health, int defense, int minDamage, int maxDamage) : base(name, dialog)
        {
            MaxHealth = health;
            CurrentHealth = MaxHealth;
            Defense = defense;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }
    }
}
