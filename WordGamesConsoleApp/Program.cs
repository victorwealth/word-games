using System;
using static System.Console;
using HangmanGame;
using System.Collections.Generic;

namespace WordGamesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var wordManager = new Word();
            var clueManager = new Clue();

            var random = new Random();
            int length = random.Next(6) + 5;

            var word = wordManager.FetchUniqueWord(length);
            var clue = clueManager.FetchClue(word);

            WriteLine("Welcome to Hangman Game!");
            WriteLine("========================");

            char keyPressed;
            WriteLine($"{word}");
            WriteLine($"{clue}");

            do
            {
                WriteLine("Enter a guess");
                keyPressed = ReadKey().KeyChar;
                WriteLine($"{clueManager.FetchClue(word, keyPressed)}");

            } while (keyPressed != '0');


            ReadKey();
        }
    }
}
