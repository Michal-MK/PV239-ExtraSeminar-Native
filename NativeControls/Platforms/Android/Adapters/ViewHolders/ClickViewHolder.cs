using Android.Views;
using AndroidX.RecyclerView.Widget;
using System;

public class ClickViewHolder<T> : RecyclerView.ViewHolder where T : new() {

	private Action<View, int> OnClickAction { get; }

	public T Context { get; set; }

	public ClickViewHolder(View view, Action<View, int> onClick) : base(view) {
		OnClickAction = onClick;
		if (OnClickAction != null) {
			view.Clickable = true;
			view.LongClickable = true;
			view.Click += (s, e) => { OnClick(s as View); };
		}
	}

	public void OnClick(View v) {
		OnClickAction?.Invoke(v, AbsoluteAdapterPosition);
	}
}