using BlazorWordGames.Server.Services.Hangman;
using System;


namespace HangmanTests
{
    public class HangmanTestsFixture : IDisposable
    {
        public WordService WordService { get; private set; }
        public ClueService ClueService { get; private set; }
        public Random random { get; private set; }

        public HangmanTestsFixture()
        {
            WordService = new WordService();
            ClueService = new ClueService();
            random = new Random();
        }
        public void Dispose()
        {
            WordService.Dispose();
            ClueService.Dispose();
        }
    }
}
