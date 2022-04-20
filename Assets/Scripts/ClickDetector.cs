using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDetector : MonoBehaviour
{

    private TouchControls controls;

    private void Awake()
    {
        controls = new TouchControls();
    }

    private void Start()
    {
        controls.Enable();
        controls.Click.PrimaryFingerClicked.performed += _ => ClickPerformed();
    }

    private void ClickPerformed() {
        var mousePosition = Mouse.current.position.ReadValue();
        var ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)) {
            var ClickHandler = hit.collider.gameObject.GetComponent<ClickHandler>();
            if(ClickHandler != null) { ClickHandler.Clicked(); }
        }
    }


}
