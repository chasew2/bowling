using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollectionPrefab;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;

    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;

    private void Start()
    {
        // Find all FallTrigger objects in the scene
        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        // Add IncrementScore as a listener to each pin’s OnPinFall event
        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }

        // Listen for reset button
        inputManager.OnResetPressed.AddListener(HandleReset);
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }

    private void SetPins()
    {
        // Destroy old pins before spawning new ones
        if (pinObjects)
        {
            foreach (Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }

        // Instantiate a new set of pins at the correct position
        pinObjects = Instantiate(pinCollectionPrefab, pinAnchor.position, Quaternion.identity);

        // Get all new pins and register their event listeners
        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }
}
