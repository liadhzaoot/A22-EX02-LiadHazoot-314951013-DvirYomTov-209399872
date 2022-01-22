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
        private List<string> m_ResultsList = new List<string>();
        private Logic m_Logic;
        private UI m_UI;

      
        public GameManager()
        {
            this.m_Logic = new Logic();
            this.m_UI = new UI();
        }
        public void GameManage()
        {
            string result = "";
            while (m_IsRestart && !m_IsQuit)
            {
                int numberOfGuesses = getNumberOfGuesses();
                string comChoose = m_Logic.ComChooseRandomly();                  
                for (int i = 0; i < numberOfGuesses; i++)
                {
                    m_UI.DrawBoard(ref m_UserGuessesList, ref m_ResultsList);
                    m_UserGuess = getGuess();
                    if (m_UserGuess == null)
                    {
                        m_IsQuit = true;
                        break;
                    }
                    m_UserGuessesList.Add(m_UserGuess); // add guess
                    result = m_Logic.BingoHit(m_UserGuessesList[m_UserGuessesList.Count - 1]);
                    m_ResultsList.Add(result); // add result 'X' OR 'V'
                    if (m_Logic.IsWin(result)) // check win
                    {
                        m_UI.DrawBoard(ref m_UserGuessesList, ref m_ResultsList);
                        UI.PrintMessage("You guessed after " + (i + 1) + " steps!");
                        m_IsRestart = restartGame();
                        m_IsWin = true;
                        break;
                    }
                }

                if (!m_IsWin && !m_IsQuit) // if the user Lose and not quit :(
                {
                    m_UI.DrawBoard(ref m_UserGuessesList, ref m_ResultsList);
                    UI.PrintMessage("No more guesses allowed. You Lost.");
                    m_IsRestart = restartGame();
                }
                if (m_IsQuit)
                {
                    UI.PrintMessage("Bye Bye :(");
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
                string chooseStr = m_UI.GetUserInput("Would you like to start a new game? <Y/N>");
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
                    UI.PrintMessage("Bye Bye");
                    isInvalideChoose = false;
                    isRestart = false;
                }
                else
                {
                    UI.PrintMessage("invalid input :(");
                }
            }
            return isRestart;

        }
        private void restartFields()
        {
            m_IsWin = false;
            m_IsQuit = false;
            this.m_UI.ClearBoard();
            m_Logic.SetComChoose("");
            m_UserGuessesList.Clear();
            m_ResultsList.Clear();
        }
     
        private Guess getGuess()
        {
            bool isInputValid = false;
            Guess guess = null; // add '?'
            guess = new Guess();
            while (!isInputValid)
            {
                string userGuess = m_UI.GetUserInput("\nPlease type your next guess or 'Q' to quit");
                try
                {
                    guess.userGuess = userGuess;
                    isInputValid = true;
                }
                catch (TypeException ex)
                {
                    UI.PrintMessage(ex.Message);
                }
                catch (RangeException ex)
                {
                    if (userGuess.Equals("Q"))
                    {
                        guess = null;
                        isInputValid = true;
                    }
                    else
                    {
                        UI.PrintMessage(ex.Message);
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
                string userGuess = m_UI.GetUserInput("Enter number of guesses between 4-10");
                try
                {
                    numberOfGuesses = numberOfGussesValidation(userGuess);
                    m_UI.SetBoardSize(numberOfGuesses);
                    isInputValid = true;
                }
                catch (TypeException ex)
                {
                    UI.PrintMessage(ex.Message);
                }
                catch (RangeException ex)
                {
                    UI.PrintMessage(ex.Message);
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

}
