using UnityEngine;

public class ResultBackgroundController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.003f, 0, 0);
        // Debug.Log(transform.position.x < -449.08f);
        // Debug.Log(transform.localPosition.x + " "+ transform.localPosition.y);
        if (transform.localPosition.x < -440.393f)
        {
            Debug.Log("move initial position");
            transform.localPosition = new Vector3(-422f, -275.1f, 0);
        }
    }
}
