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
            }
        }
    }
}
