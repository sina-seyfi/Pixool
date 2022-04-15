using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameModel : IGameContract.IGameModel
{

	public ReactiveProperty<PixelData[,]> PixelsData { get; private set; }
	public ReactiveProperty<Texture2D> Texture { get; private set; }

	ReactiveProperty<PixelData[,]> IGameContract.IGameModel.getPixelsReactiveProperty() {
		return PixelsData;
	}

	void IGameContract.IGameModel.initState() {
		PixelsData = new ReactiveProperty<PixelData[,]>();
		Texture = new ReactiveProperty<Texture2D>();
		var texture = Resources.Load<Texture2D>("Textures/dog");
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
		var _2dArray = new PixelData[row, col];
		for(int i = 0; i < row; i++) {
			for(int j = 0; j < col; j++)
            {
				if (Utils.onChance(0.6f)) { _2dArray[i, j] = new PixelEmpty(pixels[i, j]); }
				else { _2dArray[i, j] = pixels[i, j]; }
			}
        }
		return _2dArray;
    }

	void IGameContract.IGameModel.removeMissedPixel(PixelEmpty pixel) {
		// TODO Implemented this one...
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
