using HangmanGame;
using System;


namespace HangmanTests
{
    public class HangmanTestsFixture : IDisposable
    {
        public Word Word { get; private set; }
        public Clue Clue { get; private set; }
        public Random random { get; private set; }

        public HangmanTestsFixture()
        {
            Word = new Word();
            Clue = new Clue();
            random = new Random();
        }
        public void Dispose()
        {
            Word.Dispose();
            Clue.Dispose();
        }
    }
}
