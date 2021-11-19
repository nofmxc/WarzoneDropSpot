using System;
using Xamarin.Forms;

namespace WarzoneDropSpot
{
    public partial class MainPage : ContentPage
    {
        private const int originalSecondsToWait = 60;
        private int secondsToWait = originalSecondsToWait;
        private const string OriginalButtonText = "Press for drop spot";
        private const string DropModifierTextTemplate = "Drop Modifier: {0}";
        private const string WaitingButtonText = "Don't second guess it!";
        private const string ButtonHintTextTemplate = "(Next drop allowed in {0} seconds)";
        private string _ModifierText = string.Empty;
        public string ModifierText
        {
            get { return _ModifierText; }
            set
            {
                _ModifierText = value;
                OnPropertyChanged(nameof(ModifierText)); // Notify that there was a change on this property
            }
        }
        private string _ButtonText = OriginalButtonText;
        public string ButtonText
        {
            get { return _ButtonText; }
            set
            {
                _ButtonText = value;
                OnPropertyChanged(nameof(ButtonText)); // Notify that there was a change on this property
            }
        }
        private string _ButtonHintText = "";
        public string ButtonHintText
        {
            get { return _ButtonHintText; }
            set
            {
                _ButtonHintText = value;
                OnPropertyChanged(nameof(ButtonHintText)); // Notify that there was a change on this property
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
        private bool _ButtonHintEnabled = false;
        public bool ButtonHintEnabled
        {
            get { return _ButtonHintEnabled; }
            set
            {
                _ButtonHintEnabled = value;
                OnPropertyChanged(nameof(ButtonHintEnabled)); // Notify that there was a change on this property
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
            ButtonText = WaitingButtonText;
            ButtonHintEnabled = true;
            ButtonHintText = string.Format(ButtonHintTextTemplate, secondsToWait);
            ButtonEnabled = false;
            ModifierText = string.Format(DropModifierTextTemplate, GetRandomDropModifier());
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                // do something every 1 second
                Device.BeginInvokeOnMainThread(() =>
                {
                    // interact with UI elements
                    CountDownButton();
                });

                if(secondsToWait <= 1)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        // interact with UI elements
                        ResetDrop();
                    });
                    return false; // Done with timer, so return false
                }
                return true; // runs again until we get to 0
            });
        }

        void ResetDrop()
        {
            ButtonText = OriginalButtonText;
            ButtonEnabled = true;
            ButtonHintEnabled = false;
            secondsToWait = originalSecondsToWait;
            CrosshairEnabled = false;
            ModifierText = string.Empty;
        }
        void CountDownButton()
        {
            secondsToWait--;
            ButtonHintText = string.Format(ButtonHintTextTemplate, secondsToWait);
        }

        public string GetRandomDropModifier()
        {
            int randomVal = new Random().Next(1, 100);
            switch (randomVal)
            {
                case int n when 0 < n && n <= 18:
                    return "Recon Contract"; 
                case int n when 18 < n && n <= 36:
                    return "Bounty Contract";
                case int n when 36 < n && n <= 40:
                    return "Most Wanted Contract";
                case int n when 40 < n && n <= 58:
                    return "Scavenger Contract";
                case int n when 58 < n && n <= 66:
                    return "Supply Run Contract";
                case int n when 66 < n && n <= 78:
                    return "Hot Drop";
                case int n when 78 < n && n <= 90:
                    return "Slow Drop";
                default:
                    return "None";
            }
        }
    }
}
