using UnityEngine;

public class Pixel : MonoBehaviour
{
	public const string LAYER_PIXELS = "Pixels";
	public const string LAYER_SHELF = "Shelf";
	private PixelData data;
	[SerializeField]
	private SpriteRenderer srBase;
	[SerializeField]
	private SpriteRenderer srOverlay;
	[SerializeField]
	private BoxCollider boxCollider;
	[SerializeField]
	private Sprite empty;
	[SerializeField]
	private Sprite selected;
	[SerializeField]
	private ClickHandler ClickHandler;
	public delegate void PixelSelectEvent(PixelData data);
	public event PixelSelectEvent selectEvent;
    private void Start()
    {
        ClickHandler.handler += onClickListener;
    }
    private void OnDestroy()
    {
		ClickHandler.handler -= onClickListener;
	}
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
		string spLayer = null;
		string spOverlayLayer = null;
		bool isBoxColliderEnabled = false;
		switch(data) {
			case PixelEmpty: {
				spLayer = LAYER_PIXELS;
				spOverlayLayer = LAYER_PIXELS;
				getSpriteRenderer().color = Color.white;
				getOverlaySpriteRenderer().sprite = empty;
				getOverlaySpriteRenderer().color = Color.black;
				break;
			}
			case PixelWaiting pw: {
				spLayer = LAYER_PIXELS;
				spOverlayLayer = LAYER_PIXELS;
				isBoxColliderEnabled = true;
				getSpriteRenderer().color = Color.white;
				getOverlaySpriteRenderer().sprite = empty;
				getOverlaySpriteRenderer().color = pw.PixelColor.Color.ToColor32();
				break;
			}
			case PixelShelf ps: {
				spLayer = LAYER_SHELF;
				isBoxColliderEnabled = true;
				getSpriteRenderer().color = ps.Color.ToColor32();
				if(ps.IsSelected){
					spOverlayLayer = LAYER_SHELF;
					var luminance = Utils.calculateLuminance(ps.Color);
					getOverlaySpriteRenderer().sprite = selected;
					if(luminance >= 0.5)
						getOverlaySpriteRenderer().color = Color.black;
					else
						getOverlaySpriteRenderer().color = Color.white;
				}
				break;
			}
			case PixelColor pc: {
				spLayer = LAYER_PIXELS;
				getSpriteRenderer().color = pc.Color.ToColor32();
				break;
			}
		}
		if (spLayer != null) getSpriteRenderer().sortingLayerName = spLayer;
		if (spOverlayLayer != null) getOverlaySpriteRenderer().sortingLayerName = spOverlayLayer;
		boxCollider.enabled = isBoxColliderEnabled;
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

	private void onClickListener() {
		if(selectEvent != null)
        {
			selectEvent.Invoke(data);
        }
    }

}
