using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace NativeControls.UserControls.Shared;

public class RecyclerView : View {

	public IEnumerable<object> ItemSource {
		get => (IEnumerable<object>)GetValue(ItemSourceProperty);
		set => SetValue(ItemSourceProperty, value);
	}

	public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create(nameof(ItemSource), typeof(IEnumerable<object>), typeof(RecyclerView), Array.Empty<object>());

	public ScrollOrientation Orientation {
		get => (ScrollOrientation)GetValue(OrientationProperty);
		set => SetValue(OrientationProperty, value);
	}

	public static readonly BindableProperty OrientationProperty = BindableProperty.Create(nameof(Orientation), typeof(ScrollOrientation), typeof(RecyclerView), ScrollOrientation.Vertical, propertyChanging: OnOrientationChaninging);

	private static void OnOrientationChaninging(BindableObject bindable, object oldValue, object newValue) {
		if (newValue is not ScrollOrientation orientation) {
			throw new ArgumentException(nameof(newValue));
		}
		if (orientation is ScrollOrientation.Both or ScrollOrientation.Neither) {
			throw new ArgumentException($"Unsupported orientation: {orientation} - only {ScrollOrientation.Vertical} or {ScrollOrientation.Horizontal}");
		}
	}
}