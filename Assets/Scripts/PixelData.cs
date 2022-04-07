using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PixelData {
	public int X { get; set; } = -1;
	public int Y { get; set; } = -1;
}
public class PixelColor: PixelData {
	public Color32 Color { protected set; get; }
	public PixelColor(Color32 Color) {
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
	public PixelWaiting(PixelColor PixelColor) {
		this.PixelColor = PixelColor;
		this.X = PixelColor.X;
		this.Y = PixelColor.Y;
	}
}
public class PixelShelf : PixelColor {
	public PixelShelf(Color32 Color) : base(Color) { }
}