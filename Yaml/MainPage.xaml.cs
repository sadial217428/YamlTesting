using System.Net.Http.Json;

namespace Yaml
    {
    public partial class MainPage : ContentPage
        {
        int count = 0;
        private readonly HttpClient _httpClient;

        public MainPage()
            {
            InitializeComponent(); _httpClient = new HttpClient();
            }

        private async void OnCounterClicked(object sender, EventArgs e)
            {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

            await PostDataToApiAsync();
            }


        private async Task PostDataToApiAsync()
            {
            var requestUrl = "https://66e41eb2d2405277ed1327ba.mockapi.io/api/v1/users";  // Your API URL

            // Create data with DateTime stamp
            var data = new
                {
                name = $"Action at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}"  // Adding DateTime stamp
                };

            try
                {
                var response = await _httpClient.PostAsJsonAsync(requestUrl, data);

                if (response.IsSuccessStatusCode)
                    {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Data posted successfully: {result}");
                    }
                else
                    {
                    Console.WriteLine($"Error posting data: {response.StatusCode}");
                    }
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }


    }
