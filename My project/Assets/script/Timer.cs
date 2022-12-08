using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue = 181;
    public TextMeshProUGUI timerText;
    private bool completed = false;

    [SerializeField]
    AudioClip sound;

    //Update is called once per frame
    void Update()
    {
        if (!completed)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
            }

            DisplayTime(timeValue);
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        if (timeValue < 60)
        {

            timerText.color = Color.red;
        }

        if (timeValue == 60)
        {
            SoundManager.instance.PlaySingle(sound);
        }
        if (timeValue == 30)
        {
            SoundManager.instance.PlaySingle(sound);
        }
        if (timeValue == 10)
        {
            SoundManager.instance.PlaySingle(sound);
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
    public void LevelCompleted()
    {
        if (completed == false)
        {
            completed = true;
            SceneManager.LoadScene("LevelCompleted");
        }
    }
}
