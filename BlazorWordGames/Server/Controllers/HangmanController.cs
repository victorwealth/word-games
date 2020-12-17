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
       private WordService _wordService;

        public HangmanController(WordService wordService)
        {
            _wordService = wordService;
        }

        [HttpGet]
        public Word Get()
        {
            int random = new Random().Next(6) + 5;
            string word = _wordService.FetchUniqueWord(random);
            return new Word() { SelectedWord = word, Count = word.Length };
        }
    }
}
