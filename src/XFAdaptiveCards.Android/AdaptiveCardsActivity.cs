
using Android.App;
using Android.OS;

namespace XFAdaptiveCards.Droid
{
    [Activity(Label = "AdaptiveCardsActivity")]
    public class AdaptiveCardsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AdaptiveCards);
        }
    }
}