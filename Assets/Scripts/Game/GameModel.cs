using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameModel : IGameContract.IGameModel
{

	public ReactiveProperty<PixelData[,]> PixelsData { get; private set; }
	public ReactiveProperty<Texture2D> Texture { get; private set; }
	public static float EMPTY_LUMINANCE_DIFFERENCE = 0.06f;

	ReactiveProperty<PixelData[,]> IGameContract.IGameModel.getPixelsReactiveProperty() {
		return PixelsData;
	}

	void IGameContract.IGameModel.initState() {
		PixelsData = new ReactiveProperty<PixelData[,]>();
		Texture = new ReactiveProperty<Texture2D>();
		var texture = Resources.Load<Texture2D>("Textures/dog_32_32");
		Texture.Value = texture;
		var root = texture.width;
		var pixels = texture.GetPixels();
		var maxRows = (int) Mathf.Ceil(pixels.Length / (float) root);
		var _2dArray = new PixelColor[(int)root, pixels.Length / (int)root];
		for (int i = 0; i < pixels.Length; i++)
		{
			var pixelColor = new PixelColor(pixels[i]);
			var row = i / (int) root;
			var col = i % (int) root;
			// Because GetPixels of texture will get us pixels inverted on x axis...
			var invertedRow = (maxRows - (row + 1));
			pixelColor.X = col;
			pixelColor.Y = invertedRow;
			_2dArray[invertedRow, col] = pixelColor;
		}
		PixelsData.Value = calculateMissedPixels(_2dArray);
	}

	private PixelData[,] calculateMissedPixels(PixelColor[,] pixels){
		var row = pixels.GetLength(0);
		var col = pixels.GetLength(1);
		var maxEdgeSize = Mathf.Max(row, col);
		var _2dArray = new PixelData[row, col];
		var emptyList = new ArrayList();
		for(int i = 0; i < row; i++) {
			for(int j = 0; j < col; j++)
            {
				if (Utils.onChance(EMPTY_LUMINANCE_DIFFERENCE * maxEdgeSize * 4)) {
					var empty = new PixelEmpty(pixels[i, j]);
					var found = false;
					foreach(PixelEmpty item in emptyList) {
						var luminance1 = (float) Utils.calculateLuminance(item.PixelColor.Color);
						var luminance2 = (float) Utils.calculateLuminance(empty.PixelColor.Color);
						if(Mathf.Abs(luminance1 - luminance2) <= EMPTY_LUMINANCE_DIFFERENCE) {
							found = true;
							break;
						}
                    }
					if(!found) {
						emptyList.Add(empty);
						_2dArray[i, j] = empty;
					} else {
						_2dArray[i, j] = pixels[i, j];
					}
				}
				else { _2dArray[i, j] = pixels[i, j]; }
			}
        }
		return _2dArray;
    }

	void IGameContract.IGameModel.removeMissedPixel(PixelEmpty pixel) {
		var pixels = PixelsData.Value;
		var row = pixels.GetLength(0);
		var col = pixels.GetLength(1);
		for (int i = 0; i < row; i++) {
			for (int j = 0; j < col; j++) {
				if(pixels[i, j] is PixelEmpty) {
					if(((PixelEmpty)pixels[i, j]).PixelColor.Color.Equals(pixel.PixelColor.Color)) {
						pixels[i, j] = ((PixelEmpty)pixels[i, j]).PixelColor;
					}
				}
			}
		}
		PixelsData.SetValueAndForceNotify(pixels);
	}

	void IGameContract.IGameModel.resetState() {
		((IGameContract.IGameModel) this).initState();
	}

    ReactiveProperty<Texture2D> IGameContract.IGameModel.getTextureReactiveProperty()
    {
		return Texture;
    }

    PixelData[,] IGameContract.IGameModel.getPixels()
    {
		if(PixelsData.Value == null)
        {
			return new PixelData[0, 0];
        } else
        {
			return PixelsData.Value;
        }
    }
}
