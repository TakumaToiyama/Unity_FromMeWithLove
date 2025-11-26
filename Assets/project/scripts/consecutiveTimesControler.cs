using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class consecutiveTimesControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int consecutiveTimes;
    RectTransform rectTransform;
    Vector2 initialPosition = new Vector2(-300,230);
    Image consectiveImage;
    Vector3 imagePositionX;
    
    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        // consectiveImage = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        imagePositionX = new Vector3 (-300,230,0);
    }

    void OnSceneLoaded( Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainScene")
            consecutiveTimes = 0;
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
        // imagePositionX = new Vector3 (initialX + (consecutiveTimes * 15),230,0);
        // transform.position = imagePositionX;
        Vector2 newPosition = new Vector2(initialPosition.x + (consecutiveTimes * 15), initialPosition.y);
        rectTransform.anchoredPosition = newPosition;
        Debug.Log(imagePositionX);
    }
}
