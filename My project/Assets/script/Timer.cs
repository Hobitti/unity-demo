using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float timeReceived = PickUp.timeValue;
    public TextMeshProUGUI timerText;

    void Start()
    {
        DisplayTime(timeReceived);
    }

    //Update is called once per frame
    void Update()
    {
        DisplayTime(timeReceived);
    }
    void DisplayTime(float timeToDisplay)
    {

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}