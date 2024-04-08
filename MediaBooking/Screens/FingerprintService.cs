using AndroidX.Biometric;
using Android.Content;
using Java.Util.Concurrent;

namespace TuApp.Droid.Services // Ajusta el namespace según tu proyecto
{
    public class FingerprintService
    {
        private readonly Context _context;

        public FingerprintService(Context context)
        {
            _context = context;
        }

        public FingerprintService()
        {
        }

        public bool IsFingerprintAvailable()
        {
            var biometricManager = BiometricManager.From(_context);
            var canAuthenticate = biometricManager.CanAuthenticate();

            return canAuthenticate == BiometricManager.BiometricSuccess;
        }

        public void Authenticate(Action<bool> callback)
        {
            var biometricPromptInfo = new BiometricPrompt.PromptInfo.Builder()
                .SetTitle("Autenticación de huellas dactilares")
                .SetSubtitle("Escanea tu huella dactilar")
                .SetNegativeButtonText("Cancelar")
                .Build();

            var executor = Executors.NewSingleThreadExecutor();
            var biometricPrompt = new BiometricPrompt((AndroidX.Fragment.App.FragmentActivity)_context, executor, new BiometricAuthenticationCallback(callback));
            biometricPrompt.Authenticate(biometricPromptInfo);
        }

        private class BiometricAuthenticationCallback : BiometricPrompt.AuthenticationCallback
        {
            private readonly Action<bool> _callback;

            public BiometricAuthenticationCallback(Action<bool> callback)
            {
                _callback = callback;
            }

            public override void OnAuthenticationSucceeded(BiometricPrompt.AuthenticationResult result)
            {
                base.OnAuthenticationSucceeded(result);
                _callback?.Invoke(true);
            }

            public override void OnAuthenticationFailed()
            {
                base.OnAuthenticationFailed();
                _callback?.Invoke(false);
            }
        }
    }
}

