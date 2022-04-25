using System.Collections;
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

	IEnumerator ZoomDetection() {
		float originalDistance = 0f;
		Vector3? originalPosition = null;
		float originalScaleMagnitude = 0f;
		Vector3? originalScaleNormalized = null;
		Vector3? newPositionOffset = null;
		float distance = 0f;
		while(true) {
			var primaryFingerPosition = controls.PinchtoZoom.PrimaryFingerPosition.ReadValue<Vector2>();
			var secondaryFingerPosition = controls.PinchtoZoom.SecondaryFingerPosition.ReadValue<Vector2>();
			distance = Vector2.Distance(primaryFingerPosition, secondaryFingerPosition);
			if (originalDistance == 0f) {
				originalDistance = distance;
				originalScaleMagnitude = go.transform.localScale.magnitude;
				originalScaleNormalized = go.transform.localScale.normalized;
				originalPosition = go.transform.localPosition;
				var primaryFingerPositionOnScreen = Camera.main.ScreenPointToRay(primaryFingerPosition).origin;
				var secondaryFingerPositionOnScreen = Camera.main.ScreenPointToRay(secondaryFingerPosition).origin;
				var tempVector = (primaryFingerPositionOnScreen + secondaryFingerPositionOnScreen) / 2.0f;
				var centerOfTwoFingers = new Vector3(tempVector.x, tempVector.y, transform.localPosition.z);
				newPositionOffset = centerOfTwoFingers - originalPosition;
			} else {
				//// Applying scale
				// Factor < 1 when we are zooming in. (Fingers get closer to each other)
				// Factor > 1 when are zooming out. (Fingers go far from each other)
				float factor = distance / originalDistance;
				// Short for: factor + ((factor - 1f) * (speed - 1f))
				float mappedFactor = factor * speed - speed + 1;
				float newScaleMagnitude = originalScaleMagnitude * mappedFactor;
				float clampedScale = 0f;

				if (newScaleMagnitude < minScale) clampedScale = minScale;
				else if (newScaleMagnitude > maxScale) clampedScale = maxScale;
				else clampedScale = newScaleMagnitude;

				if(clampedScale != newScaleMagnitude) {
					mappedFactor *= clampedScale / newScaleMagnitude;
                }
				go.transform.localScale = ((Vector3) originalScaleNormalized) * clampedScale;
				go.transform.localPosition = (Vector3) originalPosition + (Vector3) newPositionOffset * (1 - mappedFactor);
			}
			yield return null;
		}
	}
}
