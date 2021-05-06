using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Final_Game_Project.Scenes
{
    class Credits : Scene
    {
        public Credits(Game game): base(game)
        {

        }
        public override void Run()
        {
            Clear();
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Credits\n");
            ResetColor();
            WriteLine("Orginal work based in the cinamatic world of SAW which was created by James Wan and Leigh Whannell.\n");
            WriteLine("Code by Nick Eisner\n");
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Art\n");
            ResetColor();
            WriteLine("Billy the Puppet: https://pixabay.com/vectors/film-horror-jigsaw-movie-saw-1296110/ \n");
            WriteLine("Scalpel: https://pixabay.com/vectors/scalpel-tool-medical-surgery-sharp-24257/ \n");
            WriteLine("Dead Body: https://pixabay.com/vectors/crime-scene-silhouette-body-ground-29308/ \n");
            WriteLine("Title Art (Bloody Font): https://patorjk.com/software/taag/#p=display&f=Graffiti&t=Type%20Something%20 \n");
            WriteLine("Game Over Image (Bloody Font): https://patorjk.com/software/taag/#p=display&f=Graffiti&t=Type%20Something%20 \n");
            WriteLine("Game OVer Text (Bloody Font): https://patorjk.com/software/taag/#p=display&f=Graffiti&t=Type%20Something%20 \n");
            WriteLine("Final Door (Bloody Font): https://patorjk.com/software/taag/#p=display&f=Graffiti&t=Type%20Something%20 \n");
            WriteLine("All other art created by me using: https://asciiflow.com/#/ \n");
            ConsoleUtils.ExitConsole();
        }
    }
}
