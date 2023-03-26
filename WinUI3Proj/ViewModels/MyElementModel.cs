namespace NativeControls.ViewModels;

public record MyElementViewModel(string Name, string Description, string Image);


public class DMyElementViewModel {
	public string Name { get; set; }
	public string Description { get; set; }
	public string Image { get; set; }
}
