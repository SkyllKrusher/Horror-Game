using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text gameTimeText;
    GameTimer gameTimer;

    private void Start()
    {
        gameTimer = FindAnyObjectByType<GameTimer>();
    }

    void Update()
    {
        SetGameTimeUI(gameTimer.GameTime);
    }

    private void SetGameTimeUI(int day, int timeHH, int timeMM, string amOrPm)
    {
        gameTimeText.text = "Day " + day + " -> " + timeHH + ":" + (int)timeMM + " " + amOrPm;
    }

    private void SetGameTimeUI(TimeInfo timeInfo)
    {
        SetGameTimeUI(timeInfo.day, timeInfo.hh, timeInfo.mm, timeInfo.amOrPm);
    }
}
