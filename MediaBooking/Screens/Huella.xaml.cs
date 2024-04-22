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
        var request = new AuthenticationRequestConfiguration("Demo de Autenticaci�n", "Toque el sensor de huella digital")
        {
            // Configura aqu� cualquier ajuste espec�fico para el di�logo de autenticaci�n biom�trica
            CancelTitle = "Cancelar",
            FallbackTitle = "Usar Contrase�a",
            AllowAlternativeAuthentication = true
        };

        // Verifica si la huella digital est� disponible y configurada
        var availability = await CrossFingerprint.Current.IsAvailableAsync(true);
        if (!availability)
        {
            await DisplayAlert("No disponible", "La autenticaci�n biom�trica no est� disponible o no est� configurada.", "OK");
            return;
        }

        // Solicitar la autenticaci�n biom�trica
        var result = await CrossFingerprint.Current.AuthenticateAsync(request);
        if (result.Authenticated)
        {
            // Aqu�, podr�as guardar la preferencia de utilizar huella digital para el usuario actual
            Microsoft.Maui.Storage.Preferences.Set("UseFingerprint", true);
            await DisplayAlert("Huella Configurada", "Tu huella ha sido configurada correctamente para futuros inicios de sesi�n.", "OK");
            // Aqu� tambi�n podr�as redirigir al usuario o actualizar la UI seg�n sea necesario
        }
        else
        {
            if (result.Status == FingerprintAuthenticationResultStatus.Canceled)
            {
                await DisplayAlert("Cancelado", "Autenticaci�n cancelada por el usuario.", "OK");
            }
            else
            {
                await DisplayAlert("No autenticado", "No se pudo autenticar usando la huella digital.", "OK");
            }
        }
    }
}
