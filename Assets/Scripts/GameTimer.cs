using UnityEditor.Rendering;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private float startHour = 1f;
    private float inGameHoursPassed; // in hours
    private float startTime;
    public float speedUp = 24;
    private TimeInfo gameTime;
    public TimeInfo GameTime => gameTime;

    private void Start()
    {
        inGameHoursPassed = startHour;
        startTime = Time.time;
        gameTime = new();
    }

    void Update()
    {
        inGameHoursPassed = (Time.time - startTime) * speedUp / 360f + startHour;

        int timeHH = (int)(inGameHoursPassed % 12);
        float timeMM = (int)inGameHoursPassed;
        timeMM = inGameHoursPassed - timeMM;
        timeMM *= 60;
        timeMM = (int)timeMM;
        string amOrPm = (inGameHoursPassed % 24 < 12) ? "AM" : "PM";
        int day = (int)inGameHoursPassed / 24;

        gameTime.day = day;
        gameTime.hh = timeHH;
        gameTime.mm = (int)timeMM;
        gameTime.amOrPm = amOrPm;
    }
}

public struct TimeInfo
{
    public int day;
    public int hh;
    public int mm;
    public string amOrPm;
}
