using Microsoft.Maui.Controls;

namespace TransRD.Controls
{
    public partial class PasswordEntry : ContentView
    {
        public static readonly BindableProperty PasswordProperty =
            BindableProperty.Create(
                nameof(Password),
                typeof(string),
                typeof(PasswordEntry),
                string.Empty,
                BindingMode.TwoWay
            );

        public string Password
        {
            get => (string)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(
                nameof(Placeholder),
                typeof(string),
                typeof(PasswordEntry),
                string.Empty
            );

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        private bool _isPasswordHidden = true;
        public bool IsPasswordHidden
        {
            get => _isPasswordHidden;
            set
            {
                if (_isPasswordHidden != value)
                {
                    _isPasswordHidden = value;
                    OnPropertyChanged(nameof(IsPasswordHidden));
                    OnPropertyChanged(nameof(EyeIcon));
                }
            }
        }

        public string EyeIcon => IsPasswordHidden ? "visibilityoff_icon.png" : "visibility_icon.png";
       
        public PasswordEntry()
        {
            InitializeComponent();

        }

        private void OnTogglePasswordVisibility(object sender, EventArgs e)
        {
            IsPasswordHidden = !IsPasswordHidden;
        }

        
    }
}
