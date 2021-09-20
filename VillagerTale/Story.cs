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
                    States.Queue(State.IntroSheepUnease);
                else if (choice == 3)
                    States.Queue(State.IntroSheepPet);
            }

            public static void SheepGreet()
            {
                Game.Data.IntroSheepCharacter.Reputation += 5;
                Display.Crawl("You greet the sheep in return.");
                Display.Speak("Sheep", "You must be new.");
                Display.Speak("Sheep", "Follow me!");

                int choice = Display.Choose("The sheep starts walking away. What do you do?", true,
                    "Follow it",
                    "Walk away");

                if (choice == 0)
                {
                    States.Queue(State.SheepHome);
                }

                else if (choice == 1)
                {
                    Display.Crawl("You leave the sheep walking into the distance, not once does it look back.");
                    Display.Crawl("You secretly giggle at the thought that it still thinks you're following it.");
                    States.Queue(State.SpawnField);
                }
            }

            public static void SheepQuestion()
            {
                Display.Crawl("You ask the sheep how it can speak to you like this.");
                Display.Speak("Sheep", "Oh, well...");
                Display.Speak("Sheep", "I can tell you that in time.");
                Display.Speak("Sheep", "This discussion would be better had in a nice place.");
                Display.Speak("Sheep", "Oh, I have an idea!");
                Display.Speak("Sheep", "Let's go to my house, and we can discuss it there!");
                int choice = Display.Choose("",
                    "\"I'd be happy to!\"",
                    "\"I have other things to do\"");

                if (choice == 0)
                {
                    Display.Speak("Sheep", "Wonderful!");
                    Display.Speak("Sheep", "Well, what are we waiting for? Let's go!");
                    States.Queue(State.SheepHome);
                }

                else if (choice == 1)
                {
                    Display.Speak("Sheep", "Oh, that's too bad.");
                    Display.Speak("Sheep", "Well, if you ever need me, you can find me around here.");
                    Display.Speak("Sheep", "See you then!");
                    States.Queue(State.SpawnField);
                }
            }

            public static void SheepUnease()
            {
                Game.Data.IntroSheepCharacter.Reputation -= 5;
                Display.Crawl("You slowly back away from the sheep.");
                Display.Speak("Sheep", "W-why are you backing away?");
                int choice = Display.Choose("", "\"I was just startled.\"", "Run away");
                if (choice == 0)
                {
                    Display.Crawl("He nods in understanding.");
                    Display.Speak("Sheep", "Yeah, I guess it's not every day you come face to face with a telepathic sheep.");
                    Display.Speak("Sheep", "So... what now?");
                    Display.Crawl("Somewhere within the animal's wool, a ringing noise comes forth.");
                    Display.Crawl("The sheep stops talking.");
                    Display.Speak("Sheep", "Guess I'd better go!");
                    Display.Speak("Sheep", "See you around!");
                    Display.Crawl("The sheep turns and bounces quickly to a homely house in the distance.");
                    States.Queue(State.SpawnField);
                }

                else if (choice == 1)
                {
                    Display.Crawl("The animal watches as you run off into the distance in confusion.");
                    States.Queue(State.SpawnField);
                }
            }

            public static void SheepPet()
            {
                Game.Data.IntroSheepCharacter.Reputation -= 25;
                Display.Text("The sheep jerks away quickly.");
                Display.Speak("Sheep", "What do you think you're doing?");
                int choice = Display.Choose("Try not to pet an otherworldly creature next time.",
                    "\"Petting you?\"",
                    "\"umm...\"",
                    "\"I can do whatever I want!\"",
                    "Stay silent");
                
                if (choice == 0)
                {
                    Display.Speak("Sheep", "How dare you!");
                    Display.Crawl(false, "*ahem*");
                    Display.Wait(500);
                    Display.Crawl(false, "The sheep trembles slightly.");
                    Display.Speak("Sheep", "Just know... I do not take lightly to being treated like an animal.");
                }

                else if (choice == 1 || choice == 3)
                {
                    Display.Speak("Sheep", "ANSWER ME!!!");
                    Display.Crawl(false, "The sheep trembles, eyes blazing in rage.");
                    Display.Crawl(false, "He composes himself.");
                    Display.Speak("Sheep", "I'm sorry you had to see me like that.");
                    Display.Speak("Sheep", "Maybe I should've told you earlier, I do not enjoy being treated like an animal.");
                }

                else if (choice == 2)
                {
                    States.Queue(State.IntroSheepSelfish);
                    return;
                }

                Display.Speak("Sheep", "Do we understand each other?");
                Display.Crawl("You nod solemnly.",
                    "The sheep's voice softens.");
                Display.Speak("Sheep", "Good.");
            }

            public static void SheepSelfish()
            {
                Game.Data.IntroSheepCharacter.Reputation -= 100;
                Display.Crawl(false, "The sheep stares at you, clear dismay upon his face.");
                Display.Speak("Sheep", "How... how can I speak to such a selfish...");
                Display.Speak("Sheep", "...such a selfish person?");

                int choice = Display.Choose("", "\"I'm sorry...\"", "\"I didn't mean that.\"", "\"Why should I care about what you think?\"");
                if (choice == 0)
                {
                    Game.Data.IntroSheepCharacter.Reputation += 25;
                    Display.Speak("Sheep", "\"I'm sorry\" doesn't cut it.");
                }

                else if (choice == 1)
                {
                    Game.Data.IntroSheepCharacter.Reputation += 25;
                    Display.Crawl("The sheep's voice rises to a shout.");
                    Display.Speak("Sheep", "What do you mean, \"I don't mean that?!?\"");
                    Display.Speak("Sheep", "Your few words are like manipulative poison, weaving between sorrow and ignorance!");
                }

                else if (choice == 2)
                {
                    Game.Data.IntroSheepCharacter.Reputation -= 100;
                    Display.Text("This is not going to look good on your resume-");
                    Display.Speak("Sheep", "Why you-");
                    Display.Speak("Sheep", "What don't you understand here?");
                    Display.Crawl(false, "You can feel the sheep's voice steadily rising to a shout.");
                    Display.Speak("Sheep", "Look. You've gotta realize, one day or another...");
                    Display.Speak("Sheep", "You're not the only one in this world who has thoughts... who has feelings.");
                    Display.Speak("Sheep", "and if you're going to go around making the rest of our lives hell...");
                    Display.Crawl(
                        "The sheep stares, seething at you.",
                        "Finally, deciding you are not worth the effort, he turns around and storms off through the grassy field to a shape in the distance.",
                        "You are left staring at where he was.");
                    States.Queue(State.SpawnField);
                    return;
                }

                Display.Crawl("The sheep's voice lowers slightly.");
                Display.Speak("Sheep", "Look, you need to be more careful what you say.");
                Display.Speak("Sheep", "Saying things that are ignorant...");
                Display.Speak("Sheep", "Those don't help your situation in any way.");
            }
        }

        public class SpawnField
        {
            public static void Area()
            {
                States.Queue(State.SpawnField);
                Display.Choose("The lush green grass glitters under the shining sun.");
            }
        }

        public class SheepHome
        {
            public static void Area()
            {
                States.Queue(State.SheepHome);
            }
        }
    }
}
