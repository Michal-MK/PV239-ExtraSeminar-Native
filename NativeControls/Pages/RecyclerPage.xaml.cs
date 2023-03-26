using Microsoft.Maui;
using Microsoft.Maui.Controls;
using NativeControls.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;

namespace NativeControls.Pages;

public partial class RecyclerPage : ContentPage {

	public ObservableCollection<MyElementViewModel> Elements { get; set; } = new();

	public ScrollOrientation ScrollOrientation { get; set; } = ScrollOrientation.Vertical;

	public RecyclerPage() {
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
}