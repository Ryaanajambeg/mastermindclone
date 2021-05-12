using System;

namespace mastermindclone
{
    class mastermindclone
    {



        private static bool Nvalid; // boolean to see if value of N is valid
        private static bool Mvalid; // boolean to see if value of M is valid
        private static bool Active = true; //boolean variable to see if the mastermind is active or not
        public string PlayerInput; // what the player inputs in the console
        private static bool playgame; // boolean to check if the user has typed play in the console or not
        private static bool randomise = false; // checking if a secret code has been created according to the number of positions and colours chose by the user and setting it to false initially
        private static int N; // where the user selects the number of positions
        private static int M; //where the user selects the amount of colors he wants
        private static int[] stored; // stores the secret code number
        private static int[] guesses; // has the guesses of the player
        private static string G; //the guess of the player
        private static int inputval; // int value that the user has typed
        private static bool Isitanum; // checking if the string contains an int type       
        private static int whitepegs = 0; // displays the number of whitepegs and setting it to 0 intially
        private static int blackpegs; // displays the number of blackpegs 
        

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
                game.Gameplay(); // calling "Gameplay"
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

            if (PlayerInput == "stop") //if player types "stop" active will be set to false and the program will stop running
            {
                Active = false; // putting the boolean variable "Active" to false so as to stop the game
            }
            else
            {
                Active = true; // toherwise active will be true
            }

            if (PlayerInput == "play") // checking if the player has inputted "play" in the console
            {
                playgame = true; // setting the boolean playgame to true if the user has typed play
            }
            
                



        }

        private void Gameplay()
        {

            if (playgame == true)
            {
                while (Nvalid == false && Mvalid == false )
                {
                    Console.WriteLine("Select the number of positions you wish to use"); // asking the user to enter a number of positions he wishes to use
                    N = Convert.ToInt32(Console.ReadLine()); // reading from the console what value of N the user types convert it to an integer value
                    if (N <= 0) // checking if the number of positions is valid
                    {
                        Console.Clear(); // clearing the console after the user has typed his desired value of N

                        Console.WriteLine("Incorrect Input! please enter a valid number greater than 0"); // printing out an error messsage if N is invalid
                    }

                    else if (N > 0) // checking if N is valid
                    {
                        Console.Clear(); //  clearing the console after the user has typed his desired value of N
                        Nvalid = true; // setting the boolean Nvalid to true when the user has typed a valid value of N
                    }
                }

                while (Mvalid == false && Nvalid == true)
                {
                    Console.WriteLine("Enter the number of colours you wish to use (Maximum = 9)"); // printing out number of colours user wishes to enter is number of positions is valid
                    M = Convert.ToInt32(Console.ReadLine()); // reding the value of M from the console and converting it to an integer
                    if (M < 1 || M > 9) // checking to see if M is not valid
                    {
                        Console.Clear(); // clearing the console after the user has typed his desired value of M
                        Console.WriteLine("Invalid number of colours, please enter a number between 1 and 9"); // printing out an error message if the range of M is not valid
                    }
                    else if (M >= 1 || M <= 9) // checking if M is in the correct range
                    {
                        Console.Clear(); // clearing the console after the user has typed his desired value of M
                        Mvalid = true; // changing the boolean Mvalid to true if the value of M the user has typed is valid
                    }


                }
            }

            if (Mvalid = true && Nvalid == true && randomise == false )
            {


                stored = new int[N]; // declaring the "stored" array

                Random rand = new Random(); // expression to randomise vallues

                for (int i = 0; i < N; i++) // for loop with a max value fo the number of positions the user has typed
                {
                    int temporary = rand.Next(1, M + 1); // a tempoary  varaible holding the randomised values
                    stored[i] = temporary; // adding those values to the "stored" array

                }
                for (int i = 0; i < N; i++)
                {
                    Console.Write(stored[i]); 
                }
                Console.WriteLine();

                randomise = true;

            }
            while (Mvalid = true && Nvalid == true && randomise == true )
            {
                 //G = Console.ReadLine();
                guesses = new int[N];
                // int guesscount = 0;

                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine("Enter your guess for position {0}:", i);
                    inputval = 0;
                    G = Console.ReadLine();
                    Isitanum = int.TryParse(G, out inputval);
                    //Inlimits = Isitanum && 1 <= inputval && inputval <= N;



                    guesses[i] = inputval; // adding inputvalue to the guesses array


                }
                for (int i = 0; i < N; i++)
                {
                    if (guesses[i] == stored[i]) // checking if guessed colour is in same position as the secret code
                    {
                        blackpegs++; // black pegs increases by 1 if guess is correct colour and in the correct position as the secret code
                    }
                }
                for (int i = 0; i < N; i++)
                {

                    for (int j = 0; j < N; j++)
                    {
                        if (guesses[i] == stored[j]) // checking if guessed code is in the secret code but not in same position
                        {
                            whitepegs++; // whitepegs increase if colour in both codes but not in same position
                             break;
                        }
                    }
                    if (guesses[i] == stored[i]) // checking if colour in both codes and in same positions
                    {
                        
                        whitepegs -= 1; // decreasing the whitepegs number by 1 if thats the case
                    }
                }
                                                                
               
                Console.WriteLine("Black: " + blackpegs); // displaying the number of black pegs 
                Console.WriteLine("white: " + whitepegs); // displaying the number of white pegs
                if (blackpegs == N) // checking if the number of blackpegs is same amount as the number of positions
                {
                    
                    Console.WriteLine("Congratulations! your guess is correct!"); // displaying a congratulations message if user has guessed code correctly
                    
                }                                           
                else
                {
                    blackpegs = 0; // if the guessed code is not same as secret code then blackpegs is set to 0 again so user can make another guess
                    whitepegs = 0; // if the guessed code is not same as secret code then whitepegs is set to 0 again so user can make another guess
                }

            }
        }
    }
}
