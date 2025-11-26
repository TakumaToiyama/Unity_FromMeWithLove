using System;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenPresentBox : MonoBehaviour
{
    public GameObject presentBox;
    private consecutiveTimesControler consecutiveControler;
    List<PresentController> PresentsList = new List<PresentController>();
    // int consecutiveTimes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Awake()
    // {
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }
    void Start()
    {
        genBox(0);
        genBox(-5);
        genBox(-10);

        GameObject CanvasObject = GameObject.FindWithTag("Canvas");
        // 【重要】Findで得られたGameObjectからGetComponentを使ってスクリプトを取得する
        consecutiveControler = CanvasObject.GetComponent<consecutiveTimesControler>();
    }

    // void OnSceneLoaded( Scene scene, LoadSceneMode mode)
    // {
    //     if (scene.name == "MainScene")
    //         consecutiveTimes = 0;
    // }

    

    // Update is called once per frame
    void Update()
    {
        if (IsWASDandSpace() && !PresentsList[0].getIsMoving())
        {
            if (IsCorrectInput(PresentsList[0].getColorNum()))
            {
                MoveAllPresentBox();
                genBox(-10);

                GameObject.Find("Canvas").GetComponent<UIContoller>().AddScore();

                // consecutiveTimes++;
                consecutiveControler.addConsecutiveTimes();
                
                // if (consecutiveTimes == 20)
                if (consecutiveControler.getConsecutiveTimes() == 20)
                {
                    GameObject.Find("Canvas").GetComponent<UIContoller>().AddTimeRemaining();
                    // consecutiveTimes = 0;
                    consecutiveControler.resetConsecutiveTimes();
                }
            } else 
            {
                // consecutiveTimes = 0;
                consecutiveControler.resetConsecutiveTimes();
            }

        // Debug.Log(consecutiveTimes);
            Debug.Log(consecutiveControler.getConsecutiveTimes());
        }
        

    }

    bool IsWASDandSpace()
    {
        if (Input.anyKeyDown && 
        (Input.GetKeyDown(KeyCode.W) ||
        Input.GetKeyDown(KeyCode.A) ||
        Input.GetKeyDown(KeyCode.S) ||
        Input.GetKeyDown(KeyCode.D) ||
        Input.GetKeyDown(KeyCode.F) ||
        Input.GetKeyDown(KeyCode.Space))) 
        {
            Debug.Log("press key");
            return true;
        }
        return false;
    }

    bool IsCorrectInput(int colorNum)
    {
        if (Input.GetKeyDown(KeyCode.W) && colorNum == 0) return true;
        if (Input.GetKeyDown(KeyCode.A) && colorNum == 1) return true;
        if (Input.GetKeyDown(KeyCode.S) && colorNum == 2) return true;
        if (Input.GetKeyDown(KeyCode.D) && colorNum == 3) return true;
        if (Input.GetKeyDown(KeyCode.Space) && colorNum == 4) return true;
        if (Input.GetKeyDown(KeyCode.F)) return true;

        return false;
    }

    void genBox(int x)
    {
        GameObject obj = Instantiate(presentBox, new Vector3(x,0,0),Quaternion.identity);
        PresentsList.Add(obj.GetComponent<PresentController>());
    }

    void MoveAllPresentBox()
    {
        Boolean RemoveItem = false;
        foreach (PresentController present in PresentsList)
        {
            if (present.getX() == 0)
            {
                RemoveItem = true;
            } else
            {
                present.MovePresentBox();
            }
        }

        if (RemoveItem)
        {
            Destroy(PresentsList[0].gameObject);
            PresentsList.RemoveAt(0);
        }
    }
}
