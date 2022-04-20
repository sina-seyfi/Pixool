using UnityEngine;
using Unity.Collections;
using System.Collections;
using UniRx;

public class GamePresenter : IGameContract.IGamePresenter {

	public static int SHELF_ROW_SIZE = 7;

	private IGameContract.IGameView view;
	private IGameContract.IGameModel model;
	private PixelShelf selectedShelfPixel;

	private bool isSelectedAnyPixelShelf() => selectedShelfPixel != null;

	public GamePresenter(IGameContract.IGameView view) {
		this.view = view;
		this.model = GameModelBuilder.build();
		this.model.initState();
		init();
	}

	private void init() {
		model.getPixelsReactiveProperty().Subscribe(pixels => {
			updateViewMainPixels(pixels);
			updateViewShelfPixels(pixels);
		});
		model.getTextureReactiveProperty().Subscribe(texture => view.updateReferenceTexture(texture));
	}

	private void updateViewShelfPixels(PixelData[,] pixels)
	{
		var shelfPixels = new ArrayList();
		for (int i = 0; i < pixels.GetLength(0); i++)
		{
			for (int j = 0; j < pixels.GetLength(1); j++)
			{
				var pixel = pixels[i, j];
				if(pixel is PixelEmpty) {
					var shelf = new PixelShelf(((PixelEmpty)pixel).PixelColor.Color);
					if(isSelectedAnyPixelShelf())
						shelf.IsSelected = shelf.Color.Equals(selectedShelfPixel.Color);
					shelfPixels.Add(shelf);
                }
			}
		}
		var _2dArray = new PixelShelf[(int) Mathf.Ceil(shelfPixels.Count / (float) SHELF_ROW_SIZE), SHELF_ROW_SIZE];
        for (int i = 0; i < shelfPixels.Count; i++)
        {
			var row = i / SHELF_ROW_SIZE;
			var col = i % SHELF_ROW_SIZE;
			_2dArray[row, col] = (PixelShelf) shelfPixels[i];
        }
		view.updateShelf(_2dArray);
	}

	private void updateViewMainPixels(PixelData[,] pixels)
    {
		view.updatePixels(mapMainPixelsWithState(pixels));
    }

	private PixelData[,] mapMainPixelsWithState(PixelData[,] pixels)
    {
		var _2dArray = new PixelData[pixels.GetLength(0), pixels.GetLength(1)];
        for (int i = 0; i < pixels.GetLength(0); i++)
        {
            for (int j = 0; j < pixels.GetLength(1); j++)
            {
				var pixel = pixels[i, j];
				switch(pixel)
                {
					case PixelEmpty pe:
                        {
							if(isSelectedAnyPixelShelf()) {
								_2dArray[i, j] = new PixelWaiting(selectedShelfPixel);
							} else {
								_2dArray[i, j] = pe;
                            }
							break;
                        }
					default:
                        {
							_2dArray[i, j] = pixels[i, j];
							break;
                        }
                }
            }
        }
		return _2dArray;
    }

    void IGameContract.IGamePresenter.onPixelSelected(PixelData pixel) {
		switch(pixel)
        {
			case PixelShelf ps:
                {
					Debug.Log("Pixel Shelf is Clicked");
					if(isSelectedAnyPixelShelf() && selectedShelfPixel.Color.Equals(ps.Color)) {
						selectedShelfPixel = null;
                    } else {
						selectedShelfPixel = ps;
                    }
					updateViewMainPixels(model.getPixels());
					updateViewShelfPixels(model.getPixels());
					break;
                }
			case PixelWaiting pw:
                {
					Debug.Log("Pixel Waiting is Clicked");
					if(isSelectedAnyPixelShelf())
                    {
						if(selectedShelfPixel.Color.Equals(pw.PixelColor.Color)) {
							selectedShelfPixel = null;
							model.removeMissedPixel(new PixelEmpty(pw.PixelColor));
						} else {
							// TODO Remove one from score
                        }
                    }
					break;
                }
			default:
                {
					Debug.Log("We just don't fuckin care abut this click");
					break;
                }
        }
	}
}
