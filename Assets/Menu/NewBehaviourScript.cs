using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Slider boostBar;
    public Image Fill;
    public float maxTime = 10.0f;
    public static float currTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        currTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        boostBar.value = (currTime / maxTime);
        if (currTime / maxTime < .333)
        {
            Fill.color = Color.red;
        }
        else
        {
            Fill.color = Color.green;
        }
        if (currTime < maxTime)
        {
            currTime += Time.deltaTime;
        }
    }
}
