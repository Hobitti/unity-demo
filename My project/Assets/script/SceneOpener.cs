using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpener : MonoBehaviour
{

    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void OpenLevels()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void OpenGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LevelFailed()
    {
        SceneManager.LoadScene("LevelFailed");
    }

}
