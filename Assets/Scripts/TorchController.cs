using System;
using System.Collections;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    // [SerializeField]
    // private BatteryUI batteryUI;
    private float currentBattery;
    public float CurrentBattery => currentBattery;

    [SerializeField]
    private float drainTickTime = 1;
    [SerializeField]
    private float drainPerTick = 0.1f;
    [SerializeField]
    private Light torchSpotLight;
    [SerializeField]
    private float startBattery = 66;
    [SerializeField]

    private float batteryAddedPerCell = 50; //randomize later in a range
    [SerializeField]
    private TorchUI torchUI;

    bool isTorchOn = false;
    Coroutine batteryDrainCoroutine;
    private InputManager inputManager;

    private void Start()
    {
        currentBattery = startBattery;
        inputManager = InputManager.Instance;
        torchUI.SetBatteryLevel(startBattery);
        TurnOffTorch();
    }

    private void TurnOnTorch()
    {
        if (currentBattery <= 0)
        {
            return;
        }
        isTorchOn = true;
        batteryDrainCoroutine = StartCoroutine(DrainBattery());
        torchSpotLight.enabled = true;
    }

    private void TurnOffTorch()
    {
        if (batteryDrainCoroutine != null)
        {
            StopCoroutine(batteryDrainCoroutine);
        }
        torchSpotLight.enabled = false;
        isTorchOn = false;
    }

    public void ChargeBattery()
    {
        currentBattery = Mathf.Clamp(batteryAddedPerCell, 0, 100);
    }

    public void UseBattery(float batteryUsed)
    {
        currentBattery -= batteryUsed;
        if (currentBattery <= 0)
        {
            currentBattery = 0;
            TurnOffTorch();
        }
        torchUI.SetBatteryLevel(currentBattery);
    }

    private IEnumerator DrainBattery()
    {
        while (isTorchOn)
        {
            UseBattery(drainPerTick);
            yield return new WaitForSeconds(drainTickTime); ;
        }
    }

    private void Update()
    {
        if (inputManager.IsAttackPressedThisFrame())
        {
            TurnOnTorch();
        }
        else if (inputManager.IsAttackReleasedThisFrame())
        {
            TurnOffTorch();
        }
    }
}
