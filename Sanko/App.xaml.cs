using Sanko.Views;
namespace Sanko;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new LoginPageView();
	}
}
