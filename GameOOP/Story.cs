using System;
using System.Collections.Generic;
using System.Text;

namespace GameOOPTry2
{
    class Story
    {
        public static void PrintIntro()
        {
            Console.Clear();
            Game.PrintSeperator(30);
            Console.WriteLine("STORY - Faye's Final Wish");
            Game.PrintSeperator(30);
            Console.WriteLine("Many years after Kratos' defeat of the Olympian gods,he now lives with his son Atreus in ancient Scandinavia in the realm of Midgard.\nAfter cremating the body of his wife, Faye, and after a short hunting/survival lesson with Atreus,\nKratos is confronted by a mysterious man with godlike powers.\nThe two battle and Kratos seemingly kills his opponent, after which Kratos and Atreus\nbegin their journey to honor Faye's last wish:\nto scatter her ashes at the highest peak in the nine realms.");
            Game.AnyKeyToContinue();
        }

        public static void FirstActIntro()
        {
            Console.Clear();
            Game.PrintSeperator(30);
            Console.WriteLine("THE LIGHT OF ALFHEIM");
            Game.PrintSeperator(30);
            Console.WriteLine("Kratos and Atreus head back to the Lake of the Nine, where\nTyr’s Tower is. From here, Freya teaches them how to use the\ntower to travel to other realms with a tool called the\nBifrost. Once in Alfheim, Kratos and Atreus start exploring\nthe realm to look for the Light, while getting tangled up\nin a conflict between the Light and Dark Elves.");
            Game.AnyKeyToContinue();
        }

        public static void FirstActOutro()
        {
            Console.Clear();
            Game.PrintSeperator(30);
            Console.WriteLine("THE LIGHT OF ALFHEIM");
            Game.PrintSeperator(30);
            Console.WriteLine("After the event Atreus falls sick and  Freya tells Kratos\nthat he needs to obtain the heart of a gatekeeper from\nHelheim, but his frost axe won’t be effective against the\nenemies there. Kratos then goes home to 'dig up his past.'");
            Game.AnyKeyToContinue();
        }

        public static void SecondActIntro()
        {
            Console.Clear();
            Game.PrintSeperator(30);
            Console.WriteLine("JOURNEY TO HELHEIM");
            Game.PrintSeperator(30);
            Console.WriteLine("Kratos takes Freya’s boat back home, and on the way there,\nhe is haunted by visions of Athena from his past. She\nreminds Kratos of who he really is, and how he can never\nescape his origins and role as the God of War. Kratos seems\nto understand this, but he ignores her as he digs up his\nBlades of Chaos from the floorboards at home.\nNow, he’s finally ready to go to Helheim.");
            Game.AnyKeyToContinue();
        }

        public static void SecondActOutro()
        {
            Console.Clear();
            Game.PrintSeperator(30);
            Console.WriteLine("JOURNEY TO HELHEIM");
            Game.PrintSeperator(30);
            Console.WriteLine("At the summit, they’re attacked by Baldur once again.\nIn the process, Kratos accidentally destroys the pathway to\nJotunheim, and Atreus blames him for it. All three of them\nare then sucked back into Helheim.");
            Game.AnyKeyToContinue();
        }

        public static void ThirdActIntro()
        {
            Console.Clear();
            Game.PrintSeperator(30);
            Console.WriteLine("FINDING ANOTHER WAY TO JOTUNHEIM");
            Game.PrintSeperator(30);
            Console.WriteLine("While in between realms, they discover a new travel tower\nwhich can take them directly to Jotunheim. However, there’s\nanother snag in the plan. They can’t go there quite yet as\nthey need a travel crystal, similar to Mimir’s one eye.\nThey talk to the World Serpent again, who tells them that he\nswallowed a statue which might contain a hidden compartment\ncontaining Mimir’s missing eye. Kratos, Atreus, and Mimir\nthen sail a boat into the Serpent’s mouth to find the eye.");
            Game.AnyKeyToContinue();
        }

        public static void ThirdActOutro()
        {
            Console.Clear();
            Game.PrintSeperator(30);
            Console.WriteLine("FINDING ANOTHER WAY TO JOTUNHEIM");
            Game.PrintSeperator(30);
            Console.WriteLine("They manage to find the eye, but on their way out, they find\nthat the Serpent is under attack. When they finally get\nout, we see that Baldur had attacked the serpent to flush\nthem out. Freya also shows up to try to stop them from fighting.");
            Game.AnyKeyToContinue();
        }

        public static void FourthActIntro()
        {
            Console.Clear();
            Game.PrintSeperator(30);
            Console.WriteLine("SCATTERING THE ASHES");
            Game.PrintSeperator(30);
            Console.WriteLine("When they finally reach Jotunheim, Kratos spots a\nmural on the wall which contains drawings of all the\nadventures he and Atreus had had up to this point.\nWe learn that Faye herself was actually a Giant, and\nit’s implied that she and the Giants knew that Kratos\nand Atreus would embark on this adventure together,\nand eventually come to Jotunheim to learn about her\ntrue identity. This makes Atreus half-god and\nhalf-Giant.");
            Game.AnyKeyToContinue();
        }

        public static void FourthActOutro()
        {
            Console.Clear();
            Game.PrintSeperator(30);
            Console.WriteLine("SCATTERING THE ASHES");
            Game.PrintSeperator(30);
            Console.WriteLine("After they finally scatter Faye’s ashes to the winds, Kratos\nalso tells Atreus that she had originally wanted to\nname him Loki.");
            Game.AnyKeyToContinue();
        }

        public static void PrintEnd(Player player)
        {
            Console.Clear();
            Game.PrintSeperator(30);
            Console.WriteLine("There’s lightning and thunder everywhere, and a hooded\nstranger is shown standing outside their house. We see\na metal hammer on his belt, implying that this is\nThor, who’s presumably here to settle the score with\nKratos for killing his sons and brother. ");
            Game.PrintSeperator(30);
            Console.WriteLine($"Thank you {player.Name}! Hope you had fun");
        }
    }
}
