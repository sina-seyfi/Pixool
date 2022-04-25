using UnityEngine;
using System;

public class PixelsSpawner : MonoBehaviour
{
    //public const double SCALE_MULTIPLIER_MIN = 0.5;
    //public const double SCALE_MULTIPLIER_MAX = 1.5;
    //public const double SCALE_MULTIPLIER_DEFAULT = 1.0;
    //[SerializeField, Range((float)SCALE_MULTIPLIER_MIN, (float)SCALE_MULTIPLIER_MAX)]
    //private double scaleMultiplier = SCALE_MULTIPLIER_DEFAULT;
    //public double ScaleMultiplier
    //{
    //    get { return scaleMultiplier; }
    //    set
    //    {
    //        if (value >= SCALE_MULTIPLIER_MAX) scaleMultiplier = SCALE_MULTIPLIER_MAX;
    //        else if (value >= SCALE_MULTIPLIER_MIN) scaleMultiplier = value;
    //        else scaleMultiplier = SCALE_MULTIPLIER_DEFAULT;
    //    }
    //}
    [SerializeField]
    private bool drawFromTop = false;
    public const double GAP_MIN = 0.0f;
    public const double GAP_MAX = 1.0f;
    public const double GAP_DEFAULT = 0.2f;
    [SerializeField, Range((float) GAP_MIN, (float) GAP_MAX)]
    private double gap = GAP_DEFAULT ;
    public double Gap
    {
        get { return gap; }
        set
        {
            if (value >= GAP_MAX) gap = GAP_MAX;
            else if (value >= GAP_MIN) gap = value;
            else gap = GAP_DEFAULT;
        }
    }
    public const int SCREEN_MARGIN_MIN = 1;
    public const int SCREEN_MARGIN_MAX = 20;
    public const int SCREEN_MARGIN_DEFAULT = 10;
    [SerializeField, Range(SCREEN_MARGIN_MIN, SCREEN_MARGIN_MAX)]
    private double screenMarginLeft = SCREEN_MARGIN_DEFAULT;
    public double ScreenMarginLeft
    {
        get { return screenMarginLeft; }
        set
        {
            if (value >= SCREEN_MARGIN_MAX) screenMarginLeft = SCREEN_MARGIN_MAX;
            else if (value >= SCREEN_MARGIN_MIN) screenMarginLeft = value;
            else screenMarginLeft = SCREEN_MARGIN_DEFAULT;
        }
    }
    [SerializeField, Range(SCREEN_MARGIN_MIN, SCREEN_MARGIN_MAX)]
    private double screenMarginRight = SCREEN_MARGIN_DEFAULT;
    public double ScreenMarginRight
    {
        get { return screenMarginRight; }
        set
        {
            if (value >= SCREEN_MARGIN_MAX) screenMarginRight = SCREEN_MARGIN_MAX;
            else if (value >= SCREEN_MARGIN_MIN) screenMarginRight = value;
            else screenMarginRight = SCREEN_MARGIN_DEFAULT;
        }
    }
    [SerializeField]
    private GameObject pixelPrefab;
    private GameObject[,] GOes;

    public delegate void PixelsSpawnedEvent();
    public event PixelsSpawnedEvent onSpawned;

    public double calculateRowWidth() {
        if (GOes != null && GOes.GetLength(1) >= 1) return calculateDimension(GOes.GetLength(1));
        else return 0.0;
    }

    public double calculateColHeight() {
        if (GOes != null && GOes.GetLength(0) >= 1) return calculateDimension(GOes.GetLength(0));
        else return 0.0;
    }

    public double calculateDimension(int dimensionSize) {
        return dimensionSize + ((dimensionSize - 1) * Gap);
    }

