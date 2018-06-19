using DarkSkyApi;
using DarkSkyApi.Models;
using System;
using System.Globalization;
using System.Threading;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace IoT
{
    //TODO Add forecast functionality
    //TODO Make background change with weather
    public sealed partial class MainPage : Page
    {
        public MainPage()
        { 
            this.InitializeComponent();
            SetWeather();
            SetWelcome();
            DispatcherTimer Timer = new DispatcherTimer();
            DataContext = this;
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

       private async void SetWeather()
        {
            //Getting Weather information
            var client = new DarkSkyService("31f7fea674b8a860e4ca1094783c554b");
            Forecast myWeather = await client.GetWeatherDataAsync(42.828422, -73.733340);
            int temperature =(int) Math.Round( myWeather.Currently.Temperature);
            RightTemp.Text = temperature.ToString()+"°F";

            //Setting Weather Icon based off conditions
            Image img = new Image();
            BitmapImage bitmapImage = new BitmapImage();
            Uri uri;

            //Switch to determine weather icon
            switch (myWeather.Currently.Icon)
            {
                case "clear-day":
                    uri = new Uri("ms-appx:///Assets/Icons/sunny.png");
                    bitmapImage.UriSource = uri;
                    WeatherIcon.Source = bitmapImage;
                    break;

                case "clear-night":
                    uri = new Uri("ms-appx:///Assets/Icons/night.png");
                    bitmapImage.UriSource = uri;
                    WeatherIcon.Source = bitmapImage;
                    break;

                case "partly-cloudy-day":
                    uri = new Uri("ms-appx:///Assets/Icons/partly-cloudy.png");
                    bitmapImage.UriSource = uri;
                    WeatherIcon.Source = bitmapImage;
                    break;

                case "partly-cloudy-night":
                    uri = new Uri("ms-appx:///Assets/Icons/partly-cloudy-night.png");
                    bitmapImage.UriSource = uri;
                    WeatherIcon.Source = bitmapImage;
                    break;

                case "cloudy":
                    uri = new Uri("ms-appx:///Assets/Icons/cloudy.png");
                    bitmapImage.UriSource = uri;
                    WeatherIcon.Source = bitmapImage;
                    break;

                case "rain":
                    uri = new Uri("ms-appx:///Assets/Icons/rain.png");
                    bitmapImage.UriSource = uri;
                    WeatherIcon.Source = bitmapImage;
                    break;

                case "sleet":
                    uri = new Uri("ms-appx:///Assets/Icons/sleet.png");
                    bitmapImage.UriSource = uri;
                    WeatherIcon.Source = bitmapImage;
                    break;

                case "snow":
                    uri = new Uri("ms-appx:///Assets/Icons/snow.png");
                    bitmapImage.UriSource = uri;
                    WeatherIcon.Source = bitmapImage;
                    break;

                case "wind":
                    uri = new Uri("ms-appx:///Assets/Icons/windy.png");
                    bitmapImage.UriSource = uri;
                    WeatherIcon.Source = bitmapImage;
                    break;

                case "fog":
                    uri = new Uri("ms-appx:///Assets/Icons/fog.png");
                    bitmapImage.UriSource = uri;
                    WeatherIcon.Source = bitmapImage;
                    break;
            }


            
           
        }

        public void SetWelcome()
        {
            DateTime date = DateTime.Today;
            WelDate.Text = "Hello user, today is a " + (date.DayOfWeek.ToString());
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month);
            Date.Text = monthName +" " + date.Day.ToString() +" , " +date.Year.ToString();

        }

      private void Timer_Tick(object sender, object e)
        {
            Clock.Text = DateTime.Now.ToString("h:mm:ss tt");
        }
    }
}
