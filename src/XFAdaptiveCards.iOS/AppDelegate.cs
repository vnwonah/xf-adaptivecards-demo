using Foundation;
using UIKit;
using XFAdaptiveCards.Interfaces;
using XFAdaptiveCards.Services;

namespace XFAdaptiveCards.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            RegisterTypes();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }

        void RegisterTypes()
        {
            App.RegisterType<ILogger, Logger>();
            App.BuildContainer();
        }
    }


}
