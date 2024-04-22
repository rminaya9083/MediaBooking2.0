using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Essentials;

namespace MediaBooking.Screens;

public partial class Huella : ContentPage
{
    public Huella()
    {
        InitializeComponent();
    }

    private async void Button_Huella(object sender, EventArgs e)
    {
        var request = new AuthenticationRequestConfiguration("Demo de Autenticación", "Toque el sensor de huella digital")
        {
            // Configura aquí cualquier ajuste específico para el diálogo de autenticación biométrica
            CancelTitle = "Cancelar",
            FallbackTitle = "Usar Contraseña",
            AllowAlternativeAuthentication = true
        };

        // Verifica si la huella digital está disponible y configurada
        var availability = await CrossFingerprint.Current.IsAvailableAsync(true);
        if (!availability)
        {
            await DisplayAlert("No disponible", "La autenticación biométrica no está disponible o no está configurada.", "OK");
            return;
        }

        // Solicitar la autenticación biométrica
        var result = await CrossFingerprint.Current.AuthenticateAsync(request);
        if (result.Authenticated)
        {
            // Aquí, podrías guardar la preferencia de utilizar huella digital para el usuario actual
            Microsoft.Maui.Storage.Preferences.Set("UseFingerprint", true);
            await DisplayAlert("Huella Configurada", "Tu huella ha sido configurada correctamente para futuros inicios de sesión.", "OK");
            // Aquí también podrías redirigir al usuario o actualizar la UI según sea necesario
        }
        else
        {
            if (result.Status == FingerprintAuthenticationResultStatus.Canceled)
            {
                await DisplayAlert("Cancelado", "Autenticación cancelada por el usuario.", "OK");
            }
            else
            {
                await DisplayAlert("No autenticado", "No se pudo autenticar usando la huella digital.", "OK");
            }
        }
    }
}
