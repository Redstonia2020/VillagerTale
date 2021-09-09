using System;
using System.Collections.Generic;
using System.Text;

namespace VillagerTale
{
    class Data
    {
        public Data()
        {
            
        }

        public State CurrentState { get; set; }

        public string Name { get; set; }

        public IntroSheep IntroSheepCharacter = new IntroSheep();
    }
}
