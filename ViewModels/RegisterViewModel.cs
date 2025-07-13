using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using TransRD.Models;
using TransRD.Database;

namespace TransRD.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        DB DataContext = new DB();

        [ObservableProperty]
        private string fullName;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string confirmPassword;

        [ObservableProperty]
        private bool acceptTerms;

        public RegisterViewModel()
        {
            
        }

        [RelayCommand]
        private async Task RegisterAsync()
        {
            if (string.IsNullOrWhiteSpace(FullName) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor completa todos los campos.", "OK");
                return;
            }

            if (Password != ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
                return;
            }

            if (!AcceptTerms)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes aceptar los términos y condiciones.", "OK");
                return;
            }

      // Aquí va la lógica de registro real
            User user = new User { nombre = FullName, email = email, contraseña = password };

            DataContext.Usuario.Add(user);
            DataContext.SaveChanges();

            await Application.Current.MainPage.DisplayAlert("Éxito", "Usuario registrado correctamente.", "OK");
            Navigate.NavigateToPage(new Views.LoginPage(),false);
        }

        [RelayCommand]
        private async Task NavigateToLoginAsync()
        {
            Navigate.NavigateToPage(new Views.LoginPage(),false);
        }
    }
}
