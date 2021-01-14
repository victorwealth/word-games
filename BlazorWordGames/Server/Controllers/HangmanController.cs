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
        public WordDto Get()
        {
            return FetchWord();
        }

        [HttpGet]
        public WordDto FetchWord()
        {
            int random = new Random().Next(6) + 5;
            string selectedWord = _wordService.FetchUniqueWord(random);
            var clue = _clueService.FetchClue(selectedWord);

            var word = new WordDto() { SelectedWord = selectedWord, Count = selectedWord.Length, Clue = clue, DisplayClue = new string(clue) };

            return word;
        }

        [HttpPost]
        [Route("FetchClue")]
        public WordDto FetchClue([FromBody] WordDto word) => _clueService.FetchClueArray(word);

    }
}
