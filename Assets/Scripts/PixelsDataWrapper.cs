using UnityEngine;
public abstract class PixelsDataWrapper: MonoBehaviour {

    private PixelData[,] pixelsData;
    public PixelData[,] PixelsData {
        get { return pixelsData; }
    }

    public PixelsDataWrapper(PixelsDataProvider provider) {
        pixelsData = CalculateMissedPixels(provider);
	}

    protected abstract PixelData[,] CalculateMissedPixels(PixelsDataProvider provider);

}
