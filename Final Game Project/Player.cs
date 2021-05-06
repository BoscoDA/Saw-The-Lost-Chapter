using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using Final_Game_Project.Scenes;

namespace Final_Game_Project
{
    class Player
    {
        public string Name { get; set; }
        public bool HasKey;
        public bool HasScalpel;
        public bool HasTourniquet;
        public bool HasSacrificed;
        public bool HasHacksaw;
        public bool HasLookedAround;

        public Player()
        {
            Name = null;
            HasKey = false;
            HasScalpel = false;
            HasTourniquet = false;
            HasSacrificed = false;
            HasHacksaw = false;
        }
    }
}
