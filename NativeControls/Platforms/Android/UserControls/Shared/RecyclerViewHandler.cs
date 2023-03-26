using Android.Widget;
using AndroidX.RecyclerView.Widget;
using JetBrains.Annotations;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using NativeControls.Platforms.Android.Adapters;
using NativeControls.ViewModels;
using System.Linq;
using Debug = System.Diagnostics.Debug;
using NRecyler = AndroidX.RecyclerView.Widget.RecyclerView;
using SRecycler = NativeControls.UserControls.Shared.RecyclerView;

namespace NativeControls.UserControls.Shared;

public partial class RecyclerViewHandler : ViewHandler<SRecycler, NRecyler> {
	public RecyclerViewHandler([NotNull] IPropertyMapper mapper, CommandMapper commandMapper = null)
		: base(mapper, commandMapper) { }

	public RecyclerViewHandler() : base(RecyclerViewMapper) { }

	protected override NRecyler CreatePlatformView() {
		NRecyler recycler = new(Context);
		int orientation = VirtualView.Orientation == ScrollOrientation.Vertical ? LinearLayoutManager.Vertical : LinearLayoutManager.Horizontal;
		recycler.SetLayoutManager(new LinearLayoutManager(Context, orientation, false));
		recycler.SetAdapter(new SimpleRecyclerAdapter(VirtualView.ItemSource.Cast<MyElementViewModel>(),
			(v, i) => { Toast.MakeText(Context, $"Touched: {i+1}" + (i == 0 ? "st" : i == 1 ? "nd": i == 2 ? "rd" : "th") + " view!", ToastLength.Short).Show(); }));
		return recycler;
	}
}