using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PickUp : MonoBehaviour
{

    private Inventory inventory;
    public GameObject item;
    [SerializeField] Canvas Canvas;
    bool cd = false;

    public float timeValue = 181;
    public TextMeshProUGUI timerText;
    private bool completed = false;
    public bool StartTimer = false;

    [SerializeField]
    AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

    }
    void Update()
    {
        if (!completed)
        {
            if (StartTimer == true)
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
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            StartTimer = true;
            SoundManager.instance.PlaySingle(sound);

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (!inventory.isFull[i] && !cd)
                {
                    inventory.isFull[i] = true;
                    Instantiate(item, inventory.slots[i].transform, false);
                    Canvas.transform.GetChild(i).GetComponent<Slot>().item = gameObject;
                    gameObject.SetActive(false);
                    break;
                }

            }
            cd = false;
        }
    }
    public void pickUpCD()
    {
        cd = true;
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
        if (timeValue == 0)
        {
            FindObjectOfType<SceneOpener>().LevelFailed();
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
