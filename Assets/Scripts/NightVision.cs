using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(PostProcessVolume))]
public class NightVision : MonoBehaviour
{
    [SerializeField]
    private Color defaultLightColor;
    [SerializeField]
    private Color boostedLightColor;

    private bool isNightVisionEnabled;

    private PostProcessVolume volume;

    void ToggleNightVision()
    {
        isNightVisionEnabled = !isNightVisionEnabled;

        if (isNightVisionEnabled)
        {
            RenderSettings.ambientLight = boostedLightColor;
            volume.weight = 1;
        }
        else
        {
            RenderSettings.ambientLight = defaultLightColor;
            volume.weight = 0;
        }
    }

    void Start()
    {
        RenderSettings.ambientLight = defaultLightColor;

        volume = gameObject.GetComponent<PostProcessVolume>();
        volume.weight = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNightVision();
        }
    }
}
