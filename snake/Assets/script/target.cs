using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class target : MonoBehaviour
{
    public motion motion;
    public Text cointText;
    public int coint;
    private float timer;
    private float timerfever;
    private bool fever;
    private int combo = 1;

    private void Update()
    {
        timer -= Time.deltaTime;
        timerfever -= Time.deltaTime;
        if (timerfever < 0)
        {
            motion.fever = 1;
            motion.spead = 1;
        }
    }
    private void FixedUpdate()
    {
        if (timerfever > 0)
        {
            coint++;
            cointText.text = "Кр: " + coint.ToString();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
       /*
       if (other.gameObject.tag == "health")
        {
            other.GetComponent<MeshRenderer>().enabled = false;
            var bone = Instantiate(motion.prefabCube);
            bone.transform.parent = motion.gameObject.transform.parent.transform;
            motion.bodyCube.Add(bone.transform);
        }
       */
        if (other.gameObject.tag == "damage")
        {
            // other.GetComponent<MeshRenderer>().enabled = false;
            // Destroy(motion.bodyCube[motion.bodyCube.Count - 1].gameObject);
            // motion.bodyCube.RemoveAt(motion.bodyCube.Count - 1);
            feverMode(other);
        } 
        if (other.gameObject.tag == "people")
        {
           if( gameObject.GetComponent<Renderer>().material.color == other.gameObject.GetComponent<Renderer>().material.color)
            {
                other.GetComponent<MeshRenderer>().enabled = false;
                var bone = Instantiate(motion.prefabCube);
                bone.GetComponent<Renderer>().material.color = other.gameObject.GetComponent<Renderer>().material.color;
                bone.transform.parent = motion.gameObject.transform.parent.transform;
                motion.bodyCube.Add(bone.transform);
            }
            else
            {
                feverMode(other);
            }
        }
        if (other.gameObject.tag == "crystal")
        {
           
            if (timer > 0)
            {
                combo++;
            }
            else
            {
                combo = 1;
            }
            if (combo == 3)
            {
                motion.fever = 0;
                motion.spead = 3;
                timerfever = 5;
                
            }
            timer = 1;
            coint++;
            cointText.text = "Кр: " + coint.ToString();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(0);
        }
       
    }
    private void feverMode(Collider other)
    {
        if (motion.fever == 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

}
