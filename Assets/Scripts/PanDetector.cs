using System.Collections;
using UnityEngine;

public class PanDetector : MonoBehaviour
{

    private const float NO_VALUE = -1f;
    private const float LOCATION_THRESHOLD = 0.025f;
    private TouchControls controls;
    private Coroutine coroutine;
    public PanListener panListener;

    private void Awake()
    {
        controls = new TouchControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        controls.Pan.Enable();
        controls.Pan.PrimaryFingerTouch.started += _ => PanStarted();
        controls.Pan.PrimaryFingerTouch.canceled += _ => PanEnded();
        controls.Pan.SecondaryTouchContact.started += _ => PanEnded();
        //controls.Pan.SecondaryTouchContact.canceled += _ => {
        //    if(controls.Pan.PrimaryFingerTouch.inProgress) {
        //        PanStarted();
        //    }
        //};
    }

    private void OnDestroy()
    {
        controls.Pan.Disable();
    }

    private void PanStarted()
    {
        coroutine = StartCoroutine(CalculatePan());
    }

    private void PanEnded()
    {
        StopCoroutine(coroutine);
    }

    private IEnumerator CalculatePan()
    {
        Vector2 previousLocation = new Vector2(NO_VALUE, NO_VALUE);
        bool thresholdReached = false;
        //Debug.Log("Touchscreen Count: " + );
        //bool touchScreenAvailable = Touchscreen.current != null;
        while(true)
        {
            // TODO Very bad approach, Must get number of touches
            if(true) {
                Vector2 currentLocation = controls.Pan.PrimaryFingerPosition.ReadValue<Vector2>();
                // If we didn't init previous location, just save it as reference:
                if(previousLocation.x == NO_VALUE && previousLocation.y == NO_VALUE) {
                    previousLocation = currentLocation;
                } else {
                    if(thresholdReached) {
                        var offset = currentLocation - previousLocation;
                        previousLocation = currentLocation;
                        if (panListener != null) panListener.Pan(offset);
                    } else {
                        float thresholdAmount = ((currentLocation - previousLocation).magnitude / previousLocation.magnitude);
                        thresholdReached = thresholdAmount >= LOCATION_THRESHOLD;
                        if(thresholdReached) {
                            previousLocation = currentLocation;
                        }
                    }
                }
            }
            //else {
            //    previousLocation = new Vector2(NO_VALUE, NO_VALUE);
            //    thresholdReached = false;
            //}
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
