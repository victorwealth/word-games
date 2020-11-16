using System;
using System.Collections.Generic;
using System.IO;

namespace HangmanGame
{
    public class WordManager
    {
        private HashSet<string> _usedWordsSet = new HashSet<string>();
        private List<string> _wordsList;


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

        public void LoadWordsToMemory()
        {
            _wordsList = new List<string>();
            string result;

            try
            {
                StreamReader sr = new StreamReader(@"WordSource.txt");
                while ((result = sr.ReadLine()) != null)
                {
                    _wordsList.Add(result);
                }
            }
            catch (FileNotFoundException e)
            {
                throw;
            }
            catch (IOException e)
            {
                throw;
            }
        }

        public string FetchUniqueWord(int requestedLength)
        {
            foreach (var word in _wordsList)
            {
                if (word.Length != requestedLength) continue;
                else if (_usedWordsSet.Add(word)) return word;
            }

            return null;
        }
    }
}

