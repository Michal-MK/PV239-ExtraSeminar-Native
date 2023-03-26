using Microsoft.Maui.Controls;

namespace NativeControls;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainPage());
	}
}
