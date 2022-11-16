using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI TM;
    public float TimerC;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimerC += Time.deltaTime;
        TM.text = TimerC.ToString();
    }
}
