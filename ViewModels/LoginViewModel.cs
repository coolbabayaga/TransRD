// LoginViewModel.cs
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.Maui.Controls;
using TransRD.Models;
using TransRD.Database;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace TransRD.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string? password;

        public DB DataContext = new DB();

        public LoginViewModel()
        {
            // Constructor
        }

        [RelayCommand]
        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

      // Autenticación simulada

            var LoginUsuario = DataContext.Usuario
                .Where(u => u.email == Email)
                .Where(u => u.contraseña == Password)
                .FirstOrDefault();

            if (LoginUsuario != null) //TODO:  check user existance
            {
                await Application.Current.MainPage.DisplayAlert("Bienvenido", "Inicio de sesión exitoso", "OK");
                Navigate.NavigateToPage(new Views.SplashPage(), false);
                // Navegar a la página principal
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Credenciales inválidas", "OK");
            }
        }

        [RelayCommand]
        private async Task NavigateToRegisterAsync()
        {
            Navigate.NavigateToPage(new Views.RegisterPage(),false);
        }

        [RelayCommand]
        private async Task NavigateToResetPasswordAsync()
        {
           Navigate.NavigateToPage(new Views.RecuperarClavePage(),true);
        }
    }
}
