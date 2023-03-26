using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using NativeControls.UserControls;
using NativeControls.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace NativeControls.Pages;

public partial class CollectionPage : ContentPage {

	public ObservableCollection<MyElementViewModel> Elements { get; set; } = new();

	public Action<MyElement> RainbowColoring => e => { 
		e.BackgroundColor = Color.FromHsla(new Random().NextDouble(), 1, 0.5, 1);
	};
	
	public Action<MyElement> GrayscaleColoring => e => { 
		e.BackgroundColor = Color.FromHsla(0, 0, new Random().NextDouble(), 1);
	};

	public CollectionPage() {
		Enumerable.Range(0, 100)
		.Select(s => {
			return new MyElementViewModel {
				Name = $"Name {s}",
				Description = $"Description {s}",
				Image = "https://picsum.photos/300"
			};
		}).ToList().ForEach(Elements.Add);

		BindingContext = this;

		InitializeComponent();
	}

	public static readonly BindableProperty OddElementActionProperty = BindableProperty.CreateAttached(
			nameof(OddElementActionProperty),
			typeof(Action<MyElement>),
			typeof(CollectionPage),
			null,
			BindingMode.OneWay,
			null);

	public static Action<MyElement> GetOddElementAction(BindableObject view) {
		return (Action<MyElement>)view.GetValue(OddElementActionProperty);
	}

	public static void SetOddElementAction(BindableObject view, Action<MyElement> value) {
		view.SetValue(OddElementActionProperty, value);
	}

	private void CollectionView_ChildAdded(object sender, ElementEventArgs e) {
		(GetOddElementAction(e.Element))?.Invoke(e.Element as MyElement);
	}
}