using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.1f,10f)][SerializeField] float gameTimeScale = 1f;

    [SerializeField] int pointsPerBlockDestroyed;

    [SerializeField] int currentScore = 0;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] bool autoPlay = false;

    private void Awake()
    {
        // singleton
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
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
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameTimeScale;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void DestroyGameStatus()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlay()
    {
        return autoPlay;
    }
}
