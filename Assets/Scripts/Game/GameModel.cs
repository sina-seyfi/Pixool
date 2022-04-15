using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameModel : IGameContract.IGameModel
{

	public ReactiveProperty<PixelData[,]> PixelsData { get; private set; }

	ReactiveProperty<PixelData[,]> IGameContract.IGameModel.getPixels() {
		return PixelsData;
	}

	void IGameContract.IGameModel.initState() {
		PixelsData = new ReactiveProperty<PixelData[,]>();
		var texture = Resources.Load<Texture2D>("Textures/dog");
		var root = texture.width;
		var pixels = texture.GetPixels();
		var _2dArray = new PixelData[(int)root, pixels.Length / (int)root];
		for (int i = 0; i < pixels.Length; i++)
		{
			var pixelColor = new PixelColor(pixels[i]);
			var row = i / (int) root;
			var col = i % (int) root;
			pixelColor.X = col;
			pixelColor.Y = row;
			if (Utils.onChance(0.5f)) { _2dArray[row, col] = new PixelEmpty(pixelColor); }
			else { _2dArray[row, col] = pixelColor; }
		}
		PixelsData.Value = calculateMissedPixels(_2dArray);
	}

	private PixelData[,] calculateMissedPixels(PixelData[,] pixels){
		return pixels; // TODO Calculate missed pixels here...
    }

	void IGameContract.IGameModel.removeMissedPixel(PixelEmpty pixel) {
		// TODO Implemented this one...
	}

	void IGameContract.IGameModel.resetState() {
		((IGameContract.IGameModel) this).initState();
	}

}
