using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorWordGames.Shared
{
    public class Word
    {
        public string SelectedWord { get; set; }
        public int Count { get; set; }
        public char[] Clue { get; set; }
        public char Guess { get; set; }
        public string DisplayClue { get; set; }
    }
}

