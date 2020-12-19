using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWordGames.Server.Services.Hangman
{
    public class ClueService : IDisposable
    {
        public char[] FetchClue(string word)
        {
            var clue = new char[word.Length];
            //var clue = new StringBuilder();
            int wordLength = word.Length;

            for (int i = 0; i < wordLength; i++)
            {
                //clue.Append("-");
                clue[i] = '-';
            }

            //return clue.ToString();

            return clue;
        }

        public string FetchClue(string word, char guess)
        {
            guess = char.ToLower(guess);
            if (guess < 'a' || guess > 'z') throw new ArgumentException("Invalid character");


            var sb = new StringBuilder();
            foreach (var character in word.ToCharArray())
            {
                if (char.ToLower(character) == guess)
                    sb.Append(guess);
                else
                    sb.Append("-");
            }

            return sb.ToString();
        }

        public char[] FetchClueArray(string word, char guess, char[] clue)
        {
            guess = char.ToLower(guess);
            var wordCharArray = word.ToCharArray();

            if (guess < 'a' || guess > 'z') throw new ArgumentException("Invalid character");

            for (int i = 0; i < word.Length; i++)
            {
                if (guess == char.ToLower(wordCharArray[i]))
                    clue[i] = guess;
            }

            return clue;

        }

        public void Dispose() { }

    }
}
