using Android.Content;
using XFAdaptiveCards.Interfaces;

namespace XFAdaptiveCards.Droid.Services
{
    public class AdaptiveCardsService : IAdaptiveCardsService
    {
        public void DisplayCard(string cardJson)
        {
            var intent = new Intent(Android.App.Application.Context, typeof(AdaptiveCardsActivity));
            intent.AddFlags(ActivityFlags.NewTask);
            Android.App.Application.Context.StartActivity(intent);
        }
    }
}