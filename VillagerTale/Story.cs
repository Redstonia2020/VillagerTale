using System;
using System.Collections.Generic;
using System.Text;

namespace VillagerTale
{
    public class Story
    {
        public class Intro
        {
            public static void Narrative()
            {
                Console.Clear();
                Display.Crawl("The gentle breeze blows softly upon you.");
                Display.Crawl("The sun shines from above, its radiant warmth upon your skin.");
                Display.Crawl("The grass waves in the wind, the dew upon their blades gleaming in the daylight.");
                Display.Crawl("All sorts of wild animal roam the fields, grazing peacefully on the lush grass.");
                Display.Crawl("A lone sheep wanders up to you, its white wool bright in the sunshine.");
                Display.Crawl("It looks up at you curiously, you take no heed of it.");
                Display.Crawl("Then, out of nowhere, a voice comes forth.");
                Display.Crawl("Looking around confusedly, your gaze ends up on the sheep before you.");
                Display.Crawl("Its mouth doesn't seem to move, yet somehow it manages to communicate its thought with you.");
                States.Queue(State.IntroSheepDialogue);
            }

            public static void SheepDialogue()
            {
                Console.Clear();
                Display.Speak("Sheep", "Hello there!");
                int choice = Display.Choose("What do you do? (type your choice or use the number on the side)",
                    "Greet it back",
                    "Ask it how it can speak",
                    "Back away",
                    "Pet it");

                if (choice == 0)
                    States.Queue(State.IntroSheepGreet);
                else if (choice == 1)
                    States.Queue(State.IntroSheepQuestion);
                else if (choice == 2)
                    States.Queue(State.IntroSheepRetreat);
                else if (choice == 3)
                    States.Queue(State.IntroSheepPet);
            }

            public static void SheepGreet()
            {
                Display.Crawl("You greet the sheep in return.");
                Display.Speak("Sheep", "You must be new.");
                Display.Speak("Sheep", "Follow me!");
            }

            public static void SheepQuestion()
            {
                Display.Crawl("You ask the sheep how it can speak to you like this.");
                Display.Speak("Sheep", "Oh, well...");
                Display.Speak("Sheep", "I can tell you that in time.");
                Display.Speak("Sheep", "This discussion would be better had in a nice place");
                Display.Speak("Sheep", "Oh, I have an idea!");
                Display.Speak("Sheep", "Let's go to my house, and we can discuss it there!");
                int choice = Display.Choose("",
                    "\"I'd be happy to!\"",
                    "\"I have other things to do\"");

                if (choice == 0)
                {
                    Display.Speak("Sheep", "Wonderful!");
                    Display.Speak("Sheep", "Well, what are we waiting for? Let's go!");
                    //queue
                }

                else if (choice == 1)
                {
                    Display.Speak("Sheep", "Oh, that's too bad.");
                    Display.Speak("Sheep", "Well, if you ever need me, you can find me around here.");
                    Display.Speak("Sheep", "See you then!");
                }
            }

            public static void SheepRetreat()
            {
                Display.Crawl("You slowly back away from the sheep.");
                Display.Speak("Sheep", "W-why are you backing away?");
            }

            public static void SheepPet()
            {

            }
        }
    }
}
