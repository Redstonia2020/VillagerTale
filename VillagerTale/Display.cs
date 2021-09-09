using System;
using System.Collections.Generic;
using System.Text;

namespace VillagerTale
{
    public enum Align
    {
        Left,
        Center,
        Right
    }

    class Display
    {
        public static void Text(Align alignment, bool wait, params string[] text)
        {
            foreach (string print in text)
            {
                if (alignment == Align.Center)
                {
                    for (int i = 0; i < (Console.WindowWidth - print.Length) / 2; i++)
                    {
                        Console.Write(" ");
                    }
                }

                else if (alignment == Align.Right)
                {
                    for (int i = 0; i < Console.WindowWidth - print.Length - 1; i++)
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine(print);
            }

            if (wait)
            {
                if (Key() == ConsoleKey.Escape)
                {
                    Game.Pause();
                }
            }
        }

        public static void Text(Align alignment, params string[] text)
        {
            Text(alignment, true, text);
        }

        public static void Text(params string[] text)
        {
            Text(Align.Left, text);
        }

        public static void Crawl(Align alignment, bool wait, params string[] text)
        {
            foreach (string print in text)
            {
                if (alignment == Align.Center)
                {
                    for (int i = 0; i < (Console.WindowWidth - print.Length) / 2; i++)
                    {
                        Console.Write(" ");
                    }
                }

                else if (alignment == Align.Right)
                {
                    for (int i = 0; i < Console.WindowWidth - print.Length - 1; i++)
                    {
                        Console.Write(" ");
                    }
                }

                CrawlText(print);
            }

            Console.WriteLine();

            if (wait)
            {
                if (Key() == ConsoleKey.Escape)
                {
                    Game.Pause();
                }
            }
        }

        public static void Crawl(Align alignment, params string[] text)
        {
            Crawl(alignment, true, text);
        }

        public static void Crawl(bool wait, params string[] text)
        {
            Crawl(Align.Left, wait, text);
        }

        public static void Crawl(params string[] text)
        {
            Crawl(Align.Left, text);
        }

        private static void CrawlText(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                string character = text[i].ToString();
                Console.Write(character);
                if (Console.KeyAvailable)
                {
                    continue;
                }

                else if (character == ",")
                {
                    Wait(150);
                }

                else if (character == "." && i + 1 < text.Length && text[i + 1].ToString() == ".")
                {
                    Wait(150);
                }

                else if (character == "." || character == "?" || character == "!")
                {
                    Wait(350);
                }

                else if (character == "-")
                {
                    Wait(350);
                }

                else
                {
                    Wait(35);
                }
            }

            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

        public static bool Confirm(string text, Align alignment = Align.Left)
        {
            Text(alignment, false, $"{text} (y/n)");

            while (true)
            {
                ConsoleKey key = Key();
                if (key == ConsoleKey.Y)
                {
                    return true;
                }

                else if (key == ConsoleKey.N)
                {
                    return false;
                }
            }
        }

        public static int Choose(string choose, bool crawl, params string[] choices)
        {
            if (crawl)
                Crawl(Align.Left, false, choose);
            else
                Console.WriteLine(choose);

            for (int i = 0; i < choices.Length; i++)
            {
                Console.WriteLine($"  ({i + 1:D2}) {choices[i]}");
            }

            for (int i = 0; i < choices.Length; i++)
            {
                choices[i] = choices[i].ToLower();
            }

            while (true)
            {
                string choice = Console.ReadLine().ToLower();
                if (string.IsNullOrWhiteSpace(choice)) { }
                else if (int.TryParse(choice, out int index) && --index < choices.Length)
                {
                    return index;
                }

                else if (Array.Exists(choices, e => e.StartsWith(choice)))
                {
                    return Array.FindIndex(choices, e => e.StartsWith(choice));
                }

                else if (Array.Exists(choices, e => e.Contains(choice)))
                {
                    return Array.FindIndex(choices, e => e.Contains(choice));
                }
            }
        }

        public static int Choose(string choose, params string[] choices)
        {
            return Choose(choose, false, choices);
        }


        public static void Speak(string speaker, string dialogue)
        {
            Console.Write($"[{speaker}] ");
            Crawl($"\"{dialogue}\"");
        }

        public static void CenterVertical(int lines)
        {
            for (int i = 0; i < (Console.WindowHeight - lines) / 2; i++)
            {
                Console.WriteLine();
            }
        }

        public static void Wait(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        public static ConsoleKey Key(out ConsoleKeyInfo info)
        {
            while (Console.KeyAvailable)    // this clears the buffer of keys stacked up on each other
                Console.ReadKey(true);
            info = Console.ReadKey(true);
            return info.Key;
        }

        public static ConsoleKey Key()
        {
            return Key(out _);
        }
    }
}
