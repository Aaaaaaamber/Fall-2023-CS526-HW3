using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  // Singleton instance.

    public enum GameState
    {
        Playing,
        GameOver,
        PlayerWon
    }

    public GameState currentState = GameState.Playing;
    public GameObject gameOverPanel; // Drag your Game Over panel here in the inspector.
    public GameObject playerWonPanel; // Drag your Player Won panel here in the inspector.

    private void Awake()
    {
        // Singleton pattern implementation.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        // Initially hide the game over and player won panels.
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        Debug.Log("gameOver set false!");
        if (playerWonPanel != null) playerWonPanel.SetActive(false);
    }

    // When the game is over.
    public void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0;
        currentState = GameState.GameOver;
        Debug.Log("Game Over!");
        //SceneManager.LoadScene("end");
        RestartGame();
        Debug.Log("Restart Game!");
    }

    public void PlayerWon()
    {
        // RestartGame();
/*        if (playerWonPanel != null)
        {
            playerWonPanel.SetActive(true);
        }
*/
        // Optionally, if you want the game to pause when player wins.
        Time.timeScale = 0;

        currentState = GameState.PlayerWon;
       //layerWonPanel.SetActive(true);
        Debug.Log("Player Won!");
        SceneManager.LoadScene("win");
        RestartGame();
    }

    // Function to restart the game.
    public void RestartGame()
    {
        // Reset the game time scale if you've set it to 0 earlier.
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene("Background", LoadSceneMode.Additive);
        SceneManager.LoadScene("GameStart", LoadSceneMode.Additive);
        currentState = GameState.Playing;
    }
}
