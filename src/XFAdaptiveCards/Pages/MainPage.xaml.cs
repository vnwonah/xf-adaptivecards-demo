using Xamarin.Forms;
using XFAdaptiveCards.PageModels;

namespace XFAdaptiveCards.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new MainPageModel();

        }
    }
}