    public void Spawn(PixelData[,] pixelsData, Action<GameObject> pixelAction) {
        int rowSize = pixelsData.GetLength(0);
        int colSize = pixelsData.GetLength(1);
        bool useCacheGameObject = false;
        // Check if we already have GOes in cache...
        if (GOes != null)
        {
            int rowCacheSize = GOes.GetLength(0);
            int colCacheSize = GOes.GetLength(1);
            useCacheGameObject =
                rowSize == rowCacheSize &&
                colSize == colCacheSize;
            if (!useCacheGameObject)
            {
                for (int i = 0; i < rowCacheSize; i++)
                    for (int j = 0; j < colCacheSize; j++)
                        Destroy(GOes[i, j]);
                GOes = new GameObject[rowSize, colSize];
            }
        }
        else
        {
            GOes = new GameObject[rowSize, colSize];
        }
        double rowWidthUnit = calculateDimension(colSize) + screenMarginLeft + screenMarginRight;
        double unitScale = CameraFit.SCREEN_WIDTH / rowWidthUnit;
        for (int row = 0; row < rowSize; row++)
        {
            double yPos = -row * unitScale;
            if (row >= 1) yPos -= row * Gap * unitScale;
            double parentYPos = convertYPositionToParentPosition(yPos, rowSize, unitScale, Gap);
            for (int col = 0; col < colSize; col++)
            {
                var pixelData = pixelsData[row, col];
                if(pixelData != null) {
                    double xPos = col * unitScale;
                    if (col >= 1) xPos += col * Gap * unitScale;
                    double parentXPos = convertXPositionToParentPosition(xPos, colSize, unitScale, Gap);
                    Vector3 scale = new Vector3((float)unitScale, (float)unitScale);
                    Transform parent = gameObject.transform;
                    Vector3 position = new Vector3((float)parentXPos, (float)parentYPos, 0f);
                    GameObject go;
                    if (useCacheGameObject)
                    {
                        go = GOes[row, col];
                        // updatePixel(go, scale, parent, position);
                    }
                    else
                    {
                        go = createPixel(scale, parent, position);
                        GOes[row, col] = go;
                    }
                    Pixel pixel = go.GetComponent<Pixel>();
                    if (pixel != null) pixel.Data = pixelData;
                    if (pixelAction != null) pixelAction.Invoke(go);
                } else {
                    Destroy(GOes[row, col]);
                }
            }
        }
        if(!useCacheGameObject && onSpawned != null) {
            onSpawned.Invoke();
        }
    }
    public void Spawn(PixelData[,] pixelsData) {
        Spawn(pixelsData, null);
    }

    public void Reshape(Func<PixelData, PixelData> lambda) {
        var row = GOes.GetLength(0);
        var col = GOes.GetLength(1);
        for(int i = 0; i < row; i++) {
            for(int j = 0; j < col; j++) {
                var pixel = GOes[row, col].GetComponent<Pixel>();
                if(pixel != null) {
                    pixel.Data = lambda.Invoke(pixel.Data);
				}
			}
		}
	}

    private GameObject createPixel(Vector3 scale, Transform parent, Vector3 position) {
        GameObject pixel = Instantiate(pixelPrefab, parent);
        pixel.transform.localScale = scale;
        pixel.transform.position = position + parent.position;
        return pixel;
    }

    //private void updatePixel(GameObject pixel, Vector3 scale, Transform parent, Vector3 position) {
    //    pixel.transform.localScale = scale;
    //    pixel.transform.position = position + parent.position;
    //}

    private double convertYPositionToParentPosition(double yPos, int rows, double unitScale, double gapMultiplier) {
        double maxHeight = (rows * unitScale) + ((rows - 1) * gapMultiplier * unitScale);
        if (drawFromTop) return yPos;
        else return yPos + maxHeight / 2.0;
    }

    private double convertXPositionToParentPosition(double xPos, int cols, double unitScale, double gapMultiplier) {
        double maxWidth = (cols * unitScale) + ((cols - 1) * gapMultiplier * unitScale);
        return xPos - maxWidth / 2.0;
    }

}
