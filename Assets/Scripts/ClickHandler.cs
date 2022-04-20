using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public delegate void EventClickHandler();
    public event EventClickHandler handler;
    public void Clicked() {
        handler?.Invoke();
    }
}
