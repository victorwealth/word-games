﻿using HangmanGame;
using System;
using System.Text;
using Xunit;

namespace HangmanTests
{
    public class ClueTests : IClassFixture<HangmanTestsFixture>
    {
        private readonly HangmanTestsFixture _fixture;
        public ClueTests(HangmanTestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void FetchClue_Prints_Dashes_To_Match_Word()
        {
            int requestedLength = _fixture.random.Next(6) + 5;
            var expected = new StringBuilder();

            for (int i = 0; i < requestedLength; i++)
            {
                expected.Append("-");
            }

            string word = _fixture.Word.FetchUniqueWord(requestedLength);
            string clue = _fixture.Clue.FetchClue(word);

            Assert.Equal(expected.ToString(), clue);
        }

        [Fact]
        public void FetchClue_Replaces_Dashes_With_Correct_Guess()
        {
            string word = "pizza";
            char guess = 'z';

            var result = _fixture.Clue.FetchClue(word, guess);

            Assert.Equal("--zz-", result);
        }

        [Fact]
        public void FetchClue_After_InCorrect_Guess()
        {
            string word = "pizza";
            char guess = 'o';

            var result = _fixture.Clue.FetchClue(word, guess);

            Assert.Equal("-----", result);
        }
    }
}
