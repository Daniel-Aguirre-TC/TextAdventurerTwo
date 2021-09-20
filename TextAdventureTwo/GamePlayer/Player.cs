using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureTwo.GamePlayer
{
    public class Player
    {

        enum Classes { Amazon, Barbarian, Sorceress }
        
        public string Name { get; set; }
        Classes PlayerClass { get; set; }
        public string Class { get => PlayerClass.ToString(); }
        // reflects either " Current Location: 'xyz' " OR " Talking To: 'xyz' " OR " Battling: 'xyz' " 
        public string Current { get; set; }

        #region Level
        public int Level { get; set; }
        public int Experience { get; set; }
        #endregion

        #region Stats
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Vitality { get; set; }
        public int Energy { get; set; }

        // attack related
        public int ChanceToHit { get; set; }
        public bool IsDefending { get; set; }

        #endregion
        #region Resistances
        public int FireResist { get; set; }
        public int ColdResist { get; set; }
        public int LightResist { get; set; }
        public int PoisonResist { get; set; }
        #endregion


        public Player()
        {
            Current = "Current Location/Action Not Yet Set";
            // set resistances
            FireResist = 0;
            ColdResist = 0;
            LightResist = 0;
            PoisonResist = 0;
            ChanceToHit = 80;
            IsDefending = false;
            // ask player to select class then assign
            SetClass();
            // ask play for their name
            Name = Prompter.GetPlayerName();
        }



        void SetClass()
        {
            var selection = Prompter.SelectClassScreen();
            switch (selection)
            {
                case 0:
                    PlayerClass = Classes.Amazon;
                    SetMaxHealth(50);
                    SetMaxMana(15);
                    SetStats(20, 25, 20, 15);
                    break;
                case 1:
                    PlayerClass = Classes.Barbarian;
                    SetMaxHealth(55);
                    SetMaxMana(10);
                    SetStats(30, 20, 25, 10);

                    break;
                case 2:
                    PlayerClass = Classes.Sorceress;
                    SetMaxHealth(40);
                    SetMaxMana(35);
                    SetStats(10, 25, 10, 35);
                    break;
            }
        }

        /// <summary>
        /// Change the players stats to the passed in params.
        /// </summary>
        /// <param name="strength"></param>
        /// <param name="dexterity"></param>
        /// <param name="vitality"></param>
        /// <param name="energy"></param>
        void SetStats(int strength, int dexterity, int vitality, int energy)
        {
            Strength = strength;
            Dexterity = dexterity;
            Vitality = vitality;
            Energy = energy;
        }

        /// <summary>
        /// Set the max health and update current health to match it.
        /// </summary>
        /// <param name="newValue"></param>
        void SetMaxHealth(int newValue)
        {
            MaxHealth = newValue;
            CurrentHealth = newValue;
        }

        /// <summary>
        /// Set the max mana and update current mana to match it.
        /// </summary>
        /// <param name="newValue"></param>
        void SetMaxMana(int newValue)
        {
            MaxMana = newValue;
            CurrentMana = newValue;
        }

    }
}
