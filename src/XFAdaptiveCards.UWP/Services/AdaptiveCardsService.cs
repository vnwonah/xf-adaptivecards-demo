using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using XFAdaptiveCards.Interfaces;
using XFAdaptiveCards.UWP.Pages;

namespace XFAdaptiveCards.UWP.Services
{
    public class AdaptiveCardsService : IAdaptiveCardsService
    {
        public void DisplayCard(string cardJson)
        {
            var currentPage = Window.Current.Content as Frame;
            currentPage.Navigate(typeof(AdaptiveCardsPage), cardJson);
        }
    }
}
