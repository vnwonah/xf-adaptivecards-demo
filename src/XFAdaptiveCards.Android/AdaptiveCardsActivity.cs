using AdaptiveCards.Rendering.Xamarin.Android.ObjectModel;
using AdaptiveCards.Rendering.Xamarin.Android.Renderer;
using AdaptiveCards.Rendering.Xamarin.Android.Renderer.ActionHandler;
using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Widget;

namespace XFAdaptiveCards.Droid
{
    [Activity(Label = "Adaptive Card")]
    public class AdaptiveCardsActivity : FragmentActivity, ICardActionHandler
    {
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AdaptiveCards);
        }

        protected override void OnStart()
        {
            var cardJson = Intent.GetStringExtra("cardJson");
            RenderAdaptiveCard(cardJson, true);
            base.OnStart();
        }

        private void RenderAdaptiveCard(string jsonText, bool showErrorToast)
        {
            try
            {
                ParseResult parseResult = AdaptiveCard.DeserializeFromString(jsonText, AdaptiveCardRenderer.Version);
                Toast.MakeText(this, parseResult.AdaptiveCard.Body.Capacity().ToString(), ToastLength.Short).Show();
                LinearLayout layout = (LinearLayout)FindViewById(Resource.Id.visualAdaptiveCardLayout);
                layout.RemoveAllViews();

                var renderedCard = AdaptiveCardRenderer.Instance.Render(Application.Context, SupportFragmentManager, parseResult.AdaptiveCard, this, new HostConfig());
                layout.AddView(renderedCard.View);
            }
            catch (Java.IO.IOException ex)
            {
                if (showErrorToast)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
                }
            }
        }

        public void OnAction(BaseActionElement p0, RenderedAdaptiveCard p1)
        {
        }

        public void OnMediaPlay(BaseCardElement p0, RenderedAdaptiveCard p1)
        {
        }

        public void OnMediaStop(BaseCardElement p0, RenderedAdaptiveCard p1)
        {
        }
    }
}