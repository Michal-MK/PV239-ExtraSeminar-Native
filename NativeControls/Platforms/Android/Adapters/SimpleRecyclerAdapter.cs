using Android.Graphics;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content.Resources;
using AndroidX.RecyclerView.Widget;
using Bumptech.Glide;
using Bumptech.Glide.Load.Engine;
using NativeControls.ViewModels;
using System;
using System.Collections.Generic;

namespace NativeControls.Platforms.Android.Adapters {
	public class SimpleRecyclerAdapter : RecycleAdapter<MyElementViewModel> {
		public SimpleRecyclerAdapter(IEnumerable<MyElementViewModel> data, Action<View, int> onClick) : base(data, onClick) {

		}

		public override int LayoutResourceID => Resource.Layout.my_element;

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
			base.OnBindViewHolder(holder, position);

			View v = holder.ItemView;

			if (position % 2 == 0) {
				Color c = new(ResourcesCompat.GetColor(MainActivity.Instance.Resources, Resource.Color.listItemEven, null));
				c.A = 64;
				v.SetBackgroundColor(c);
			}
			else {
				Color c = new(ResourcesCompat.GetColor(MainActivity.Instance.Resources, Resource.Color.listItemOdd, null));
				c.A = 64;
				v.SetBackgroundColor(c);
			}
			var iv = v.FindViewById<ImageView>(Resource.Id.my_entry_image);

			Glide.With(iv).Load(Data[position].Image).SetDiskCacheStrategy(DiskCacheStrategy.None).SkipMemoryCache(true).Into(iv);
			v.FindViewById<TextView>(Resource.Id.my_entry_name).Text = Data[position].Name;
			v.FindViewById<TextView>(Resource.Id.my_entry_description).Text = Data[position].Description;
		}
	}
}
