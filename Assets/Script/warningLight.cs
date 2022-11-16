using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class warningLight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Light;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "block")
        {
            Light.SetActive(true);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "block")
        {
            Light.SetActive(false);
        }

    }
}
