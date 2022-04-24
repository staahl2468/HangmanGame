using System;

namespace HangmanGame
{
    internal class Program
    {
        
        // The running program.
        static void Main(string[] args)
        {
            // Change to your own file location
            string filepath = @"C:\Users\staah\source\repos\HangmanGame\EnglishWords.txt";
            string[] Englishwords = File.ReadAllLines(filepath);
            char[] Wordarray = RandomWord(Englishwords);
            char[] Guessed = MakeGuessed(Wordarray);
            Console.WriteLine(Guessed);
            int Mistakecounter = 0;
            int Win = 0;
            do
            {
                char Currentguess = TakeGuess();
                Guessed = Compare(Currentguess, Wordarray, Guessed);
                Console.WriteLine(Guessed);
                Mistakecounter = MistakeCounter(Currentguess, Wordarray, Mistakecounter);
                Win = CheckForWin(Guessed, Wordarray, Win);
            }while(Mistakecounter < 10 && Win == 0);
            if (Win != 0)
            {
                Console.WriteLine("YOU WIN!!!");
            }
            else
            {
                Console.WriteLine("GAME OVER");
            }
        }

        // Picks a random string from a text file, and makes it into an array.
        public static char[] RandomWord(string[] words)
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 5000);

            string word = $"{words[num]}";
            char[] wordarray = new char [word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                wordarray[i] = word[i];
            }
            return wordarray;
        }

        // Changing all char's in the word to "_". This is what will be displayed to the user.
        public static char[] MakeGuessed(char[] word)
        {
            char[] guessed = new char [word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                guessed[i] = Convert.ToChar("_");
            }
            return guessed;
        }

        // Asks the user for a guess and returns their guess in a char.
        public static char TakeGuess()
        {
            Console.WriteLine("Take a guess");
            return Convert.ToChar(Console.ReadLine());
        }

        // Updates the array "Guessed".
        public static char[] Compare(char guess, char[] word, char[] guessed)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (guess == word[i])
                {
                    guessed[i] = guess;
                }
            }
            return guessed;
        }

        // If the word doesn't contain their guess, the mistake counter will go up.
        public static int MistakeCounter(char guess, char[] word, int counter)
        {
            if (!word.Contains(guess))
            {
                return counter += 1;
            }
            else
            {
                return counter;
            }
        }

        // If all the char's in "Guessed" and "Wordarray" are the same, it will change "Win" to 1.
        public static int CheckForWin(char[] guessed, char[] word, int win)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (guessed[i] == word[i])
                {
                    win += 1;
                }
            }
            if (win == word.Length)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}