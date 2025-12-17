using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIContoller : MonoBehaviour
{
    int score;
    float timeRemaining;
    bool timerIsRunnning = false;
    GameObject scoreText;
    GameObject timerText;    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private static UIContoller instance;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    } 
    void Start()
    {

    }

    void OnSceneLoaded( Scene scene, LoadSceneMode mode)
    {
        this.scoreText = GameObject.Find("score");
        this.timerText = GameObject.Find("timer");

        if (scene.name == "MainScene")
        {
            timerIsRunnning = true;
            score = 0;
            timeRemaining = 5;
        } else
        {
            
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if (timerIsRunnning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            } else
            {
                Debug.Log("Timer has run out!");
                timeRemaining = 0;
                timerIsRunnning = false;
                SceneManager.LoadScene("ResultScene");
            }
        }
        
        if (scoreText != null)
        {
             scoreText.GetComponent<TMP_Text>().text = "Score : " + score.ToString("D4");
        }

        if (timerText != null)
        {
            timerText.GetComponent<TMP_Text>().text = "" + Math.Round(timeRemaining,1);
        }
    }

    public void AddScore()
    {
        this.score += 1;  
    }

    public void AddTimeRemaining()
    {
        timeRemaining++;
        Debug.Log("Add time");
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;        
    }
}