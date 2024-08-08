
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        const string script = @"
  window.addEventListener('message', (event) => {
    const data = event.data;
    window.webkit.messageHandlers.nativeApp.postMessage(data);
  });
";

        public MainPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            string text = "This is a Toast";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(text, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
        }

        private async Task InjectJSEventListener()
        {
            await TWebView.EvaluateJavaScriptAsync(script);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            TWebView.Reload();
            
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if( TWebView.CanGoForward)
                TWebView.GoForward();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            if( TWebView.CanGoBack)
                TWebView.GoBack();
        }
    }

}
