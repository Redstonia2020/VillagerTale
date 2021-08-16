using System;

namespace VillagerTale
{
    class Program
    {
        static void Main(string[] args)
        {
            States.Queue(State.StartMenu);
            States.Start();
        }
    }
}
