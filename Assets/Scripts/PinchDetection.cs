using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchDetection : MonoBehaviour
{
	[SerializeField]
	private float speed = 1f; // TODO Fix speed issue with paning when zooming...
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
		controls.PinchtoZoom.Enable();
		controls.PinchtoZoom.SecondaryTouchContact.started += _ => ZoomStart();
		controls.PinchtoZoom.SecondaryTouchContact.canceled += _ => ZoomEnd();
	}
    private void OnDestroy() {
		controls.PinchtoZoom.Disable();
    }
    private void ZoomStart() {
		Debug.Log("Pinch to Zoom started");
		zoomCoroutine = StartCoroutine(ZoomDetection());
	}
	private void ZoomEnd() {
		StopCoroutine(zoomCoroutine);
	}

	private float mapFactorWithSpeed(float factor) {
		// Short for: factor + ((factor - 1f) * (speed - 1f))
		return factor * speed - speed + 1;
	}

	IEnumerator ZoomDetection() {
		// For scaling/paning section:
		float previousDistance = 0f, distance = 0f;
		// For scaling section:
		float originalDistance = 0f;
		Vector3? centerOfTwoFingers = null;
		Vector3? oldPosition = null;
		Vector3? newPositionOffset = null;
		while(true) {
			var primaryFingerPosition = controls.PinchtoZoom.PrimaryFingerPosition.ReadValue<Vector2>();
			var secondaryFingerPosition = controls.PinchtoZoom.SecondaryFingerPosition.ReadValue<Vector2>();
			distance = Vector2.Distance(primaryFingerPosition, secondaryFingerPosition);
			if (originalDistance == 0f) {
				originalDistance = distance;
				var primaryFingerPositionOnScreen = Camera.main.ScreenPointToRay(primaryFingerPosition).origin;
				var secondaryFingerPositionOnScreen = Camera.main.ScreenPointToRay(secondaryFingerPosition).origin;
				var tempVector = (primaryFingerPositionOnScreen + secondaryFingerPositionOnScreen) / 2.0f;
				centerOfTwoFingers = new Vector3(tempVector.x, tempVector.y, transform.localPosition.z);
				oldPosition = go.transform.position;
				newPositionOffset = centerOfTwoFingers - oldPosition;
			}
			// Detection
			// Zoom Out
			if (previousDistance > 0f) {
                //// Applying scale
				// Factor < 0 when we are zooming in. (Fingers get closer to each other)
				// Factor > 0 when are zooming out. (Fingers go far from each other)
				float factor = distance / previousDistance;
				Vector3 oldScale = go.transform.localScale;
				Vector3 newScale = oldScale * mapFactorWithSpeed(factor);
				float newScaleMagnitude = newScale.magnitude;
				if(newScaleMagnitude < minScale) {
					go.transform.localScale = newScale.normalized * minScale;
				} else if(newScaleMagnitude > maxScale) {
					go.transform.localScale = Vector3.ClampMagnitude(newScale, maxScale);
				} else if(newScaleMagnitude > minScale && newScaleMagnitude < maxScale) {
					go.transform.localScale = newScale;
				}
				//// Applying position (to pan):
				var panFactor = distance / originalDistance;
				Vector3 newPosition = (Vector3) oldPosition + (Vector3) newPositionOffset * (1 - panFactor) * speed;
				go.transform.position = newPosition;
			}
			previousDistance = distance;
			yield return null;
		}
	}
}
