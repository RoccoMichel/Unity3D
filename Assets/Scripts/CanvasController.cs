using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Feel free to remove the following!
        if (GetComponent<CanvasScaler>().uiScaleMode == CanvasScaler.ScaleMode.ConstantPixelSize)
            Debug.LogWarning($"{gameObject.name} is currently set to 'Constant Pixel Size', this is usually undesired!");
        if (FindAnyObjectByType<EventSystem>() == null)
            Debug.LogWarning("No Event System in Scene!");

        // EXAMPLE:
        // InstantiateMenu("BasicMenu");
    }

    /// <summary>
    /// Instantiate GameObject onto Canvas from ResourceFolder
    /// </summary>
    /// <param name="resourceName">Prefab path within "Resources/UI/"</param>
    /// <return>The Instantiated GameObject (child of CanvasController)</return>
    public GameObject InstantiateMenu(string resourceName)
    {
        return Instantiate((GameObject)Resources.Load($"UI/{resourceName}"), transform);
    }

    private void Reset()
    {
        gameObject.name = "--- Canvas ---";
    }
}
