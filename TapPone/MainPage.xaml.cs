using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace TapPone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int clickCount;
        Random random = new Random();
        BitmapImage bitmapImage = new BitmapImage();
       // MediaPlayer a = Windows.Media.Playback.MediaPlayer;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            rootpage.AddHandler(UIElement.PointerPressedEvent, new PointerEventHandler(mainpage_clicked), false);
            
            BitmapImage bitmapImage1 = new BitmapImage();
            Uri uri = new Uri("ms-appx:///images/avatar/" + random.Next(0, 11) + ".png");
            bitmapImage1.UriSource = uri;

            avatar.Source = bitmapImage1;

            
        }

        private void mainpage_clicked(object sender, PointerRoutedEventArgs e)
        {
            //throw new NotImplementedException();
            clickCount++;

            if (clickCount % 15 == 0)
            {
                Uri uri = new Uri("ms-appx:///images/monsters/" + random.Next(0, 14) + ".png");
                bitmapImage.UriSource = uri;

                monster.Source = bitmapImage; //(random.Next(0, 10) + ".png");
            }
            statusTxt.Text = "click " + clickCount + " times";
            storyboard.Begin();
            //CompositeTransform scale = new CompositeTransform()
            //{
            //    ScaleX = 0.9,
            //    ScaleY = 0.9,
            //};
            //monster.RenderTransform = scale;
            //monster.RenderTransform = null;

            //<Image x:Name="monster" HorizontalAlignment="Left" Height="310" Margin="36,103,0,0" VerticalAlignment="Top" Width="329" Source="images/monsters/9.png" RenderTransformOrigin="0.5,0.5">
            //    <Image.RenderTransform>
            //        <CompositeTransform ScaleX="0.9"/>
            //    </Image.RenderTransform>
            //</Image>
           // mediaplayer.Play();

        }

        //public void Vibrate(long durationSeconds)
        //{
        //    VibrateController vibController = VibrateController.Default;
        //    TimeSpan ts = new TimeSpan(00, 00, durationSeconds);

        //    vibController.Start(ts);
        //}

        //public static void VibrateStop()
        //{
        //    VibrateController vibController = VibrateController.Default;
        //    vibController.Stop();
        //}


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
    }
}
