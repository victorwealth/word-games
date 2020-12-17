﻿using BlazorWordGames.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWordGames.Client.Services.Hangman
{
    public class DataService
    {
        public string SelectedWord { get; set; }
        private HttpClient http;

        public DataService(HttpClient httpClient)
        {
            http = httpClient;
        }

        public async Task<Word> GetWord()
        {
            return await http.GetFromJsonAsync<Word>($"api/Hangman");
        }
    }
}