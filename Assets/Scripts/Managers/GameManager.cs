using UnityEngine;

public class GameManager : Singleton<GameManager>
{  
    bool isPaused = false;
    bool isWin = false;
    bool isLose = false;

    public void LoseGame() {
        isLose = true;
    }

    public void WinGame() {
        isWin = true;
    }

    public void PauseGame() {
        isPaused = true;
    }
    
    public void ResumeGame() {
        isPaused = false;
    }

    void Update(){
        if (isPaused) {
            Time.timeScale = 0;
        } 
        else {
            Time.timeScale = 1;
        }
        if (isWin) {
            Debug.Log("You Win!");
        }
        else if (isLose) {
            Debug.Log("You Lose!");
        }
    }


}
