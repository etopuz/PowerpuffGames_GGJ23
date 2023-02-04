using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
     public  int LevelIndex;
    public void NextScene()
    {
        if (LevelIndex == 0)
        {
            SceneManager.LoadScene("TrainingLevel");
        }
        if (LevelIndex == 1)
        {
            SceneManager.LoadScene("Level1");
        }

        if (LevelIndex == 2)
        {
            SceneManager.LoadScene("Level2");
        }

        if (LevelIndex == 3)
        {
            SceneManager.LoadScene("Level3");
        }
        if (LevelIndex == 4)
        {
            SceneManager.LoadScene("LevelMenu");
        }
        if (LevelIndex == 5)
        {
            SceneManager.LoadScene("Credits");
        }
        if (LevelIndex == 6)
        {
            Application.Quit();
        }

        GameManager.instance.ResetGame();
    }
}
