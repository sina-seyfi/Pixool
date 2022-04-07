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
		enableOverlaySpriteRenderer();
		return srOverlay;
	}
	private void enableOverlaySpriteRenderer() {
		if(!srOverlay.enabled) srOverlay.enabled = true;
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
			}
		}
	}

	private void updateInternalState() {
		disableOverlaySpriteRenderer();
		switch(data) {
			case PixelEmpty: {
				getSpriteRenderer().color = Color.white;
				getOverlaySpriteRenderer().color = Color.black;
				break;
			}
			case PixelWaiting pw: {
				getSpriteRenderer().color = Color.white;
				getOverlaySpriteRenderer().color = pw.Color;
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
}
