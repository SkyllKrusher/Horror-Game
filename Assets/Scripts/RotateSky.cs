using UnityEngine;

public class RotateSky : MonoBehaviour
{
    [Tooltip("Number of minutes in a day")]
    [SerializeField] float minutesPerDay = 12f;
    void Update()
    {
        RotateADegree();
    }

    private void RotateADegree()
    {
        if (minutesPerDay == 0) { return; }
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 6f / minutesPerDay);
    }
}
