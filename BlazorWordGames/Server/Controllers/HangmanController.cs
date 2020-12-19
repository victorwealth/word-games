using BlazorWordGames.Server.Services.Hangman;
using BlazorWordGames.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWordGames.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangmanController : ControllerBase
    {
       private readonly WordService _wordService;
       private readonly ClueService _clueService;

        public HangmanController(WordService wordService, ClueService clueService)
        {
            _wordService = wordService;
            _clueService = clueService;
        }

        [HttpGet]
        [Route("GetWord")]
        public Word Get()
        {
            return FetchWord();
        }

        [HttpGet]
        public Word FetchWord()
        {
            int random = new Random().Next(6) + 5;
            string word = _wordService.FetchUniqueWord(random);
            var clue = _clueService.FetchClue(word);

            return new Word() { SelectedWord = word, Count = word.Length, Clue = clue, DisplayClue = new string(clue) };
        }

        [HttpPost]
        [Route("FetchClue")]
        public Word FetchClue([FromBody] Word word)
        {
            var clue = _clueService.FetchClueArray(word.SelectedWord, word.Guess, word.Clue);
            word.Clue = clue;
            word.DisplayClue = new string(clue);

            return word;
        }
    }
}
