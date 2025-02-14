using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;
    [SerializeField] private InputManager inputManager;

    private bool isBallLaunched;
    private Rigidbody ballRB;

    private void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);

        // Attach ball to the player before launch
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
    }

    private void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;

        // Detach ball from player
        transform.parent = null;
        ballRB.isKinematic = false;

        // Apply launch force
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);

        // Hide the launch indicator after firing
        launchIndicator.gameObject.SetActive(false);
    }

    public void ResetBall()
    {
        isBallLaunched = false;

        // Reset physics
        ballRB.isKinematic = true;
        ballRB.linearVelocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;

        // Reattach ball to player
        launchIndicator.gameObject.SetActive(true);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
    }
}
