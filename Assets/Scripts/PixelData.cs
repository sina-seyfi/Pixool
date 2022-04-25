public abstract class PixelData {
	public int X { get; set; } = -1;
	public int Y { get; set; } = -1;
}
public class PixelColor: PixelData {
	public Game.Color Color { protected set; get; }
	public PixelColor(Game.Color Color) {
		this.Color = Color;
	}
}
public class PixelEmpty : PixelData {
	public PixelColor PixelColor { get; }
	public PixelEmpty(PixelColor PixelColor) {
		this.PixelColor = PixelColor;
		this.X = PixelColor.X;
		this.Y = PixelColor.Y;
	}
}
public class PixelWaiting : PixelData {
	public PixelColor PixelColor { get; }
	public PixelEmpty PixelEmpty { get; }
	public PixelWaiting(PixelColor PixelColor, PixelEmpty PixelEmpty) {
		this.PixelColor = PixelColor;
		this.PixelEmpty = PixelEmpty;
		this.X = PixelColor.X;
		this.Y = PixelColor.Y;
	}
}
public class PixelShelf : PixelColor {
	public bool IsSelected { get; set; } = false;
	public PixelShelf(Game.Color Color) : base(Color) { }
}