using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using IoT.Factory;
using System.Threading.Tasks;


namespace IoT
{
    //TODO Add forecast functionality
    public sealed partial class MainPage : Page
    {
        public MainPage()
        { 
            this.InitializeComponent();
            DateTime date = DateTime.Today;
            WelDate.Text = "Hello user, today is a " + (date.DayOfWeek.ToString());
            getWeather();
        }

       private async void getWeather()
        {
            RootObject myWeather = await CurrentWeather.GetWeather();
            WelWeather.Text = "It is currently " + Math.Round((((myWeather.main.temp - 273) * 1.8) +32))+ " degrees outside";
        }
    }
}
