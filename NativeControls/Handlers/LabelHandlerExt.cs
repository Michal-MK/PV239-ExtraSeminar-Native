using Microsoft.Maui.Controls;
using Microsoft.Maui.Handlers;

namespace NativeControls.Handlers {
	public static class LabelExt {

		public const string IsSelectable = nameof(IsSelectable);

		public static void Setup() {
			LabelHandler.Mapper.Add(IsSelectable, (handler, label) => {
#if WINDOWS
				if (GetIsSelectable(handler.VirtualView as Label))
					handler.PlatformView.IsTextSelectionEnabled = true;
#endif
			});
		}

		public static BindableProperty IsSelectableProperty = BindableProperty.CreateAttached(
			IsSelectable,
			typeof(bool),
			typeof(Label),
			false);

		public static void SetIsSelectable(BindableObject view, bool value) {
			view.SetValue(IsSelectableProperty, value);
		}

		public static bool GetIsSelectable(BindableObject view) {
			return (bool)view.GetValue(IsSelectableProperty);
		}
	}
}
