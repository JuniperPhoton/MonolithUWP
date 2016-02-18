using Lousy.Mon;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;


namespace Monolith_UWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void StartAnimBtn_Click(object sender, RoutedEventArgs e)
        {
            // Create an ease for use with animations later
            ExponentialEase ExpEaseOut =
                new ExponentialEase() { EasingMode = EasingMode.EaseOut };

            // Animate a UIElement along the X axis from 0 to 40
            Oli.MoveXOf(rect).From(0).To(40).For(0.3, OrSo.Secs).Now();

            // Rotate UIElement to 90 degrees 
            EventToken rotating =
                Oli.Rotate(rect).To(90).For(0.3, OrSo.Secs).With(ExpEaseOut).Now();

            // Fade the opacity to 0 after the rotation finishes
            Oli.Fade(rect).To(0).For(0.3, OrSo.Secs).With(ExpEaseOut).After(rotating);

            // Run arbitrary code after the rotation too!
            Oli.Run(() =>
            {
                // Do things here!
            }).After(rotating);
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            var transform = rect.RenderTransform as CompositeTransform;
            if(transform!= null)
            {
                transform.TranslateX = 0;
                transform.Rotation = 0;
                rect.Opacity = 1;
            }
        }
    }
}
