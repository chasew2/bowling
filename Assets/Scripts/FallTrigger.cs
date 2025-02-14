using System;
using UnityEngine;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    public UnityEvent OnPinFall = new UnityEvent();
    private bool isPinFallen = false;

    private void OnTriggerEnter(Collider triggeredObject)
    {
        // Ensure the pin only registers falling when it touches the ground
        if (triggeredObject.CompareTag("Ground") && !isPinFallen)
        {
            isPinFallen = true;
            OnPinFall?.Invoke(); // Notify GameManager that this pin has fallen
            Debug.Log($"{gameObject.name} has fallen");
        }
    }
}
