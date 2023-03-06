using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
     public  int LevelIndex;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {     
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            BasePlayer player = other.transform.GetComponent<BasePlayer>();
            PlayerPrefs.SetInt("PlayerHealth", player.health);
            PlayerPrefs.Save();
        }
    }
    
    public void NextScene()
    {
 
        if (LevelIndex == 0)
        {
            SceneManager.LoadScene("TutorialLevel");
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
            SceneManager.LoadScene("StartScene");
        }
        if (LevelIndex == 5)
        {
            SceneManager.LoadScene("Credits");
        }
        if (LevelIndex == 6)
        {
            Application.Quit();
        }
        if (LevelIndex == 7)
        {
            SceneManager.LoadScene("Entry");
        }
        
        GameManager.instance.ResetGame();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.instance.ResetGame();
    }
}
