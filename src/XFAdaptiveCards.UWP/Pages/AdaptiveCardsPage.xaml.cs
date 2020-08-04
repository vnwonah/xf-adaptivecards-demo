using AdaptiveCards.Rendering.Uwp;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace XFAdaptiveCards.UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdaptiveCardsPage : Page
    {
        public AdaptiveCardsPage()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            currentView.BackRequested += CurrentView_BackRequested;
        }

        private void CurrentView_BackRequested(object sender, BackRequestedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }
       
        private void RenderAdaptiveCard(string jsonString)
        {
            var renderer = new AdaptiveCardRenderer();
            var card = AdaptiveCard.FromJsonString(jsonString);
            RenderedAdaptiveCard renderedAdaptiveCard = renderer.RenderAdaptiveCard(card.AdaptiveCard);
            if (renderedAdaptiveCard.FrameworkElement != null)
            {
                // Get the framework element
                var uiCard = renderedAdaptiveCard.FrameworkElement;

                // Add it to your UI
                cardsGrid.Children.Add(uiCard);
            }
        }
    }
}
