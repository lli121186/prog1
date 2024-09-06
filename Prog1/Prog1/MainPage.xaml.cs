using System.Text.RegularExpressions;

namespace UserRegistrationApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            string name = NameEntry.Text;
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;
            string confirmPassword = ConfirmPasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                ErrorMessage.Text = "Bitte fülle alle Felder aus.";
                ErrorMessage.IsVisible = true;
                SuccessMessage.IsVisible = false;
                return;
            }

            if (!IsValidEmail(email))
            {
                ErrorMessage.Text = "Bitte gib eine gültige E-Mail-Adresse ein.";
                ErrorMessage.IsVisible = true;
                SuccessMessage.IsVisible = false;
                return;
            }

            if (password != confirmPassword)
            {
                ErrorMessage.Text = "Die Passwörter stimmen nicht überein.";
                ErrorMessage.IsVisible = true;
                SuccessMessage.IsVisible = false;
                return;
            }

            ErrorMessage.IsVisible = false;
            SuccessMessage.Text = "Registrierung erfolgreich!";
            SuccessMessage.IsVisible = true;
        }

        private bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }
    }
}
