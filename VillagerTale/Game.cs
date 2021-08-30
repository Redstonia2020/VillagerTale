using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VillagerTale
{
    class Game
    {
        public static Data Data = new Data();
        public static string SaveDirectory = "saves";
        public static string CurrrentSave;
        public static string AutosaveDirectory = "saves/autosaves";
        public static string AutosaveFile = "saves/autosaves/autosave.json";
        public static bool DevSave = false;

        public static void Pause()
        {
            Console.Clear();
            Display.CenterVertical(6);
            Display.Text(Align.Center, false,
                "PAUSE Menu",
                "",
                "Return to Game (ESC)",
                "Save Game to... (S)",
                "Load Game... (L)",
                "Exit Game (BACKSPACE)"
            );

            ConsoleKey key = Display.Key();
            if (key == ConsoleKey.S)
            {
                Console.Clear();
                ChangeSave(false, true);
                Pause();
            }

            else if (key == ConsoleKey.L)
            {
                if (Display.Confirm("Would you like to save your current file?"))
                {
                    Save();
                    Console.WriteLine("Saved game!");
                    ChangeSave(true, false);
                }
            }

            else if (key == ConsoleKey.Backspace)
            {
                Console.Clear();
                Display.CenterVertical(2);
                if (Display.Confirm($"Are you sure you want to exit?", Align.Center))
                {
                    Environment.Exit(0);
                }

                Pause();
            }

            else if (key == ConsoleKey.Escape)
            {
                return;
            }

            else
            {
                Pause();
            }
        }

        public static void StartMenu()
        {
            Display.CenterVertical(4);
            Display.Text(Align.Center, "Villager Tale", "all rights not reserved", "", "press any key to START");

            ChangeSave(true, true);
            Console.Clear();
        }

        public static void Save()
        {
            if (DevSave)
                return;

            try
            {
                File.WriteAllText(CurrrentSave, JsonSerializer.Serialize(Data));
            }

            catch (ArgumentNullException)
            {
                //doesn't care
            }
        }

        public static void Autosave()
        {
            File.WriteAllText(AutosaveFile, JsonSerializer.Serialize(Data));
        }

        public static void Load()
        {
            Data = JsonSerializer.Deserialize<Data>(File.ReadAllText(CurrrentSave));
            States.Queue(Data.CurrentState);
        }

        private static void ChangeSave(bool load, bool allownew)
        {
            Console.Clear();
            
            Console.WriteLine("Select a save by inputting the name of your save on the right, or use a different name to create a save with that name.");
            string[] saves = GetSaves(out string[] shortnames);
            for (int i = 0; i < saves.Length; i++)
            {
                Console.WriteLine($"{shortnames[i]}\t({saves[i]})");
            }

            while (true)
            {
                string typed = Console.ReadLine();
                if (Array.Exists(shortnames, e => e == typed))
                {
                    int savei = Array.IndexOf(shortnames, typed);
                    CurrrentSave = $"{saves[savei]}";
                    Display.Text($"Using save \"{shortnames[savei]}\" ({saves[savei]})");
                    if (load)
                        Load();
                    else
                        Save();
                    break;
                }

                else if (string.IsNullOrWhiteSpace(typed)) { }

                else
                {
                    if (!allownew)
                    {
                        continue;
                    }

                    if (typed == "dev")
                    {
                        DevSave = true;
                        if (load)
                            States.Queue(State.IntroNarrative);
                        break;
                    }

                    else if (Display.Confirm($"Create new save with name \"{typed}\"?"))
                    {
                        CurrrentSave = $"{SaveDirectory}/{typed}.json";
                        Display.Text($"Created save!");
                        if (load)
                            States.Queue(State.IntroNarrative);
                        Save();
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Cancelled action.");
                    }
                }
            }
        }

        public static string[] GetSaves(out string[] shortnames)
        {
            if (!Directory.Exists(AutosaveDirectory))
            {
                Directory.CreateDirectory(AutosaveDirectory);
            }

            string[] saves = Directory.GetFiles(SaveDirectory);
            List<string> shortnameslist = new List<string>();
            foreach (string save in saves)
            {
                shortnameslist.Add(Path.GetFileNameWithoutExtension(save));
            }

            shortnames = shortnameslist.ToArray();
            return saves;
        }
    }
}