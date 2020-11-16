using HangmanGame;
using System;
using System.Collections.Generic;
using Xunit;

namespace HangmanTests
{
    public class HangmanTest
    {
        [Fact]
        public void Count_Occurence_Of_Alphabet_In_A_Word()
        {
            string word = "pizza";
            char alphabet = 'a';

             WordManager wordManager = new WordManager();

            int count = wordManager.CountAlphabet(word, alphabet);

            Assert.Equal(1, count);

        }

        [Fact]
        public void Length_Of_Fetched_Word_Random()
        {
            Random random = new Random();
            int requestedLength = random.Next(6) + 5;

            WordManager wordManager = new WordManager();
            wordManager.LoadWordsToMemory();
            string word = wordManager.FetchUniqueWord(requestedLength);

            Assert.True(requestedLength == word.Length);
        }

        [Fact]
        public void Test_Uniqueness_Of_Fetched_Word()
        {
            Random random = new Random();
            HashSet<string> usedWordsSet = new HashSet<string>();
            int round = 0;
            WordManager wordManager = new WordManager();
            wordManager.LoadWordsToMemory();

            while (round < 100)
            {
                int requestedLength = random.Next(6) + 5;
                string word = wordManager.FetchUniqueWord(requestedLength);
                round++;

                Assert.True(usedWordsSet.Add(word));
            }

        }
    }
}



