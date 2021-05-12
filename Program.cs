using System;

namespace mastermindclone
{
    class mastermindclone
    {



        private static bool Nvalid; // boolean to see if value of N is valid
        private static bool Mvalid; // boolean to see if value of M is valid
        private static bool Active = true; //boolean variable to see if the mastermind is active or not
        private string PlayerInput; // what the player inputs in the console
        private static bool GamePlayable; // Boolean that says game is playable if valid inputs are used
        private static bool playgame;
        private static bool randomise = false;

        private static int N; // where the user selects the number of positions
        private static int M; //where the user selects the amount of colors he wants
        private static int[] stored; // stores the secret code number
        private static int[] guesses; // has the guesses of the player
        private static string G; //the guess of the playe
        private static int inputval;
        private static bool Isitanum;
        private static int parsingit;
        private static int whitepegs = 0;
        private static int blackpegs;
        private static bool Inlimits;





        static void Main(string[] args)
        {
            mastermindclone game = new mastermindclone();
            string input = string.Empty;

            Console.WriteLine("Welcome to the Mastermind Game! type play to continue");

            while (Active)
            {
                Console.WriteLine("Enter your command:");

                input = game.FirstInput();
                game.ProcessInput(input);
                game.Gameplay();
            }
        }


        private string FirstInput()
        {

            PlayerInput = ""; // input is nothing at start
            PlayerInput = Console.ReadLine(); // read what the player inputs from the console
            Console.Clear(); // console clears after each input

            return PlayerInput;

        }

        private void ProcessInput(string userinput)
        {

            PlayerInput = userinput.ToLower();

            if (PlayerInput == "stop")
            {
                Active = false; // putting the boolean variable "Active" to false so as to stop the game
            }
            else
            {
                Active = true;
            }

            if (PlayerInput == "play")
            {
                playgame = true;
            }


        }

        private void Gameplay()
        {

            if (playgame == true)
            {
                while (Nvalid == false && Mvalid == false)
                {
                    Console.WriteLine("Select the number of positions you wish to use");
                    N = Convert.ToInt32(Console.ReadLine());
                    if (N <= 0) // checking if the number of positions is valid
                    {
                        Console.Clear();

                        Console.WriteLine("Incorrect Input! please enter a valid number greater than 0"); // printing out an error messsage if N is invalid
                    }

                    else if (N > 0) // checking if N is valid
                    {
                        Console.Clear();
                        Nvalid = true;
                    }
                }

                while (Mvalid == false && Nvalid == true)
                {
                    Console.WriteLine("Enter the number of colours you wish to use (Maximum = 9)"); // printing out number of colours user wishes to enter is number of positions is valid
                    M = Convert.ToInt32(Console.ReadLine());
                    if (M < 1 || M > 9) // checking to see if M is not valid
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid number of colours, please enter a number between 1 and 9"); // printing out an error message if the range of M is not valid
                    }
                    else if (M >= 1 || M <= 9)
                    {
                        Console.Clear();
                        Mvalid = true;
                    }


                }
            }

            if (Mvalid = true && Nvalid == true && randomise == false)
            {


                stored = new int[N];

                Random rand = new Random();

                for (int i = 0; i < N; i++)
                {
                    int temporary = rand.Next(1, M + 1);
                    stored[i] = temporary;

                }
                for (int i = 0; i < N; i++)
                {
                    Console.Write(stored[i]);
                }
                Console.WriteLine();

                randomise = true;

            }
            while (Mvalid = true && Nvalid == true && randomise == true)
            {
                // G = Console.ReadLine();
                guesses = new int[N];
                // int guesscount = 0;
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine("Enter your guess for position {0}:", i);
                    inputval = 0;
                    G = Console.ReadLine();
                    Isitanum = int.TryParse(G, out inputval);
                    //Inlimits = Isitanum && 1 <= inputval && inputval <= N;



                    guesses[i] = inputval;


                }
                for (int i = 0; i < N; i++)
                {
                    if (guesses[i] == stored[i])
                    {
                        blackpegs++;
                    }
                }
                for (int i = 0; i < N; i++)
                {
                    // blackpegs = 0;
                    for (int j = 0; j < N; j++)
                    {
                        if (guesses[i] == stored[j])
                        {
                            whitepegs += 1;
                            break;
                        }
                    }

                    //  if (guesses[i] == stored[i])
                    // {
                    //    blackpegs += 1;
                    //   whitepegs -= 1;
                    // }
                   
                }
                Console.WriteLine("Black: " + blackpegs);
                Console.WriteLine("white: " + whitepegs);
                if (blackpegs == N)
                {
                    Console.WriteLine("Congratulations! your guess is correct!");
                }
                else
                {
                    blackpegs = 0;
                    whitepegs = 0;
                }

            }
        }
    }
}
