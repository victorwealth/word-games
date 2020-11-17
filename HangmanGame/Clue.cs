using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanGame
{
    public class Clue : IDisposable
    {
        public string FetchClue(string word)
        {
            var clue = new StringBuilder();
            int wordLength = word.Length;

            for (int i = 0; i < wordLength; i++)
            {
                clue.Append("-");
            }

            return clue.ToString();
        }

        public string FetchClue(string word, char guess)
        {
            guess = char.ToLower(guess);
            if (guess < 'a' || guess > 'z') throw new ArgumentException("Invalid character");
            

            var sb = new StringBuilder();
            foreach (var character in word.ToCharArray())
            {
                if (character == guess)
                    sb.Append(guess);
                else
                    sb.Append("-");
            }

            return sb.ToString();
        }

        public void Dispose() { }
        
    }
}
