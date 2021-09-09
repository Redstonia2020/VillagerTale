using System;
using System.Collections.Generic;
using System.Text;

namespace VillagerTale
{
    interface Interactable
    {
        public string Name { get; set; }

        public void Interact();
    }
}
