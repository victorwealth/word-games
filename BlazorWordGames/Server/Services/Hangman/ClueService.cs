using BlazorWordGames.Shared;
using System;
using System.Text;

namespace BlazorWordGames.Server.Services.Hangman
{
    public class ClueService : IDisposable
    {
        public char[] FetchClue(string word)
        {
            var clue = new char[word.Length];
            int wordLength = word.Length;

            for (int i = 0; i < wordLength; i++)
            {
                clue[i] = '-';
            }

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

        public WordDto FetchClueArray(WordDto word)
        {
            var guess = char.ToLower(word.Guess);
            var wordCharArray = word.SelectedWord.ToCharArray();

            if (guess < 'a' || guess > 'z') throw new ArgumentException("Invalid character");

            for (int i = 0; i < word.SelectedWord.Length; i++)
            {
                if (guess == char.ToLower(wordCharArray[i]))
                    word.Clue[i] = guess;
            }

            
            word.DisplayClue = new string(word.Clue);

            return word;

        }

        public void Dispose() { }

    }
}
