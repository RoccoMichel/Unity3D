using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool debug;

    [Header("References")]
    public static GameController instance;
    private InputAction debugAction;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        debugAction = InputSystem.actions.FindAction("Debug");
    }

    private void Update()
    {
        if (debugAction.WasPressedThisFrame()) debug = !debug;
    }

    private void OnGUI()
    {
        if (!debug) return;

        // Text
        GUI.Label(new Rect(10, 10, 100, 20), $"ms per frame: {System.Decimal.Round((decimal)(Time.deltaTime * 1000), 2)}");

        // Buttons
        if (GUI.Button(new Rect(10, 40, 100, 20), "Reload")) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (GUI.Button(new Rect(10, 70, 100, 20), "Exit")) Application.Quit(); ;
    }

    private void Reset()
    {
        transform.position = Vector3.zero;
        gameObject.tag = "GameController";
        gameObject.name = "--- GameController ---";
    }
}
