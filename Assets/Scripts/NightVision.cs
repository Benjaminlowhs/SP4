using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(PostProcessVolume))]
public class NightVision : MonoBehaviour
{
    [SerializeField]
    Color defaultLightColor;
    [SerializeField]
    Color boostedLightColor;

    bool isNightVisionEnabled;
    float nightVisionBattery;

    PostProcessVolume volume;

    void ToggleNightVision()
    {
        if (nightVisionBattery < 0)
            return;

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

        nightVisionBattery = 100f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNightVision();
        }

        if (isNightVisionEnabled)
            nightVisionBattery -= 0.3f * Time.deltaTime;
    }
}
