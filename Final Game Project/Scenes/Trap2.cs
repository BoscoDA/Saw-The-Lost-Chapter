using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Final_Game_Project.Scenes
{
    class Trap2 : Scene
    {
        public bool HasEscaped { get; private set; } = false;
        public bool HasPlayedTape { get; private set; }
        private Lock LockLocker;
        private Lock LockToolbox;
        public bool IsToolboxUnlocked { get; private set; } = false;
        public bool IsLockerUnlocked { get; private set; } = false;
        public int Sin1 { get; private set; }
        public int Sin2 { get; private set; }
        string[] Sins = { "Lust", "Gluttony", "Greed", "Anger", "Heresy", "Violence", "Fraud", "Treachery" };

        public Trap2(Game game) : base(game)
        {
            PickSins();
            LockLocker = new Lock(Sins[Sin1].ToLower(), ConsoleColor.Red);
            LockToolbox = new Lock(Sins[Sin2].ToLower(), ConsoleColor.Red);
        }
        public override void Run()
        {
            MyGame.MyDoor.StartTrap();
            while (HasEscaped != true && MyGame.MyDoor.myWatch.ElapsedMilliseconds <= MyGame.MyDoor.DeathTime)
            {
                string prompt = $"{Art_Assets.SecondTrapOverWorld}\nNow free from the trap. The lights in the room now all turn on revealing your surroundings.\n" +
                    "In the room you see a desk, storage locker, a tool box and a door.\n\n" +
                    "Where would you like to go?";
                string[] options = { "Go to desk...", "Go to storage locker...", "Go to tool box...", "Go to door" };
                Menu choiceMenu = new Menu(prompt, options);
                int selectedIndex = choiceMenu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Desk();
                        break;
                    case 1:
                        UnlockLocker();
                        break;
                    case 2:
                        UnlockToolbox();
                        break;
                    case 3:
                        bool wasSuccesful = MyGame.MyDoor.AttemptEscape();
                        HasEscaped = wasSuccesful;
                        break;
                }
            }
            MyGame.MyDoor.myWatch.Stop();
            if (HasEscaped == true && MyGame.MyDoor.myWatch.ElapsedMilliseconds <= MyGame.MyDoor.DeathTime)
            {
                Clear();
                MyGame.MyFinalScene.Run();
            }
            else
            {
                MyGame.MyDeath.Run();
            }

        }
        private void Desk()
        {
            string deskPrompt = $"{Art_Assets.Desk}\n\nYou walk up to the desk.";
            string[] deskOptions = { "Open drawer...", "Walk away..." };
            Menu deskMenu = new Menu(deskPrompt, deskOptions);
            int deskSelectedIndex = deskMenu.Run();

            switch (deskSelectedIndex)
            {
                case 0:
                    string subPrompt = $"{Art_Assets.Drawer}\n\nYou open the drawer and find a tape recorder inside..." +
                        "Do you want to play it?";
                    string[] subOptions = { "Yes", "No" };
                    Menu subChoiceMenu2 = new Menu(subPrompt, subOptions);
                    int subSelectedIndex = subChoiceMenu2.Run();
                    switch (subSelectedIndex)
                    {
                        case 0:
                            PlayTape();
                            break;
                        case 1:
                            deskMenu.Run();
                            break;
                    }
                    break;
                case 1:
                    MyGame.MyChoice3.Run();
                    break;
            }
        }
        private void PlayTape()
        {
            string tape1 = @$"Well done completing your first trial {MyGame.MyPlayer.Name}. But you're not
in the clear yet. You still must be held accountable for the harm your sinful
lifestyle has caused others. Will you be able to make the ultimate sacrifice
in order to be born a new. 
Free from the {Sins[Sin1]} you've locked away deep insisde you and the
{Sins[Sin2]} you've used as a tool to ruin others lives.
Dig deep {MyGame.MyPlayer.Name}.
Live or die. The Choice is Yours. ";
            TextAnimationUtils.AnimateMultiLines(tape1, 20, 38, Art_Assets.TapeRecorder, ConsoleColor.Red, 40);
            ConsoleUtils.WaitForKeyPress();
            HasPlayedTape = true;
            Clear();
        }
        private void Locker()
        {
            string lockerPrompt = $"{Art_Assets.Locker}\n\nYou walk up to the storage locker...";
            string[] lockerOptions = { "Open locker...", "Walk away..." };
            Menu lockerMenu = new Menu(lockerPrompt, lockerOptions);
            int lockerSelectedIndex = lockerMenu.Run();

            switch (lockerSelectedIndex)
            {
                case 0:
                    if (MyGame.MyPlayer.HasTourniquet == false)
                    {
                        string subPrompt = $"{Art_Assets.Tourniquet}\n\nYou open the locker and find an old vietnam era tourniquet inside..." +
                            "Do you want to take it?";
                        string[] subOptions = { "Yes", "No" };
                        Menu subChoiceMenu2 = new Menu(subPrompt, subOptions);
                        int subSelectedIndex = subChoiceMenu2.Run();
                        switch (subSelectedIndex)
                        {
                            case 0:
                                MyGame.MyPlayer.HasTourniquet = true;
                                MyGame.MyChoice3.Run();
                                break;
                            case 1:
                                lockerMenu.Run();
                                break;
                        }
                    }
                    else
                    {
                        string emptyLocker = @"The locker is empty... ";
                        TextAnimationUtils.AnimateMultiLines(emptyLocker, 20, 38, Art_Assets.EmptyLocker, ConsoleColor.Green, 50);
                        ConsoleUtils.WaitForKeyPress();
                        Clear();
                    }
                    break;
                case 1:
                    MyGame.MyChoice3.Run();
                    break;
            }
        }
        private void UnlockLocker()
        {
            if (IsLockerUnlocked == false)
            {
                bool lockerUnlocked = LockLocker.AttemptEscape();
                IsLockerUnlocked = lockerUnlocked;
                if (IsLockerUnlocked == false)
                {
                    Run();
                }
                else
                {
                    Locker();
                }
            }
            else
            {
                Locker();
            }
        }
        private void Toolbox()
        {
            string toolPrompt = $"{Art_Assets.Toolbox}\n\nYou walk up to the tool box...";
            string[] toolOptions = { "Open locker...", "Walk away..." };
            Menu toolMenu = new Menu(toolPrompt, toolOptions);
            int toolSelectedIndex = toolMenu.Run();

            switch (toolSelectedIndex)
            {
                case 0:
                    if (MyGame.MyPlayer.HasHacksaw == false)
                    {
                        string subPrompt = $"{Art_Assets.Hacksaw}\n\nYou open the tool box and wrapped in a black plastic garbage bag you find a rusty hacksaw..." +
                            "Do you want to take it?";
                        string[] subOptions = { "Yes", "No" };
                        Menu subChoiceMenu2 = new Menu(subPrompt, subOptions);
                        int subSelectedIndex = subChoiceMenu2.Run();
                        switch (subSelectedIndex)
                        {
                            case 0:
                                MyGame.MyPlayer.HasHacksaw = true;
                                MyGame.MyChoice3.Run();
                                break;
                            case 1:
                                toolMenu.Run();
                                break;
                        }
                    }
                    else
                    {
                        string emptyToolbox = "The toolbox is empty... ";
                        TextAnimationUtils.AnimateMultiLines(emptyToolbox, 20, 38, Art_Assets.EmptyToolbox, ConsoleColor.Green, 40);
                        ConsoleUtils.WaitForKeyPress();
                        Clear();
                    }
                    break;
                case 1:
                    MyGame.MyChoice3.Run();
                    break;
            }
        }
        private void UnlockToolbox()
        {
            if (IsToolboxUnlocked == false)
            {
                bool toolboxUnlocked = LockToolbox.AttemptEscape();
                IsToolboxUnlocked = toolboxUnlocked;
                if (IsLockerUnlocked == false)
                {
                    Run();
                }
                else
                {
                    Toolbox();
                }
            }
            else
            {
                Toolbox();
            }

        }
        private void PickSins()
        {
            if (HasPlayedTape != true)
            {
                Random random = new Random();
                Sin1 = random.Next(0, 8);
                Sin2 = random.Next(0, 8);
                while (Sin1 == Sin2)
                {
                    Sin1 = random.Next(0, 8);
                    Sin2 = random.Next(0, 8);
                }
            }
        }
    }
}
