using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PixelsSpawner : MonoBehaviour
{
    private double gap = 0.2f;
    private double screenMarginLeft = 10;
    private double screenMarginRight = 10;
    [SerializeField]
    private CameraFit CameraFit;
    [SerializeField]
    private GameObject pixelPrefab;
    private GameObject[,] GOes;
    public void Spawn(PixelData[,] pixelsData) {
        int rows = pixelsData.GetLength(0);
        int cols = pixelsData.GetLength(1);
        double rowWidthUnit = cols + ((cols - 1) * gap) + screenMarginLeft + screenMarginRight;
        double unitScale = CameraFit.sceneWidth / rowWidthUnit;
        GOes = new GameObject[rows, cols];
        for(int row = 0; row < rows; row++) {
            double yPos = row * unitScale;
            if(row >= 1) yPos += row * gap * unitScale;
            double parentYPos = convertYPositionToParentPosition(yPos, rows, unitScale, gap);
            for(int col = 0; col < cols; col++) {
                var pixelData = pixelsData[row, col];
                double xPos = col * unitScale;
                if(col >= 1) xPos += col * gap * unitScale;
                double parentXPos = convertXPositionToParentPosition(xPos, cols, unitScale, gap);
                Vector3 scale = new Vector3((float) unitScale, (float) unitScale);
                Transform parent = gameObject.transform;
                Vector3 position = new Vector3((float) parentXPos, (float) parentYPos, 0f);
                GameObject go = createPixel(scale, parent, position);
                GOes[row, col] = go;
                Pixel pixel = go.GetComponent<Pixel>();
                if(pixel != null) {
                    pixel.Data = pixelData;
				}
            }
        }
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
        GameObject pixel = Instantiate(pixelPrefab);
        pixel.transform.localScale = scale;
        pixel.transform.parent = parent;
        pixel.transform.position = position;
        return pixel;
    }

    private double convertYPositionToParentPosition(double yPos, int rows, double unitScale, double gapMultiplier) {
        double maxHeight = (rows * unitScale) + ((rows - 1) * gapMultiplier * unitScale);
        return yPos - maxHeight / 2.0;
    }

    private double convertXPositionToParentPosition(double xPos, int cols, double unitScale, double gapMultiplier) {
        double maxWidth = (cols * unitScale) + ((cols - 1) * gapMultiplier * unitScale);
        return xPos - maxWidth / 2.0;
    }

}
