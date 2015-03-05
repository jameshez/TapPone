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
using Windows.Phone.Devices.Notification;

namespace TapPone
{
    public sealed partial class MainPage : Page
    {
        private int attack_this_monster = 0;
        Random random = new Random();
        BitmapImage bitmapImage = new BitmapImage();

        private long monster_hp_max = 390;
        private long attack_power = 15;
        private long life_click = 0;
        private long gold = 0;

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
            attack_this_monster++;
            life_click++;

            long temp_left_hp = monster_hp_max - attack_this_monster * attack_power;

            if (temp_left_hp <= 0)
            {
                Uri uri = new Uri("ms-appx:///images/monsters/" + random.Next(1, 14) + ".png");
                bitmapImage.UriSource = uri;

                monster.Source = bitmapImage;
                statusTxt.Text += "打败一个怪兽，掉落28金币\n";
                Vibrate();
                attack_this_monster = 0;
                monster_hp.Width = 250;

                gold += 28;
            }
            else
            {
                monster_hp.Width = 250 * temp_left_hp / monster_hp_max;
            }

            storyboard.Begin();
        }

        public void Vibrate()
        {
            //VibrateController vibController = VibrateController.Default;
            VibrationDevice testVibrationDevice = VibrationDevice.GetDefault();
            testVibrationDevice.Vibrate(TimeSpan.FromSeconds(0.1));
            //testVibrationDevice.Cancel();
        }

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Flyout a = new Flyout(;)
        }
    }
}
