using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessThatNumber
{
    public class Program
    {
        //this is the number the user needs to guess.  Set its value in your code using a RNG.
        static int NumberToGuess = 0;
        static Random NumberGetter = new Random();
       
        static void Main(string[] args)
        {
            // strings message and the title bar message.
            string message = null;
            string messageTitle = null;

          // Game loop
            {
                // set console window size
                Console.SetWindowSize((int)Math.Floor(Console.LargestWindowWidth * 0.8), (int)Math.Floor(Console.LargestWindowHeight * 0.8));
                // title screen with any key to play
                TitleScreen();
                // enter the game state to find skeletor by using the guess number
                SetNumberToGuess(NumberGetter.Next(1, 100));
                message = "Do you know where I am?";
                messageTitle = "He doesn't know... he he";
                MessageBox.Show(message, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // if true the user guessed right
                if (FindSkeletor())
                {
                    message = "Child, do you think you can defeat me. He!! He!!";
                    messageTitle = "Prepare, yourself...";
                    MessageBox.Show(message, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                // enter a small game where we use the guess number, but as a hitter counter
            } while (Quiter());
        }

        public static void TitleScreen()
        {
            Console.Clear();
            Console.WriteLine(@"
      :::::::: :::    ::::::::::::::::       ::::::::::::::::::::::::::::: ::::::::: 
    :+:    :+::+:   :+: :+:       :+:       :+:           :+:   :+:    :+::+:    :+: 
   +:+       +:+  +:+  +:+       +:+       +:+           +:+   +:+    +:++:+    +:+");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(@"  +#++:++#+++#++:++   +#++:++#  +#+       +#++:++#      +#+   +#+    +:++#++:++#:    
        +#++#+  +#+  +#+       +#+       +#+           +#+   +#+    +#++#+    +#+    
#+#    #+##+#   #+# #+#       #+#       #+#           #+#   #+#    #+##+#    #+#     
######## ###    #################################    ###    ######## ###    ### ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Any key to play with me...");
            Console.ReadKey();
        }

        public static int GetUserInput(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine();
            if (ValidateInput(userInput))
            {
                return Convert.ToInt32(userInput);
            }
            else
            {
                Console.WriteLine("You are a troublesome child. he he");
                return 0;
            }
        }

        public static bool FindSkeletor()
        {
            int GuessedNumber = GetUserInput("So, you want to find me? I am in location from 1 to 100. So, please make your entry.");
            int attempts = 1;
            while (GuessedNumber != NumberToGuess)
            {
                GuessThatNumber(GuessedNumber);
                GuessedNumber = GetUserInput("What's the matter? You can't find me.");
                attempts++;
            }

            return true;
        }

        public static bool GuessThatNumber(int GuessedNumber)
        {
                if (GuessedNumber > NumberToGuess)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("He!! He!! he, he...  You, no brain, you are dead cold. he, he");
                    return false;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("You, mencing child. he he... You are getting closer...");
                    return false;
                }
                return true;
        }

        public static bool Quiter()
        {
            string quitMessage = "Are you a quiter";
            string titleMessage = "He's a quiter... It's in the eyes.";
            DialogResult userResponse = MessageBox.Show(quitMessage,titleMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            Console.WriteLine("Are you a quiter? ");

            if (userResponse == DialogResult.Yes)
            {
                Console.WriteLine("Ah, yes... Yes, I knew you can't defeat me!!!");
                return false;
            }
            else
            {
                TitleScreen();
                Console.WriteLine("Oh, you come back for more. Great, great, HA HA!!!");
                return true;
            }
        }
        
        public static bool ValidateInput(string userInput)
        {
            //check to make sure that the users input is a valid number between 1 and 100.
            for (int i = 0; i < userInput.Length; i++)
            {
                if (Char.IsLetter(userInput[i]))
                    return false;
            }


            if (Convert.ToInt32(userInput) > 0 && Convert.ToInt32(userInput) < 101)
            {
                return true;
            }
            return false;
        }

        public static void SetNumberToGuess(int number)
        {
            //TODO: make this function override your global variable holding the number the user needs to guess.  This is used only for testing methods.
            NumberToGuess = number;
        }

        public static bool IsGuessTooHigh(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too high
            if (userGuess > NumberToGuess)
            {
                return true;
            }
            return false;
        }

        public static bool IsGuessTooLow(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too low
            if (userGuess < NumberToGuess)
            {
                return true;
            }
            return false;
        }
    }
}
