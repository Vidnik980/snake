using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPeople : MonoBehaviour
{
    private float y = 1.3f;
    private bool direction;
    private void Update()
    {
        if (direction == false)
        {
            y += Time.deltaTime;
            if (y > 2)
            {
                direction = !direction;
            }
        }
        if (direction == true)
        {
            y -= Time.deltaTime;
            if (y < 1.3)
            {
                direction = !direction;
            }
        }
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
