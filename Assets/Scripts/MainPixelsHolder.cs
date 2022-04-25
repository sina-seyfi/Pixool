using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPixelsHolder : MonoBehaviour, PanListener
{

    [SerializeField]
    private PanDetector panDetector;
    private PixelsSpawner spawner;

    private bool isPixelsSpawned = false;

    // Start is called before the first frame update
    void Start() {
        panDetector.panListener = this;
        spawner = GetComponent<PixelsSpawner>();
        spawner.onSpawned += OnPixelsSpawned;
    }

    public void Pan(Vector2 offset) {
        if(isPixelsSpawned) {
            var point = Camera.main.ScreenToWorldPoint(offset);
            float cameraHalfHeight = Camera.main.orthographicSize;
            float cameraHalfWidth = CameraFit.SCREEN_WIDTH / 2.0f;
            transform.position = transform.position + new Vector3(point.x + cameraHalfWidth, point.y + cameraHalfHeight);
        }
    }

    private void OnPixelsSpawned() {
        isPixelsSpawned = true;
    }

}
