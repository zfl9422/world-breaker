using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    // config
    [Range(0.1f, 4f)] [SerializeField] float time = 1f;
    [SerializeField] int pointsPerBlock = 100;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool autoPlayEnabled;

    // state
    [SerializeField] int score = 0;

    public void Restart()
    {
        Destroy(gameObject);
    }
    private void Awake()
    {
        // Singleton Pattern implementation
        // On Awake, only destory this game object if it has been previously created (Level 1)
        int gameStateCount = FindObjectsOfType<GameState>().Length;

        if (gameStateCount > 1)
        {
            gameObject.SetActive(false); 
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        ScoreDisplayUpdate();
    }

    // Update is called once per frame
    private void Update()
    {
        Time.timeScale = time;
    }
    public void ScoreUpdate()
    {
        score += pointsPerBlock;
        ScoreDisplayUpdate();
    }

    private void ScoreDisplayUpdate()
    {
        scoreText.text = score.ToString();
    }

    public bool getAutoPlayEnabled()
    {
        return autoPlayEnabled;
    }

    public string GetScore()
    {
        return scoreText.text;
    }
}
