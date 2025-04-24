using System;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    private float currentBattery;
    public float CurrentBattery => currentBattery;

    private float startBattery = 66;
    private float batteryAddedPerCell = 50; //randomize later in a range

    private void Start()
    {
        currentBattery = startBattery;
    }

    private void ChargeBattery()
    {
        currentBattery = Mathf.Clamp(batteryAddedPerCell, 0, 100);
    }

    private void UseBattery(float batteryUsed)
    {
        currentBattery -= batteryUsed;
    }
}
