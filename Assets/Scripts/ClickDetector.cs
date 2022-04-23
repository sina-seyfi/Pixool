using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDetector : MonoBehaviour
{

    private TouchControls controls;

    private void Awake()
    {
        controls = new TouchControls();
    }

    private void Start() {
        controls.Click.Enable();
        controls.Click.PrimaryFingerClicked.performed += _ => ClickPerformed();
    }

    private void OnDestroy() {
        controls.Click.Disable();
    }

    private void ClickPerformed() {
        var pointerPosition = controls.Click.PrimaryFingerPosition.ReadValue<Vector2>();
        var ray = Camera.main.ScreenPointToRay(pointerPosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)) {
            var ClickHandler = hit.collider.gameObject.GetComponent<ClickHandler>();
            if(ClickHandler != null) { ClickHandler.Clicked(); }
        }
    }


}
