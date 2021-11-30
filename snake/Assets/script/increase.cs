using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increase : MonoBehaviour
{
    private float i = 1f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "health")
        {
            i += 0.2f;
            transform.localScale = new Vector3(i, i, i);
        }


        if (other.gameObject.tag == "color")
        {
            gameObject.GetComponent<Renderer>().material.color = other.gameObject.GetComponent<Renderer>().material.color;
        }
        if (other.gameObject.tag == "Finish")
        {
            
        }
    }
            private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "health")
        {
            i -= 0.2f;
            transform.localScale = new Vector3(i, i, i);
        }

       
    }
}