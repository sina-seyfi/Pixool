using UnityEngine;

public class PixelsDataProvider: MonoBehaviour
{

    [SerializeField]
    private Texture2D Texture;

	public PixelColor[,] providePixels() {
        var pixels = Texture.GetPixels32(0);
        var root = Mathf.Sqrt(pixels.Length);
        var _2dArray = new PixelColor[(int) root, pixels.Length / (int) root];
        for(int i = 0; i < pixels.Length; i++) {
            var pixelColor = new PixelColor(pixels[i]);
            var row = i / (int) root;
            var col = i % (int) root;
            pixelColor.X = col;
            pixelColor.Y = row;
            _2dArray[row, col] = pixelColor;
        }
        return _2dArray;
    }

}
