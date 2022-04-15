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
	[SerializeField]
	private Sprite empty;
	[SerializeField]
	private Sprite selected;
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
				getSpriteRenderer().color = Color.white;
				getOverlaySpriteRenderer().sprite = empty;
				getOverlaySpriteRenderer().color = Color.black;
				break;
			}
			case PixelWaiting pw: {
				getSpriteRenderer().color = Color.white;
				getOverlaySpriteRenderer().sprite = empty;
				getOverlaySpriteRenderer().color = pw.PixelColor.Color;
				break;
			}
			case PixelShelf ps: {
				getSpriteRenderer().color = ps.Color;
				if(ps.IsSelected){
					getOverlaySpriteRenderer().sprite = selected;
					getOverlaySpriteRenderer().color = Color.white;
				}
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
					name = "PixelEmpty (" + data.X + ", " + data.Y + ")";
					break;
				}
			case PixelWaiting pw: {
					name = "PixelWaiting (" + data.X + ", " + data.Y + ")";
					break;
				}
			case PixelShelf ps: {
					name = "PixelShelf (" + data.X + ", " + data.Y + ")";
					break;
				}
			case PixelColor pc: {
					name = "PixelColor (" + data.X + ", " + data.Y + ")";
					break;
				}
		}
	}

}
