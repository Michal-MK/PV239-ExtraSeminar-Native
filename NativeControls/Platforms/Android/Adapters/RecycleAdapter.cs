using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NativeControls.Platforms.Android.Adapters;

public abstract class RecycleAdapter<TModel> : RecyclerView.Adapter where TModel : new() {

	public List<TModel> Data { get; set; }

	public abstract int LayoutResourceID { get; }

	protected Action<View, int> itemClickedAction;

	private readonly Dictionary<int, RecyclerView.ViewHolder> positionedHolders = new Dictionary<int, RecyclerView.ViewHolder>();

	public RecycleAdapter(IEnumerable<TModel> data, Action<View, int> onClick) {
		Data = data.ToList();
		itemClickedAction = onClick;
	}

	public override int ItemCount => Data.Count;

	public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
		positionedHolders[position] = holder;

		ClickViewHolder<TModel> cast = holder as ClickViewHolder<TModel>;
		cast.Context = Data[position];
	}

	public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) {
		View w = LayoutInflater.From(parent.Context).Inflate(LayoutResourceID, parent, false);
		return new ClickViewHolder<TModel>(w, itemClickedAction);
	}
}
