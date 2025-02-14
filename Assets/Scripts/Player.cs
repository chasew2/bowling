using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed = 5f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputManager.OnMove.AddListener(MovePlayer); 
    }

    private void MovePlayer(Vector2 direction)
    {
        Vector3 moveDirection = new Vector3(direction.x, 0f, 0f);
        rb.AddForce(speed * moveDirection);
    }
}
