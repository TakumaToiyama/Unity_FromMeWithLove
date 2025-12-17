using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class consecutiveTimesControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int consecutiveTimes;
    RectTransform rectTransform;
    Vector2 initialPosition = new Vector2(-150,216);
    private static consecutiveTimesControler instance;
    
    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = initialPosition;
    }

    void Start()
    {
        
    }
    void OnDestroy()
    {
        Debug.Log("destroy");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    void OnSceneLoaded( Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainScene")
        {
            rectTransform = GetComponent<RectTransform>();
            consecutiveTimes = 0;

            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = initialPosition;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addConsecutiveTimes()
    {
        consecutiveTimes++;
        moveConsecutiveImage();
    }

    public int getConsecutiveTimes()
    {
        return consecutiveTimes;
    }

    public void resetConsecutiveTimes()
    {
        consecutiveTimes = 0;
        moveConsecutiveImage();
    }

    public void moveConsecutiveImage()
    {
        if (rectTransform != null)
        {
            
        Vector2 newPosition = new Vector2(initialPosition.x + (consecutiveTimes * 15), initialPosition.y);
        rectTransform.anchoredPosition = newPosition;
        }
    }
}
