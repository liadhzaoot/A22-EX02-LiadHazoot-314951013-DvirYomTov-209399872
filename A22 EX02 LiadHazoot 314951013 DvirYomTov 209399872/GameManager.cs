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
        private bool m_IsWin = false;
        private bool m_IsRestart = true;
        private bool m_IsQuit = false;
        private List<Guess> m_UserGuessesList = new List<Guess>();
        private Guess m_UserGuess = null;
        private List<string> m_PointsList = new List<string>();
        private Logic m_Logic;

        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            gm.GameManage();
        }
        public GameManager()
        {
            m_Logic = new Logic();
        }
        public void GameManage()
        {
            string point = "";
            while (m_IsRestart && !m_IsQuit)
            {
                int numberOfGuesses = getNumberOfGuesses();
                string comChoose = m_Logic.ComChooseRandomly();
                // ------------------my check---------------------------------
                Console.WriteLine(comChoose);
                // -----------------------------------------------------------

                for (int i = 0; i < numberOfGuesses; i++)
                {
                    m_UserGuess = getGuess();
                    if (m_UserGuess == null)
                    {
                        m_IsQuit = true;
                        break;
                    }
                    m_UserGuessesList.Add(m_UserGuess); // add guess
                    point = m_Logic.BingoHit(m_UserGuessesList[m_UserGuessesList.Count - 1]);
                    m_PointsList.Add(point); // add point 'X' OR 'V'
                    if (m_Logic.IsWin(point)) // check win
                    {
                        Console.WriteLine("You guessed after " + (i + 1) + " steps!");


                        // ------------------my check---------------------------------
                        printList(m_UserGuessesList);
                        Console.WriteLine();
                        Console.WriteLine("--------------------");
                        Console.WriteLine();
                        m_PointsList.ForEach(Console.WriteLine);
                        // -----------------------------------------------------------


                        m_IsRestart = restartGame();
                        m_IsWin = true;
                        break;
                    }
                }


                // ------------------my check---------------------------------
                if (!m_IsRestart && !m_IsWin)
                {
                    printList(m_UserGuessesList);
                    Console.WriteLine();
                    Console.WriteLine("--------------------");
                    Console.WriteLine();
                    m_PointsList.ForEach(Console.WriteLine);
                }
                // -----------------------------------------------------------



                if (!m_IsWin && !m_IsQuit) // if the user Lose and not quit :(
                {
                    Console.WriteLine("No more guesses allowed. You Lost.");
                    m_IsRestart = restartGame();
                }
                if (m_IsQuit)
                {
                    Console.WriteLine("Bye Bye :(");
                }

             
            }
        }
        /// <summary>
        ///  restart the game
        /// </summary>
        private bool restartGame()
        {
            bool isInvalideChoose = true;
            bool isRestart = false;
            while (isInvalideChoose)
            {


                Console.WriteLine("Would you like to start a new game? <Y/N>");
                string chooseStr = Console.ReadLine();
                char choose;
                bool intResultTryParse = char.TryParse(chooseStr, out choose);

                if (intResultTryParse && choose.Equals('Y'))
                {
                    isRestart = true;
                    isInvalideChoose = false;

                    restartFields();
                }
                else if (intResultTryParse && choose.Equals('N'))
                {
                    Console.WriteLine("Bye Bye");
                    isInvalideChoose = false;
                    isRestart = false;
                }
                else
                {
                    Console.WriteLine("invalid input :(");
                }
            }
            return isRestart;

        }
        private void restartFields()
        {
            m_IsWin = false;
            m_IsQuit = false;
            m_Logic.SetComChoose("");
            m_UserGuessesList.Clear();
            m_PointsList.Clear();
        }
        private void printList(List<Guess> list)
        {
            foreach (Guess item in list)
            {
                Console.WriteLine(item.userGuess);
            }
        }
        private Guess getGuess()
        {
            bool isInputValid = false;
            Guess guess = null; // add '?'
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
                    if (numberOfGuessesStr.Equals("Q"))
                    {
                        guess = null;
                        isInputValid = true;
                    }
                    else
                    {
                        Console.WriteLine(ex.Message);
                    }
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
    //public class RangeException : Exception
    //{
    //    public RangeException(string message)
    //        : base(message)
    //    { }
    //}
    //public class TypeException : Exception
    //{ 
    //    public TypeException(string message)
    //        : base(message)
    //    { }
    //}
}
