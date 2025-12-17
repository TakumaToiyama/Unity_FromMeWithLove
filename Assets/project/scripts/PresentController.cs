using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class PresentController : MonoBehaviour
{
    public Sprite[] presentSprites;
    int ColorNum;
    UnityEngine.Vector3 targetPosition;
    SpriteRenderer spriteRenderer;
    float speed = 100f;
    bool isMoving = false;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ColorNum = UnityEngine.Random.Range(0,5);
        // switch(ColorNum)
        // {
        //     case 0:
        //         spriteRenderer.sprite = presentSprites[ColorNum + UnityEngine.Random.Range(0,2)];
        //         break;
        //      case 1:
        //         spriteRenderer.sprite = presentSprites[ColorNum];
        //         break;
        //      case 2:
        //         spriteRenderer.sprite = presentSprites[ColorNum];
        //         break;
        //     case 3:
        //         spriteRenderer.sprite = presentSprites[ColorNum];
        //         break;
        //     default:
        //         spriteRenderer.sprite = presentSprites[ColorNum];
        //         break;
        // }

        //red
        //green
        //blue
        //yellow
        //black
        spriteRenderer.sprite = presentSprites[2 *ColorNum + UnityEngine.Random.Range(0,2)];
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            return;
        }

        float step = speed * Time.deltaTime;
        transform.position = UnityEngine.Vector3.MoveTowards(transform.position,targetPosition,step);

        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    public void MovePresentBox()
    {
        targetPosition = new UnityEngine.Vector3(transform.position.x + 3.65f, -1.83f, 0);
        isMoving = true;
    }

    // helper fanction

    public float getX()
    {
        return transform.position.x;
    }

    public int getColorNum()
    {
        return ColorNum;
    }

    public bool getIsMoving()
    {
        return isMoving;
    }

}
