using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{  
    public bool isPaused = false;
    public bool isWin = false;
    public bool isLose = false;
    public bool isPlaying = true;

    public GameObject deathCanvas;

    private void Start() {
        deathCanvas = (GameObject) Resources.Load("DeathScreen");
    }
    public void ResetGame(){
        isPaused = false;
        isWin = false;
        isLose = false;
        isPlaying = true;
    }

    public void LoseGame() {
        isLose = true;
        Instantiate(deathCanvas);
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
            isPlaying = false;
        } 
        else {
            Time.timeScale = 1;
            isPlaying = true;
        }
        if (isWin) {
            Debug.Log("You Win!");
            Time.timeScale = 0;
            isPlaying = false;
        }
        else if (isLose) {
            Debug.Log("You Lose!");
            Time.timeScale = 0;
            isPlaying = false;
        }
    }




}
