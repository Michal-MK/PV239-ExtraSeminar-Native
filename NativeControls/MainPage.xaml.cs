using Microsoft.Maui.Controls;
using Microsoft.UI.Xaml;
using NativeControls.Pages;
using System;

namespace NativeControls;

public partial class MainPage : ContentPage
{

	private static NavigationPage Root => (NavigationPage)App.Current.MainPage;

	public MainPage()
	{
		InitializeComponent();
	}

	private void Implementation1_Clicked(object sender, EventArgs e) {
		Root.PushAsync(new RecyclerPage());
	}

	private void Implementation2_Clicked(object sender, EventArgs e) {
		Root.PushAsync(new CollectionPage());
	}
}