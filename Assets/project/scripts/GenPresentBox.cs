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
    Vector3 box1 = new Vector3(0f,-1.83f,0);
    Vector3 box2 = new Vector3(-3.65f,-1.83f,0);
    Vector3 box3 = new Vector3(-7.3f,-1.83f,0);
    void Start()
    {
        genBox(box1);
        genBox(box2);
        genBox(box3);

        GameObject CanvasObject = GameObject.FindWithTag("Canvas");
        // 【重要】Findで得られたGameObjectからGetComponentを使ってスクリプトを取得する
        consecutiveControler = CanvasObject.GetComponent<consecutiveTimesControler>();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (IsWASDandSpace() && !PresentsList[0].getIsMoving())
        {
            if (IsCorrectInput(PresentsList[0].getColorNum()))
            {
                MoveAllPresentBox();
                genBox(box3);

                GameObject.Find("Canvas").GetComponent<UIContoller>().AddScore();

                // consecutiveTimes++;
                consecutiveControler.addConsecutiveTimes();
                
                if (consecutiveControler.getConsecutiveTimes() == 20)
                {
                    GameObject.Find("Canvas").GetComponent<UIContoller>().AddTimeRemaining();
                    // consecutiveTimes = 0;
                    consecutiveControler.resetConsecutiveTimes();
                }
            } else 
            {
                // consecutiveTimes = 0;
                // consecutiveControler.resetConsecutiveTimes();
            }
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

    void genBox(Vector3 presentVector)
    {
        GameObject obj = Instantiate(presentBox, presentVector,Quaternion.identity);
        PresentsList.Add(obj.GetComponent<PresentController>());
    }

    void MoveAllPresentBox()
    {
        Destroy(PresentsList[0].gameObject);
        PresentsList.RemoveAt(0);
        foreach (PresentController present in PresentsList)
        {
            present.MovePresentBox();
        }
    }
}
