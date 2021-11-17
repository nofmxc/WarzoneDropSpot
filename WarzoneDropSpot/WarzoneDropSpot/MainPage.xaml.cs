using System;
using Xamarin.Forms;

namespace WarzoneDropSpot
{
    public partial class MainPage : ContentPage
    {
        private string _ButtonText = "Press for drop spot. Geronimo!";
        public string ButtonText
        {
            get { return _ButtonText; }
            set 
            { 
                _ButtonText = value;
                OnPropertyChanged(nameof(ButtonText)); // Notify that there was a change on this property
            }
        }
        private double _XPos;
        public double XPos
        {
            get { return _XPos; }
            set
            {
                _XPos = value;
                OnPropertyChanged(nameof(XPos)); // Notify that there was a change on this property
            }
        }
        private double _YPos;
        public double YPos
        {
            get { return _YPos; }
            set
            {
                _YPos = value;
                OnPropertyChanged(nameof(YPos)); // Notify that there was a change on this property
            }
        }
        private bool _CrosshairEnabled;
        public bool CrosshairEnabled
        {
            get { return _CrosshairEnabled; }
            set
            {
                _CrosshairEnabled = value;
                OnPropertyChanged(nameof(CrosshairEnabled)); // Notify that there was a change on this property
            }
        }
        private bool _ButtonEnabled = true;
        public bool ButtonEnabled
        {
            get { return _ButtonEnabled; }
            set
            {
                _ButtonEnabled = value;
                OnPropertyChanged(nameof(ButtonEnabled)); // Notify that there was a change on this property
            }
        }

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            XPos = new Random().NextDouble();
            YPos = new Random().NextDouble();
            CrosshairEnabled = true;
            ButtonText = "Don't second guess it!";
            ButtonEnabled = false;
        }
    }
}
