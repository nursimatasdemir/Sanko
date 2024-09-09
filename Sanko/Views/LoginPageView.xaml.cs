using Database;
namespace Sanko.Views;

public partial class LoginPageView : ContentPage
{
	private readonly DataService _databaseService;
	public LoginPageView(DataService databaseService)
	{
		InitializeComponent();
		_databaseService = databaseService;
	}

    public async void Login_Clicked(object sender, EventArgs e)
    {
		string email = emailEntry.Text;
		string password = passwordEntry.Text;

		if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
		{
			await DisplayAlert("Error", "Lütfen Email adresinizi ve şifrenizi giriniz!", "OK");
			return;
		}
		bool isAuthenticated = await _databaseService.AuthenticateUserAsync(email, password);
		if (isAuthenticated)
		{
			await Navigation.PushAsync(new MainPage());
		} else
		{
			await DisplayAlert("Error", "Email adresi veya şifre yanlış!", "Tekrar Dene");
		}
		

    }
}