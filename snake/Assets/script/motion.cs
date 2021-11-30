using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motion : MonoBehaviour
{
    public List<Transform> bodyCube;
    public float distanceCube;
    public GameObject prefabCube;
    private Transform transformCube;
    public float spead = 0.02f;
    public Transform camera;
    public int fever = 1;
    private float speadSnake;


    private void Start()
    {
        transformCube = GetComponent<Transform>();
        speadSnake = (Screen.height) / 20000f;
    }
    private void Update()
    {
        
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3 (objPosition.x * fever ,transform.position.y,transform.position.z);
        MoveSnake(transform.position + transform.forward * spead * speadSnake);
        camera.position = new Vector3 (camera.position.x,camera.position.y,camera.position.z + spead * speadSnake);
    }
    private void MoveSnake(Vector3 newPosition)
    {
        float sqrDistansCube = distanceCube * distanceCube;
        Vector3 previsionPosition = newPosition;

        foreach (var bone in bodyCube)
        {
            if ((bone.position - previsionPosition).sqrMagnitude > sqrDistansCube)
            {
                var temp = bone.position;
                bone.position = previsionPosition;
                previsionPosition = temp;
            }
            else
            {
                break;
            }
        }

        transformCube.position = newPosition;

    }


}
