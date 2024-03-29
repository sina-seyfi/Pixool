using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFit : MonoBehaviour
{
    // Set this to the in-world distance between the left & right edges of your scene.
    public static float SCREEN_WIDTH = 10f;

    Camera _camera;
    void Start() {
        _camera = GetComponent<Camera>();
    }

    // Adjust the camera's height so the desired scene width fits in view
    // even if the screen/window size changes dynamically.
    void Update() {
        float unitsPerPixel = SCREEN_WIDTH / Screen.width;
        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;
        _camera.orthographicSize = desiredHalfHeight;
    }
}
