using System;
using System.Collections.Generic;
using System.Text;

namespace VillagerTale
{
    class AreaInteractables
    {
        public AreaInteractables(params Interactable[] add)
        {
            Add(add);
        }

        public List<Interactable> Interactables = new List<Interactable>();

        public void Add(params Interactable[] add)
        {
            Interactables.AddRange(add);
        }

        public T[] Get<T>()
        {
            List<T> passed = new List<T>();
            foreach (object item in Interactables)
            {
                if (item is T)
                {
                    passed.Add((T)item);
                }
            }

            return passed.ToArray();
        }
    }
}
