using BlazorWordGames.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWordGames.Client.Services.Hangman
{
    public class DataService
    {
        public string SelectedWord { get; set; }
        private readonly HttpClient http;

        public DataService(HttpClient httpClient)
        {
            http = httpClient;
        }

        public async Task<WordDto> GetWord()
        {
            return await http.GetFromJsonAsync<WordDto>($"api/Hangman");
        }

        public async Task<WordDto> FetchNextWord()
        {
            return await http.GetFromJsonAsync<WordDto>($"api/Hangman/FetchWord");
        }

        public async Task<WordDto> FetchClue(WordDto word)
        {
            var resp = await http.PostAsJsonAsync($"api/Hangman/FetchClue", word);
            return await resp.Content.ReadFromJsonAsync<WordDto>();
        }
    }
}

