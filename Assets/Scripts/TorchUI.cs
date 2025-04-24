using UnityEngine;
using UnityEngine.UI;

public class TorchUI : MonoBehaviour
{
    [SerializeField]
    private Slider batterySlider;

    public void SetBatteryLevel(float batteryPercent)
    {
        batterySlider.value = batteryPercent;
    }
}
