using System.Text.RegularExpressions;
using Microsoft.Maui.Storage;

namespace Proyecto_Evently.Views;

public partial class Login : ContentPage
{
    private static Dictionary<string, string> usuarios = new();

    public Login()
    {
        InitializeComponent();
        CargarUsuarios();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await this.FadeToAsync(1, 400);
        await LoginCard.ScaleToAsync(1, 300, Easing.CubicOut);

        string sesion = Preferences.Get("usuario_activo", string.Empty);
        if (!string.IsNullOrEmpty(sesion))
        {
            IrAPantallaPrincipal(sesion);
        }
    }

    private static void GuardarUsuarios()
    {
        string datos = string.Join(";", usuarios.Select(u => $"{u.Key}|{u.Value}"));
        Preferences.Set("usuarios_guardados", datos);
    }

    private static void CargarUsuarios()
    {
        string datos = Preferences.Get("usuarios_guardados", string.Empty);

        if (!string.IsNullOrWhiteSpace(datos))
        {
            var lista = datos.Split(";");

            foreach (var item in lista)
            {
                var partes = item.Split("|");
                if (partes.Length == 2)
                {
                    usuarios[partes[0]] = partes[1];
                }
            }
        }
    }

    private static bool EsCorreoValido(string correo)
    {
        return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    private async void OnRegisterClicked(object? sender, EventArgs e)
    {
        string correo = CorreoEntry.Text?.Trim() ?? string.Empty;
        string password = PasswordEntry.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlertAsync("Error", "Completa todos los campos", "OK");
            return;
        }

        if (!EsCorreoValido(correo))
        {
            await DisplayAlertAsync("Error", "Correo inválido", "OK");
            return;
        }

        if (usuarios.ContainsKey(correo))
        {
            await DisplayAlertAsync("Error", "El usuario ya existe", "OK");
            return;
        }

        usuarios.Add(correo, password);
        GuardarUsuarios();

        await DisplayAlertAsync("Exito", "Usuario registrado correctamente!!!", "OK");

        CorreoEntry.Text = string.Empty;
        PasswordEntry.Text = string.Empty;
    }

    private async void OnLoginClicked(object? sender, EventArgs e)
    {
        string correo = CorreoEntry.Text?.Trim() ?? string.Empty;
        string password = PasswordEntry.Text?.Trim() ?? string.Empty;

        if (usuarios.TryGetValue(correo, out string? storedPassword) &&
            storedPassword == password)
        {
            Preferences.Set("usuario_activo", correo);

            await this.ScaleToAsync(0.95, 100);
            await this.ScaleToAsync(1, 100);

            IrAPantallaPrincipal(correo);
        }
        else
        {
            await DisplayAlertAsync("Error", "Correo o contraseña incorrectos", "OK");
        }
    }

    private static void IrAPantallaPrincipal(string correo)
    {
        Application.Current!.Windows[0].Page = new ContentPage
        {
            BackgroundColor = Colors.White,
            Content = new VerticalStackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 20,
                Children =
                {
                    new Label
                    {
                        Text = "Bienvenido a Evntly!",
                        FontSize = 26,
                        TextColor = Colors.Black
                    },
                    new Label
                    {
                        Text = correo,
                        FontSize = 14,
                        TextColor = Colors.Gray
                    },
                    new Button
                    {
                        Text = "Cerrar sesión",
                        BackgroundColor = Colors.Red,
                        TextColor = Colors.White,
                        Command = new Command(() =>
                        {
                            Preferences.Remove("usuario_activo");
                            Application.Current!.Windows[0].Page = new Login();
                        })
                    }
                }
            }
        };
    }

    private void OnTogglePassword(object? sender, EventArgs e)
    {
        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
        TogglePasswordBtn.Text = PasswordEntry.IsPassword ? "👁" : "🙈";
    }
}