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

namespace TapPone
{
    public sealed partial class MainPage : Page
    {
        private int clickCount;
        Random random = new Random();
        BitmapImage bitmapImage = new BitmapImage();

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            rootpage.AddHandler(UIElement.PointerPressedEvent, new PointerEventHandler(mainpage_clicked), false);
            
            BitmapImage bitmapImage1 = new BitmapImage();
            Uri uri = new Uri("ms-appx:///images/avatar/" + random.Next(1, 11) + ".png");
            bitmapImage1.UriSource = uri;

            avatar.Source = bitmapImage1;

            monster_hp.Width = 250;

        }

        private void mainpage_clicked(object sender, PointerRoutedEventArgs e)
        {
            clickCount++;
            monster_hp.Width = 250 - clickCount % 15 * 250 / 15;
            if (clickCount % 15 == 0)
            {
                Uri uri = new Uri("ms-appx:///images/monsters/" + random.Next(1, 14) + ".png");
                bitmapImage.UriSource = uri;

                monster.Source = bitmapImage; 
            }
            
            storyboard.Begin();
            

        }

       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Flyout a = new Flyout(;)
        }
    }
}
