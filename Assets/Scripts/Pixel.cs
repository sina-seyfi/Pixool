using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour
{
	private PixelData data;
	[SerializeField]
	private SpriteRenderer srBase;
	[SerializeField]
	private SpriteRenderer srOverlay;
	private SpriteRenderer getSpriteRenderer() {
		return srBase;
	}
	private SpriteRenderer getOverlaySpriteRenderer() {
		if(!srOverlay.enabled) srOverlay.enabled = true;
		return srOverlay;
	}
	private void disableOverlaySpriteRenderer() {
		if(srOverlay.enabled) srOverlay.enabled = false;
	}
	public PixelData Data {
		get { return data; }
		set {
			if(value != null) {
				data = value;
				updateInternalState();
				updateName();
			}
		}
	}

	private void updateInternalState() {
		disableOverlaySpriteRenderer();
		switch(data) {
			case PixelEmpty: {
				Debug.Log("Called");
				getSpriteRenderer().color = Color.white;
				getOverlaySpriteRenderer().color = Color.black;
				break;
			}
			case PixelWaiting pw: {
				getSpriteRenderer().color = Color.white;
				getOverlaySpriteRenderer().color = pw.PixelColor.Color;
				break;
			}
			case PixelShelf ps: {
				getSpriteRenderer().color = ps.Color;
				break;
			}
			case PixelColor pc: {
				getSpriteRenderer().color = pc.Color;
				break;
			}
		}
	}

	private void updateName() {
		switch(data) {
			case PixelEmpty: {
					name = "PixelEmpty (" + data.Y + ", " + data.X + ")";
					break;
				}
			case PixelWaiting pw: {
					name = "PixelWaiting (" + data.Y + ", " + data.X + ")";
					break;
				}
			case PixelShelf ps: {
					name = "PixelShelf (" + data.Y + ", " + data.X + ")";
					break;
				}
			case PixelColor pc: {
					name = "PixelColor (" + data.Y + ", " + data.X + ")";
					break;
				}
		}
	}

}
