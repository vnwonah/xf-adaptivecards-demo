using XFAdaptiveCards.Interfaces;
using XFAdaptiveCards.Services;
using XFAdaptiveCards.UWP.Services;

namespace XFAdaptiveCards.UWP
{
    public sealed partial class MainPage
    {
        private static bool typesRegisterd = false;
        public MainPage()
        {
            this.InitializeComponent();
            if(!typesRegisterd)
                RegisterTypes();
            LoadApplication(new XFAdaptiveCards.App());
        }

        void RegisterTypes()
        {
            typesRegisterd = true;
            XFAdaptiveCards.App.RegisterType<ILogger, Logger>();
            XFAdaptiveCards.App.RegisterType<IAdaptiveCardsService, AdaptiveCardsService>();
            XFAdaptiveCards.App.BuildContainer();
        }
    }
}
