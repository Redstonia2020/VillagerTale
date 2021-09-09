using System;
using System.Collections.Generic;
using System.Text;

namespace VillagerTale
{
    class Character : Interactable
    {
        public string Name { get; set; }
        public int Reputation { get; set; }
        public bool Dead { get; set; }

        public virtual void Interact()
        {
            // You'd have to override this function to actually make your character say anything. //
        }
    }
}
