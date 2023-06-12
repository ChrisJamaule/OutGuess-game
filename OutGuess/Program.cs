OutGuess();

static void OutGuess()
{//start main

    //Declared variables.
    int CPU, tableAmt,userGuess, guess_num =0, wagerAmt, winnings = 0;
    bool anotherRound = true;

    //Create random number generator.
    Random rand_maker = new Random();
   
    CPU = rand_maker.Next(1,101);

    //OUTPUT FUNCTION TO DISPLAY AN INTRODUCTION.
    Console.WriteLine("Welcome to OUTGUESS! Guess a random number between 1-100 to win big!");
    Console.WriteLine();

    //GET USER INPUT.
    Console.WriteLine("How much money are you bringing to the table?");
    tableAmt = int.Parse(Console.ReadLine());

    //INPUT VALIDATION
    while (tableAmt < 10 || tableAmt > 10000)
    {
        Console.WriteLine("MAX table amount:\t $10,000. \nMIN table amount:\t $10.");
        OutGuess();
    }

    Console.Write("Choose amount of guesses (10 Max): \t");
    guess_num = int.Parse(Console.ReadLine());

    while (guess_num <= 0 || guess_num > 10)
    {
        Console.WriteLine("Invalid player move. Guesses should be 1-10. Try again.");
        OutGuess();
    }
   

    //Generate 10 max rounds. Counter variable = number of guesses.
    for (int i = 1; i <= 10; i++)
    {//start for loop

        Console.Write("Wager amount: \t ");
        wagerAmt = int.Parse(Console.ReadLine());

        //INPUT VALIDATION (To make sure user does not wager more than table amount.)
        while (wagerAmt > tableAmt)
        {
            Console.WriteLine("You CANNOT wager more money than ${0}", tableAmt);
            OutGuess();
        }

        while (wagerAmt < 10)
        {
            Console.WriteLine("MIN wager amount: $10.");
            OutGuess();
        }

        Console.WriteLine("Guess a number.");
        userGuess = int.Parse(Console.ReadLine());

        while(userGuess < 1 || userGuess > 100)
        {
            Console.WriteLine("Invalid player move. Guess a number 1-100.");
            OutGuess();
        }
       

        //INPUT VALIDATION (To make sure user only has 10 rounds.)
        while (i > 0 || i <= 10)
        {//start while loop

            if (userGuess == CPU)
            {//start if

                winnings = wagerAmt * (10 - i + 1);
                Console.WriteLine("YOU WON!\n YOUR WINNINGS: \t ${0}", winnings);
                Console.WriteLine();

                tableAmt = (tableAmt - wagerAmt) + winnings;

                guess_num = 0;

                OutGuess();
            } 
            else if (userGuess > CPU)
            {
                Console.WriteLine("Your guess is too high.");
                Console.WriteLine("You have {0} more guesses.", (guess_num - i));
                wagerAmt -= wagerAmt;
                break;
            }
            else if (userGuess < CPU)
            {
                Console.WriteLine("Your guess is too low.");
                Console.WriteLine("You have {0} more guesses.", (guess_num - i));
                wagerAmt -= wagerAmt;
                break;

            }
            else if (guess_num <= 0)
            {
                Console.WriteLine("You have no more guesses. The correct number is {0}. SORRY! :/", CPU);
                Console.WriteLine();

                tableAmt = tableAmt - wagerAmt;
            }
            else if (userGuess > CPU && guess_num <= 0)
            {
                Console.WriteLine("You have no more guesses. The correct number is {0}. SORRY! :/", CPU);
                Console.WriteLine();

                tableAmt = tableAmt - wagerAmt;

            }
            else if (userGuess < CPU && guess_num <= 0)
            {
                Console.WriteLine("You have no more guesses. The correct number is {0}. SORRY! :/", CPU);
                Console.WriteLine();

                tableAmt = tableAmt - wagerAmt;

            }//end if


        }//end while loop

    }//end for loop

   
    Console.ReadKey();

}//end main
