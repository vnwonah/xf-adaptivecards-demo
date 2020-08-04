using Acr.UserDialogs;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFAdaptiveCards.Enums;
using XFAdaptiveCards.Interfaces;

namespace XFAdaptiveCards.PageModels
{
    public class MainPageModel
    {
        public ICommand ButtonClickedCommand { get; set; }
        private readonly IAdaptiveCardsService _adaptiveCardsService;
        private HttpClient _client;

        public MainPageModel()
        {
            ButtonClickedCommand = new Command<AdaptiveCards>(async (cardType) => await ButtonClicked(cardType));
            _adaptiveCardsService = DependencyService.Resolve<IAdaptiveCardsService>();
            _client = new HttpClient { Timeout = TimeSpan.FromMilliseconds(2) };

        }

        async Task ButtonClicked(AdaptiveCards cardType)
        {
            string cardJson = null;
            switch(cardType)
            {
                case AdaptiveCards.FlightItenerary:
                    cardJson = await GetCardJson(AppConfig.FLIGHT_ITENERARY_URL);
                    break;
                case AdaptiveCards.FoodOrder:
                    cardJson = await GetCardJson(AppConfig.FLIGHT_ITENERARY_URL);
                    break;
            }
            if (!string.IsNullOrWhiteSpace(cardJson))
                _adaptiveCardsService.DisplayCard(cardJson);
        }

        private async Task<string> GetCardJson(string url)
        {
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            await UserDialogs.Instance.AlertAsync("An error occured downloding card, check network", "Download Error", "Close");
            return null;
        }
    }
}
