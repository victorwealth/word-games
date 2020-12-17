using System;
using System.Collections.Generic;
using System.IO;


namespace BlazorWordGames.Server.Services.Hangman
{
    public class WordService : IDisposable
    {
        private HashSet<string> _usedWordsSet = new HashSet<string>();

        private List<string> _wordsList;
        public List<string> WordsList
        {
            // Transient
            // List of words will not change frequently
            get
            {
                if (_wordsList != null) return _wordsList;
                else
                {
                    LoadWordsToMemory();
                    return _wordsList;
                }
            }
        }


        public int CountAlphabet(string word, char alphabet)
        {
            int count = 0;

            // this will run on Linear time O(n), but it's OK because
            // the longest word will not exceed 15 characters.
            foreach (var character in word.ToCharArray())
            {
                if (character == alphabet) count++;
            }

            return count;
        }

        private void LoadWordsToMemory()
        {
            _wordsList = new List<string>();
            string result;

            try
            {
                using StreamReader sr = new StreamReader(@"Data/WordSource.txt");
                while ((result = sr.ReadLine()) != null)
                {
                    _wordsList.Add(result);
                }
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException(e.Message);
            }
            catch (IOException e)
            {
                throw new IOException(e.Message);
            }
        }

        public string FetchUniqueWord(int requestedLength)
        {
            // traversing will run on Linear time O(n)
            foreach (var word in WordsList)
            {
                if (word.Length != requestedLength) continue;
                else if (_usedWordsSet.Add(word)) return word;
            }

            return null;
        }

        public void Dispose() { }
    }
}
