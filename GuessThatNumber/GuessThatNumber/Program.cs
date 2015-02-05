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

            // message for quit
            string quitMessage = "Are you a quiter";
            string quitTitleMessage = "He's a quiter... It's in the eyes.";
            // set console window size
            Console.SetWindowSize((int)Math.Floor(Console.LargestWindowWidth * 0.8), (int)Math.Floor(Console.LargestWindowHeight * 0.8));

            // main Game loop with a quit message
            {
                // title screen with any key to play
                TitleScreen();
                // enter the game state to find skeletor by using the guess number
                SetNumberToGuess(NumberGetter.Next(1, 100));
                message = "Do you know where I am?";
                messageTitle = "He doesn't know... he he";
                MessageBox.Show(message, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // This loops through the user input
                if (FindSkeletor())
                {
                    message = "Child, do you think you can defeat me. He!! He!!";
                    messageTitle = "Prepare, yourself...";
                    MessageBox.Show(message, messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                // enter a small game where we use the guess number, but as a hitter counter
            } while (Quiter(quitMessage, quitTitleMessage));
        }

        /// <summary>
        /// Clears and prints an OK title screen while you play the game.
        /// </summary>
        public static void TitleScreen()
        {
            Console.Clear();
            // ascii art
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

        /// <summary>
        /// Gets the users input and if not it prints a bad message to the screen.  It also converts the string to a integer
        /// </summary>
        /// <param name="message"></param>
        /// <returns>0 for invalid input or the string gets converted to a integer</returns>
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
                //Console.WriteLine("You are a troublesome child. he he");
                MessageBox.Show("You are a troublesome child. he he", userInput + "invalid input...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        /// <summary>
        /// At the state the user is finding Skeletor
        /// </summary>
        /// <returns>when skeletor is found it returns true</returns>
        public static bool FindSkeletor()
        {
            int GuessedNumber = GetUserInput("So, you want to find me? I am in location from 1 to 100. So, please make your entry.");
            int attempts = 1;
            // keeps on looping until guessedNumber equals to NumberToGuess
            while (GuessedNumber != NumberToGuess)
            {
                GuessThatNumber(GuessedNumber, "He!! He!! he, he...  You, no brain, you are dead cold. he, he");
                GuessedNumber = GetUserInput("What's the matter? You can't find me.");
                attempts++;
            }

            MessageBox.Show("You slow child. It took you " + attempts + " rounds to find. he he", "Skeletor was found", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            return true;
        }

        /// <summary>
        /// Messages are print to the console when user inputs a guess.
        /// </summary>
        /// <param name="GuessedNumber">user input</param>
        /// <param name="message">Random message from main function</param>
        public static void GuessThatNumber(int GuessedNumber, string message)
        {
                if (IsGuessTooHigh(GuessedNumber))
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(message);
                }
                if (IsGuessTooLow(GuessedNumber))
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("You, mencing child. he he...");
                }
        }

        /// <summary>
        /// A quit message displays and waits for the user's input
        /// </summary>
        /// <returns>Yes return false and no returns true</returns>
        public static bool Quiter(string quitMessage, string titleMessage)
        {
            DialogResult userResponse = MessageBox.Show(quitMessage,titleMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            Console.WriteLine("Are you a quitter?");

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
        
        /// <summary>
        /// Valids the user input
        /// </summary>
        /// <param name="userInput">User input</param>
        /// <returns>valid or not valid</returns>
        public static bool ValidateInput(string userInput)
        {
            //check to make sure that the users input is a valid number between 1 and 100.
            int tempInteger;
            if (int.TryParse(userInput, out tempInteger))
            // looks at userInput to 1 - 100
            if (Convert.ToInt32(userInput) > 0 && Convert.ToInt32(userInput) < 101)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// setter for the Number 
        /// </summary>
        /// <param name="number"></param>
        public static void SetNumberToGuess(int number)
        {
            //TODO: make this function override your global variable holding the number the user needs to guess.  This is used only for testing methods.
            NumberToGuess = number;
        }

        /// <summary>
        /// Compares the user's guess to the number, if it's too high.
        /// </summary>
        /// <param name="userGuess">userinput</param>
        /// <returns>boolean</returns>
        public static bool IsGuessTooHigh(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too high
            if (userGuess > NumberToGuess)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Compares the user's input with number to guess and if it is too low it returns true
        /// </summary>
        /// <param name="userGuess">user's input</param>
        /// <returns>boolean</returns>
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
