using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchDetection : MonoBehaviour
{
	[SerializeField]
	private float speed = 1f;
	[SerializeField]
	private float minScale = 0.5f;
	[SerializeField]
	private float maxScale = 3.0f;
    private TouchControls controls;
	private Coroutine zoomCoroutine;
	[SerializeField]
	private GameObject go;
	private void Awake() {
		controls = new TouchControls();
	}
	private void Start() {
		controls.PinchtoZoom.SecondaryTouchContact.started += _ => ZoomStart();
		controls.PinchtoZoom.SecondaryTouchContact.canceled += _ => ZoomEnd();
	}
	private void ZoomStart() {
		zoomCoroutine = StartCoroutine(ZoomDetection());
	}
	private void ZoomEnd() {
		StopCoroutine(zoomCoroutine);
	}
	IEnumerator ZoomDetection() {
		float previousDistance = 0f, distance = 0f;
		while(true) {
			distance = Vector2.Distance(controls.PinchtoZoom.PrimaryFingerPosition.ReadValue<Vector2>(), controls.PinchtoZoom.SecondaryFingerPosition.ReadValue<Vector2>());
			// Detection
			// Zoom Out
			if(previousDistance > 0f) {
				// Factor < 0 when we are zooming in. (Fingers get closer to each other)
				// Factor > 0 when are zooming out. (Fingers go far from each other)
				float factor = distance / previousDistance;
				Vector3 oldScale = go.transform.localScale;
				// Short for: factor + ((factor - 1f) * (speed - 1f))
				Vector3 newScale = oldScale * (factor * speed - speed + 1);
				float newScaleMagnitude = newScale.magnitude;
				if(newScaleMagnitude < minScale) {
					go.transform.localScale = newScale.normalized * minScale;
				} else if(newScaleMagnitude > maxScale) {
					go.transform.localScale = Vector3.ClampMagnitude(newScale, maxScale);
				} else if(newScaleMagnitude > minScale && newScaleMagnitude < maxScale) {
					go.transform.localScale = newScale;
				}
			}
			previousDistance = distance;
			yield return null;
		}
	}
}
