using System;
using System.Collections.Generic;
using System.Text;

namespace GameOOPTry2
{
    class Game
    {
        public static Player player;

        public static bool IsRunning;

        public static int CurrentLocation = 0, act = 1;
        public static string[] Locations = new string[] { "Midguard", "Alfheim", "Hellheim", "Jotunheim"};
        public static string[] Encounters = new string[] { "Battle", "Battle", "Battle", "Rest", "Rest, Shop"};
        public static string[] Enemies = new string[] { "Undead", "Troll", "Ogre", "Goblin", "Nightmare", "Stone elemental", "Death Eater", "Dragon", "Revenant", "Wulver"};

        public static int ReadInput(string prompt, int userChoices)
        {
            int input;

            do
            {
                Console.WriteLine(prompt);
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch
                {
                    input = -1;
                    Console.WriteLine("Please enter an Integer!");
                }
            } while (input < 1 || input > userChoices);

            return input;
        }

        public static void PrintSeperator(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        public static void PrintHeading(string title)
        {
            PrintSeperator(30);
            Console.WriteLine(title);
            PrintSeperator(30);
        }

        public static void AnyKeyToContinue()
        {
            Console.WriteLine("\nEnter anything to continue...");
            Console.ReadKey();
        }

        public static void StartGame()
        {
            bool nameSet = false;
            string name;
            Console.Clear();
            PrintSeperator(40);
            PrintSeperator(30);
            Console.WriteLine("GOD OF WAR");
            Console.WriteLine("A TEXT RPG");
            PrintSeperator(30);
            PrintSeperator(40);
            AnyKeyToContinue();

            do
            {
                Console.Clear();
                PrintHeading("What's your name ?");
                name = Console.ReadLine();
                Console.Clear();
                PrintHeading($"Your name is {name}.\nIs that correct?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No, I want to change my name");
                int input = ReadInput("->", 2);
                if (input == 1)
                {
                    nameSet = true;
                }
            } while (!nameSet);

            Story.PrintIntro();
            player = new Player(name);
            Story.FirstActIntro();
            IsRunning = true;
            GameLoop();
        }

        public static void CheckAct()
        {
            if (player.XP >= 10 && act == 1)
            {
                act = 2;
                CurrentLocation = 1;
                Story.FirstActOutro();
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                player.ChooseTrait();
                Story.SecondActIntro();
                RandomEncounter();
                player.CurrentHP = player.HP;
            }
            else if (player.XP >= 20 && act == 2)
            {
                act = 3;
                CurrentLocation = 2;
                Story.SecondActOutro();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Yellow;
                player.ChooseTrait();
                Story.ThirdActIntro();
                RandomEncounter();
                player.CurrentHP = player.HP;
            }
            else if (player.XP >= 30 && act == 3)
            {
                act = 4;
                CurrentLocation = 3;
                Story.ThirdActOutro();
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                player.ChooseTrait();
                Story.FourthActIntro();

                FinalBattle();
            }
        }

        public static void RandomEncounter()
        {
            Random random = new Random();
            int encounter = random.Next(0, Encounters.Length);

            if (Encounters[encounter].Equals("Battle"))
            {
                RandomBattle();

            }else if (Encounters[encounter].Equals("Rest"))
            {
                TakeRest();
            }
            else
            {
                Shop();
            }
        }

        public static void ContinueJourney()
        {
            CheckAct();

            if (act != 4)
            {
                RandomEncounter();
            }
        }

        public static void CharacterInfo()
        {
            Console.Clear();
            PrintHeading("Character Info");
            Console.WriteLine($"{player.Name} \nHP: {player.CurrentHP} / {player.HP}");
            PrintSeperator(20);
            Console.WriteLine($"XP: {player.XP} \tGold: {player.Gold}");
            PrintSeperator(20);
            Console.WriteLine($"HealthStones: {player.HealthStones}");
            PrintSeperator(20);


            if (player.RunicAttackCount > 0)
            {
                Console.WriteLine($"Runes: {player.RunicAttacks[player.RunicAttackCount - 1]}");
            }

            if (player.ArmorPowerCount > 0)
            {
                Console.WriteLine($"Armor: {player.Armors[player.ArmorPowerCount - 1]}");
            }

            AnyKeyToContinue();
        }

        public static void Shop()
        {
            Console.Clear();
            PrintHeading("If it isn't the bearded beefer and his sac-seed! Have I got something for you two...:");
            int price = new Random().Next(1, (10 + player.HealthStones * 3) + 10 + player.HealthStones);
            Console.WriteLine($"- HealtStone: {price} gold");
            PrintSeperator(20);

            Console.WriteLine("Do you want to buy one?\n1. Yes\n2. No");
            int input = ReadInput("->", 2);

            if (input == 1)
            {
                Console.Clear();
                if (player.Gold >= price)
                {
                    PrintHeading($"You bought a healthstone for {price} gold");
                    player.HealthStones++;
                    player.Gold -= price;
                }
                else
                {
                    PrintHeading("You don't have enough gold to buy this...");
                    AnyKeyToContinue();
                }
            }
        }

        public static void TakeRest()
        {
            Console.Clear();
            if (player.RestsLeft >= 1)
            {
                PrintHeading($"Do you want to take rest? ({player.RestsLeft} rests left)");
                Console.WriteLine("1. Yes\n2. No, not now");
                int input = ReadInput("->", 2);

                if (input == 1)
                {
                    Console.Clear();

                    if (player.CurrentHP < player.HP)
                    {
                        int hpRestored = new Random().Next((player.XP / 4 + 1) + 10);
                        player.CurrentHP += hpRestored;

                        if (player.CurrentHP > player.HP)
                        {
                            player.CurrentHP = player.HP;
                        }
                        Console.WriteLine($"You took a rest and restored up to {hpRestored} health");
                        Console.WriteLine($"You're now at {player.CurrentHP} / {player.HP} health");
                        player.RestsLeft--;
                    }
                }
            }
            else
            {
                Console.WriteLine("You're at full health. You don't need to rest now");
            }
            AnyKeyToContinue();
        }

        public static void RandomBattle()
        {
            Console.Clear();
            PrintHeading("Boy...");
            AnyKeyToContinue();

            Battle(new Enemy(Enemies[new Random().Next(0, Enemies.Length)], player.XP));
        }

        public static void Battle(Enemy enemy)
        {
            while (true)
            {
                Console.Clear();
                PrintHeading($"{enemy.Name} \nHP: {enemy.CurrentHP} / {enemy.HP}");
                PrintHeading($"{player.Name} \nHP: {player.CurrentHP} / {player.HP}");
                Console.WriteLine("Choose an action:");
                PrintSeperator(20);
                Console.WriteLine("1. Fight\n2. Use Healthstone\n3. Run");
                int input = ReadInput("->", 3);

                if (input == 1)
                {
                    int dmg = player.attack() - enemy.defend();
                    int dmgTook = enemy.attack() - player.defend();

                    if (dmgTook < 0)
                    {
                        dmg -= dmgTook / 2;
                        dmgTook = 0;
                    }

                    if (dmg < 0)
                    {
                        dmg = 0;
                    }

                    player.CurrentHP -= dmg;
                    enemy.CurrentHP -= dmg;

                    Console.Clear();
                    PrintHeading("BATTLE");
                    Console.WriteLine($"You dealt {dmg} damage to the {enemy.Name}");
                    PrintSeperator(15);
                    Console.WriteLine($"The {enemy.Name} dealt {dmgTook} damage to you");
                    AnyKeyToContinue();

                    if (player.CurrentHP <= 0)
                    {
                        PlayerDied();
                        break;

                    }else if(enemy.CurrentHP <= 0)
                    {
                        Console.Clear();
                        PrintHeading($"You defeated the {enemy.Name}");
                        player.XP += enemy.XP;
                        Console.WriteLine($"you earned {enemy.XP} xp");
                        bool addRest = new Random().Next(7) <= 3;
                        int goldEarned = new Random().Next(enemy.XP);

                        if (addRest)
                        {
                            player.RestsLeft++;
                            Console.WriteLine("You earned a chance to get additional rest");
                        }
                        if (goldEarned > 0)
                        {
                            player.Gold += goldEarned;
                            Console.WriteLine($"You collect {goldEarned} gold from the {enemy.Name} corpse");
                        }
                        AnyKeyToContinue();
                        break;
                    }

                }else if (input == 2)
                {
                    Console.Clear();
                    if (player.HealthStones > 0 && player.CurrentHP < player.HP)
                    {
                        PrintHeading($"Do you want to use a healthstone? ({player.HealthStones} left)");
                        Console.WriteLine("1. Yes\n2. NO, maybe later");
                        input = ReadInput("->", 2);
                        if (input == 1)
                        {
                            player.CurrentHP = player.HP;
                            Console.Clear();
                            PrintHeading($"Healthstone restored your health back to {player.HP}");
                            AnyKeyToContinue();
                        }

                    }else
                    {
                        PrintHeading("You don't have any healthstone or you're at full health");
                        AnyKeyToContinue();
                    }
                }
                else
                {
                    Console.Clear();

                    if (act != 4)
                    {
                        if (new Random().Next(0, 11) <= 4)
                        {
                            PrintHeading($"You escaped the {enemy.Name}");
                            AnyKeyToContinue();
                            break;
                        }
                        else
                        {
                            PrintHeading("You can't escape");

                            int dmgTook = enemy.attack();
                            Console.WriteLine($"In your hurry you took {dmgTook} damage");
                            AnyKeyToContinue();

                            if (player.CurrentHP <= 0)
                            {
                                PlayerDied();
                            }
                        }
                    }
                    else
                    {
                        PrintHeading("YOU CANNOT ESCAPE Baldur!!!");
                        AnyKeyToContinue();
                    }
                }

            }
        }

        public static void PrintMenu()
        {
            Console.Clear();
            PrintHeading(Locations[CurrentLocation]);
            PrintHeading("Choose an action:");
            PrintSeperator(20);
            Console.WriteLine("1. Continue on your journey");
            Console.WriteLine("2. Character Info");
            Console.WriteLine("3. Exit Game");
        }

        public static void FinalBattle()
        {
            Battle(new Enemy("Baldur", 300));

            Story.PrintEnd(player);
            IsRunning = false;
        }

        public static void PlayerDied()
        {
            Console.Clear();
            PrintHeading("You died...");
            PrintHeading($"You earned respect and {player.XP} xp on your journey");
            Console.WriteLine("hope you enjoyed the game");
            IsRunning = false;
        }

        public static void GameLoop()
        {
            while (IsRunning)
            {
                PrintMenu();
                int input = ReadInput("->", 3);
                if (input == 1)
                {
                    ContinueJourney();
                }else if(input == 2)
                {
                    CharacterInfo();
                }
                else
                {
                    IsRunning = false;
                }
            }
        }
    }
}
