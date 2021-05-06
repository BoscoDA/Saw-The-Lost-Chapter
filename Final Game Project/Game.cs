using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using Final_Game_Project.Scenes;
using Final_Game_Project.Maze;

namespace Final_Game_Project
{
    class Game
    {
        public Player MyPlayer;
        public MainMenu MyMainMeneu;
        public Intro MyIntro;
        public BillyIntro MyBilly;
        public PreTrap1 MyChoice1;
        public Struggle MyStruggle;
        public Trap1 MyChoice2;
        public Trap2 MyChoice3;
        public Reverse_Bear_Trap MyReverse;
        public GameMaze MyMaze;
        public FinalDoor MyDoor;
        public Final_Scene MyFinalScene;
        public Credits MyCredits;
        public You_Died MyDeath;

        public Game()
        {
            MyPlayer = new Player();
            MyMainMeneu = new MainMenu(this);
            MyIntro = new Intro(this);
            MyBilly = new BillyIntro(this);
            MyChoice1 = new PreTrap1(this);
            MyStruggle = new Struggle(this);
            MyChoice2 = new Trap1(this);
            MyChoice3 = new Trap2(this);
            MyReverse = new Reverse_Bear_Trap(ConsoleColor.Red, 120000, this);
            MyMaze = new GameMaze();
            MyDoor = new FinalDoor(ConsoleColor.Red, 240000, this);
            MyFinalScene = new Final_Scene(this);
            MyCredits = new Credits(this);
            MyDeath = new You_Died(this);
        }

        public void Start()
        {

            MyMainMeneu.Run();
        }
        
        
        
        
       
    }
}
