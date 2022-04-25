using UniRx;
using UnityEngine;
using Game;

public class GameModel : IGameContract.IGameModel
{

	public ReactiveProperty<PixelData[,]> PixelsData { get; private set; }
	public ReactiveProperty<Texture2D> Texture { get; private set; }

	private MissedPixelsCalculator mpc;

	ReactiveProperty<PixelData[,]> IGameContract.IGameModel.getPixelsReactiveProperty() {
		return PixelsData;
	}

	void IGameContract.IGameModel.initState() {
		mpc = MissedPixelsCalculatorFactory.create();
		PixelsData = new ReactiveProperty<PixelData[,]>();
		Texture = new ReactiveProperty<Texture2D>();
		var texture = Resources.Load<Texture2D>("Textures/pattern");
		Texture.Value = texture;
		var rawPixels = texture.GetPixels();
		var textureWidth = texture.width;
		var textureHeight = rawPixels.Length / textureWidth;
		var maxRows = (int) Mathf.Ceil(rawPixels.Length / (float) textureWidth);
		var pixels = new PixelData[textureWidth, textureHeight];
		for (int i = 0; i < rawPixels.Length; i++)
		{
			var pixelColor = new PixelColor(Utils.ToColor(rawPixels[i]));
			var row = i / textureWidth;
			var col = i % textureWidth;
			// Because GetPixels of texture will get us pixels inverted on x axis...
			var invertedRow = (maxRows - (row + 1));
			pixelColor.X = col;
			pixelColor.Y = invertedRow;
			pixels[invertedRow, col] = pixelColor;
		}
		var missedPixelIndexes = mpc.calculate(pixels.Select(pixel => new Game.Color(((PixelColor)pixel).Color.r, ((PixelColor)pixel).Color.g, ((PixelColor)pixel).Color.b)));
        foreach (var mpi in missedPixelIndexes) {
			var row = mpi.Item1;
			var col = mpi.Item2;
			pixels[row, col] = new PixelEmpty((PixelColor) pixels[row, col]);
        }
		PixelsData.Value = pixels;
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
