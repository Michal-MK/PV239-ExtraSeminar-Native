using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Media;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using NativeControls.Platforms.Windows.UserControls;
using NRecyler = Microsoft.UI.Xaml.Controls.ListView;
using SRecycler = NativeControls.UserControls.Shared.RecyclerView;

namespace NativeControls.UserControls.Shared;

public partial class RecyclerViewHandler : ViewHandler<SRecycler, NRecyler> {
	public RecyclerViewHandler(IPropertyMapper mapper, CommandMapper commandMapper = null)
		: base(mapper, commandMapper) { }

	public RecyclerViewHandler() : base(RecyclerViewMapper) { }

	protected override NRecyler CreatePlatformView() {
		NRecyler recycler = new();
		ItemsPanelTemplate uc;
		// https://github.com/microsoft/microsoft-ui-xaml/issues/2898
		if (VirtualView.Orientation == ScrollOrientation.Horizontal) {
			uc = (ItemsPanelTemplate)XamlReader.Load(
				"<ItemsPanelTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">" +
					"<StackPanel Orientation=\"Horizontal\"/>" +
				"</ItemsPanelTemplate>"
			);
			recycler.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, Microsoft.UI.Xaml.Controls.ScrollBarVisibility.Auto);
			recycler.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, Microsoft.UI.Xaml.Controls.ScrollBarVisibility.Disabled);
			recycler.SetValue(ScrollViewer.HorizontalScrollModeProperty, Microsoft.UI.Xaml.Controls.ScrollMode.Enabled);
			recycler.SetValue(ScrollViewer.VerticalScrollModeProperty, Microsoft.UI.Xaml.Controls.ScrollMode.Disabled);
		}
		else {
			uc = (ItemsPanelTemplate)XamlReader.Load(
				"<ItemsPanelTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">" +
					"<StackPanel Orientation=\"Vertical\"/>" +
				"</ItemsPanelTemplate>"
			);
			recycler.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, Microsoft.UI.Xaml.Controls.ScrollBarVisibility.Disabled);
			recycler.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, Microsoft.UI.Xaml.Controls.ScrollBarVisibility.Auto);
			recycler.SetValue(ScrollViewer.HorizontalScrollModeProperty, Microsoft.UI.Xaml.Controls.ScrollMode.Disabled);
			recycler.SetValue(ScrollViewer.VerticalScrollModeProperty, Microsoft.UI.Xaml.Controls.ScrollMode.Enabled);
		}
		recycler.ItemsPanel = uc;
		recycler.ItemsSource = VirtualView.ItemSource;

		recycler.ItemTemplate = (DataTemplate)XamlReader.Load("<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" " +
																			"xmlns:local=\"using:NativeControls.Platforms.Windows.UserControls\">" +
																	"<local:MyElementControl/>" +
															  "</DataTemplate>");
		return recycler;
	}
}