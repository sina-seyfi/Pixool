using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PixelData { }
public class PixelColor: PixelData {
	public Color32 Color { set; get; }
}
public class PixelEmpty : PixelData { }
public class PixelWaiting : PixelColor {
	public PixelWaiting(Color32 Color) {
		this.Color = Color;
	}
}
public class PixelShelf : PixelColor {
	public PixelShelf(Color32 Color) {
		this.Color = Color;
	}
}