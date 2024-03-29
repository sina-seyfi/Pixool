using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour, IGameContract.IGameView
{

	private IGameContract.IGamePresenter presenter;
	[SerializeField]
	private PixelsSpawner mainPixelsSpawner;
	[SerializeField]
	private PixelsSpawner shelfPixelsSpawner;
	[SerializeField]
	private RawImage rawImage;

    // Start is called before the first frame update
    void Start()
    {
		presenter = new GamePresenter(this);
    }

    // Update is called once per frame
    void Update()
    {
    }

	void IGameContract.IGameView.updateLevelName(string name) {
		// TODO Implement this later
	}

	void IGameContract.IGameView.updatePixels(PixelData[,] pixels) {
		mainPixelsSpawner.Spawn(pixels, pixelGo => {
			var pixel = pixelGo.GetComponent<Pixel>();
			if(pixel != null) {
				pixel.selectEvent -= onPixelSelected;
				pixel.selectEvent += onPixelSelected;
			}
		});
	}

	void IGameContract.IGameView.updateReferenceTexture(Texture2D texture) {

	}

	void IGameContract.IGameView.updateShelf(PixelShelf[,] pixels) {
		shelfPixelsSpawner.Spawn(pixels, pixelGo => {
			var pixel = pixelGo.GetComponent<Pixel>();
			if (pixel != null)
			{
				pixel.selectEvent -= onPixelSelected;
				pixel.selectEvent += onPixelSelected;
			}
		});
	}

	private void onPixelSelected(PixelData data) {
		presenter.onPixelSelected(data);
    }

}
