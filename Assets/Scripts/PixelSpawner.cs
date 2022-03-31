using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelSpawner : MonoBehaviour
{
    [SerializeField]
    private double gapMultiplier = 0.2f;
    [SerializeField]
    private int marginLeft = 10;
    [SerializeField]
    private int marginRight = 10;
    [SerializeField]
    private CameraFit cameraFit;
    [SerializeField]
    private int rows = 10;
    [SerializeField]
    private int cols = 10;
    [SerializeField]
    private GameObject pixel;
    // Start is called before the first frame update
    void Start()
    {
        double rowWidthUnit = cols + ((cols - 1) * gapMultiplier) + marginLeft + marginRight;
        double unitScale = cameraFit.sceneWidth / rowWidthUnit;
        Debug.Log("UnitScale: " + unitScale);
        Debug.Log("Something happened");
        for(int i = 0; i < rows; i++) {
            double yPos = i * unitScale;
            if(i >= 1) yPos += i * gapMultiplier * unitScale;
            double parentYPos = convertYPositionToParentPosition(yPos, rows, unitScale, gapMultiplier);
            for(int j = 0; j < cols; j++) {
                double xPos = j * unitScale;
                if(j >= 1) xPos += j * gapMultiplier * unitScale;
                double parentXPos = convertXPositionToParentPosition(xPos, cols, unitScale, gapMultiplier);
                GameObject go = Instantiate(pixel);
                go.transform.localScale = new Vector3((float) unitScale, (float) unitScale);
                go.transform.parent = gameObject.transform;
                go.transform.position = new Vector3((float) parentXPos, (float) parentYPos, 0f);
            }
		}
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
