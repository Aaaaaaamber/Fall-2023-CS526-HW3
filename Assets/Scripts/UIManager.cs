using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;
    public GameObject gameOverPanel; // Drag your Game Over panel here in the inspector.
    public GameObject playerWonPanel; // Drag your Player Won panel here in the inspector.
    public Text totalPelletsText;
    public Text currentPelletsText;


    private void Update()
    {
        if (player != null)
        {
            totalPelletsText.text = "Total Pellets: " + player.totalPelletsCollected.ToString();
            currentPelletsText.text = "Current Pellets: " + player.currentPelletsCanUse.ToString();
        }
        switch (GameManager.instance.currentState)
        {
            case GameManager.GameState.Playing:
                if (playerWonPanel != null) playerWonPanel.SetActive(false);
                if (gameOverPanel != null) gameOverPanel.SetActive(false);
                break;
            case GameManager.GameState.GameOver:
                if (gameOverPanel != null) gameOverPanel.SetActive(true);
                break;
            case GameManager.GameState.PlayerWon:
                if (playerWonPanel != null) playerWonPanel.SetActive(true);
                break;
        }
    }
}
