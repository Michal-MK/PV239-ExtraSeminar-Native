using Microsoft.Maui;

namespace NativeControls.UserControls.Shared;

public partial class RecyclerViewHandler {
	public static PropertyMapper<RecyclerView, RecyclerViewHandler> RecyclerViewMapper = new(ViewMapper) {

	};
}