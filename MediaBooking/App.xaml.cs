namespace MediaBooking
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new FlyoutMenu();
            MainPage = new MediaBooking.Screens.Acceso();
        }
    }
}
