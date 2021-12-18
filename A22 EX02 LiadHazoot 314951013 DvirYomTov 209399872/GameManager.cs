using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_EX02_LiadHazoot_314951013_DvirYomTov_209399872
{
    public class GameManager
    {
        private const int k_MinNumberOfGuesses = 4;
        private const int k_MaxNumberOfGuesses = 10;

        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            gm.GameManage();
        }
        public GameManager()
        {
            


        }
        public void GameManage()
        {
            int numberOfGuesses = getNumberOfGuesses();
 

        }

        private Guess getGuess()
        {
            bool isInputValid = false;
            Guess guess; // add '?'
            guess = new Guess();
            while (!isInputValid)
            {
                Console.WriteLine("Enter guess");
                string numberOfGuessesStr = Console.ReadLine();
                try
                {
                    guess.userGuess = numberOfGuessesStr;
                    isInputValid = true;
                }
                catch (TypeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (RangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return guess;
        }

        private int getNumberOfGuesses()
        {
            bool isInputValid = false;
            int numberOfGuesses = 0;
            while (!isInputValid)
            {
                Console.WriteLine("Enter number of guesses");
                string numberOfGuessesStr = Console.ReadLine();
                try
                {
                    numberOfGuesses = numberOfGussesValidation(numberOfGuessesStr);
                    isInputValid = true;
                }
                catch (TypeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (RangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return numberOfGuesses;
        }
        private int numberOfGussesValidation(string i_numberOfGuesses)
        {
            int numOfGuesses;
            bool intResultTryParse = int.TryParse(i_numberOfGuesses, out numOfGuesses);
            if (!intResultTryParse)
            {
                throw new TypeException("number of guesses wrong type");
            }
            else if (numOfGuesses > k_MaxNumberOfGuesses || numOfGuesses < k_MinNumberOfGuesses)
            {
                throw new RangeException("number of guesses out of range");
            }
            return numOfGuesses;
        }

    }
    public class RangeException : Exception
    {
        public RangeException(string message)
            : base(message)
        { }
    }
    public class TypeException : Exception
    {
        public TypeException(string message)
            : base(message)
        { }
    }
}
