using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManagement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        int gameStateCount = FindObjectsOfType<GameState>().Length;
        if (gameStateCount >= 1)
        {
            GameState gs = FindObjectOfType<GameState>();
            score.text = gs.GetScore();
        }     
    }
}
