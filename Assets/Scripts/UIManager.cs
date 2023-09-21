using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;
    public Text totalPelletsText;
    public Text currentPelletsText;

    private void Update()
    {
        if (player != null)
        {
            totalPelletsText.text = "Total Pellets: " + player.totalPelletsCollected.ToString();
            currentPelletsText.text = "Current Pellets: " + player.currentPelletsCanUse.ToString();
        }
    }
}
