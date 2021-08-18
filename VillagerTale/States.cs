﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VillagerTale
{
    public enum State
    {
        StartMenu,
        IntroNarrative,
        IntroSheepDialogue
    }

    class States
    {
        private static State? _queued;
        private static bool _cycling = true;

        public static Dictionary<State, Action> ToAction = new Dictionary<State, Action>
        {
            { State.StartMenu, Game.StartMenu },
            { State.IntroNarrative, Story.Intro.Narrative },
            { State.IntroSheepDialogue, Story.Intro.SheepDialogue },
        };

        public static void Start()
        {
            while (_cycling)
            {
                if (_queued.HasValue)
                {
                    State state = _queued.Value;
                    _queued = null;

                    Game.Data.CurrentState = state;
                    Game.Save();
                    ToAction[state]();
                }

                else
                {
                    NoStateError();
                }
            }
        }

        public static void Queue(State function)
        {
            _queued = function;
        }

        public static void End(State function)
        {
            Queue(function);
            SetCycle(false);
        }

        public static void SetCycle(bool set)
        {
            _cycling = set;
        }

        private static void NoStateError()
        {
            Console.Clear();
            Display.Text("no state is set");
            SetCycle(false);
        }
    }
}