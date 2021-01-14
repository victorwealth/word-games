using System.Collections.Generic;
using Xunit;

namespace HangmanTests
{
    public class WordServiceTests : IClassFixture<HangmanTestsFixture>
    {
        private readonly HangmanTestsFixture _fixture;

        public WordServiceTests(HangmanTestsFixture fixture)
        {
            _fixture = fixture;
        }

        
        [Fact]
        public void Count_Occurence_Of_Alphabet_In_A_Word()
        {
            string word = "pizza";
            char alphabet = 'a';
            int count = _fixture.WordService.CountAlphabet(word, alphabet);

            Assert.Equal(1, count);

        }

        [Fact]
        public void Length_Of_Fetched_Word_Random()
        {
            int requestedLength = _fixture.random.Next(6) + 5;
            string word = _fixture.WordService.FetchUniqueWord(requestedLength);

            Assert.True(requestedLength == word.Length);
        }

        [Fact]
        public void Test_Uniqueness_Of_Fetched_Word()
        {
            HashSet<string> usedWordsSet = new HashSet<string>();
            int round = 0;
            
            while (round < 100)
            {
                int requestedLength = _fixture.random.Next(6) + 5;
                string word = _fixture.WordService.FetchUniqueWord(requestedLength);
                round++;

                Assert.True(usedWordsSet.Add(word));
            }

        }
    }
}




