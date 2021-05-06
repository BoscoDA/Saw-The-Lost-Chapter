using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Game_Project.Scenes
{
    class Scene
    {
        protected Game MyGame;

        public Scene(Game game)
        {
            MyGame = game;
        }

        virtual public void Run()
        {
            // Runs the actual scene logic!
            // Override in child classes.
        }
    }
}
