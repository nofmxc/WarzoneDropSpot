using System;
using Xamarin.Forms;

namespace WarzoneDropSpot
{
    public partial class MainPage : ContentPage
    {
        private double _xPos;
        public double xPos
        {
            get { return _xPos; }
            set
            {
                _xPos = value;
                OnPropertyChanged(nameof(xPos)); // Notify that there was a change on this property
            }
        }
        private double _yPos;
        public double yPos
        {
            get { return _yPos; }
            set
            {
                _yPos = value;
                OnPropertyChanged(nameof(yPos)); // Notify that there was a change on this property
            }
        }
        private bool _crosshairEnabled;
        public bool crosshairEnabled
        {
            get { return _crosshairEnabled; }
            set
            {
                _crosshairEnabled = value;
                OnPropertyChanged(nameof(crosshairEnabled)); // Notify that there was a change on this property
            }
        }

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            xPos = new Random().NextDouble();
            yPos = new Random().NextDouble();
            crosshairEnabled = true;
        }
    }
}
