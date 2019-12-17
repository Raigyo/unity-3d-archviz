using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //Object to rotate
    public GameObject objectToRotate;
    //Rotational Speed
    public float speed = 0f;

    //Forward Direction
    public bool ForwardX = false;
    public bool ForwardY = false;
    public bool ForwardZ = false;

    //Reverse Direction
    public bool ReverseX = false;
    public bool ReverseY = false;
    public bool ReverseZ = false;



    void Update()
    {
        //Forward Direction
        if (ForwardX == true)
        {
            objectToRotate.transform.Rotate(Time.deltaTime * speed, 0, 0, Space.Self);
        }
        if (ForwardY == true)
        {
            objectToRotate.transform.Rotate(0, Time.deltaTime * speed, 0, Space.Self);
            //transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
        if (ForwardZ == true)
        {
            objectToRotate.transform.Rotate(0, 0, Time.deltaTime * speed, Space.Self);
        }
        //Reverse Direction
        if (ReverseX == true)
        {
            objectToRotate.transform.Rotate(-Time.deltaTime * speed, 0, 0, Space.Self);
        }
        if (ReverseY == true)
        {
            objectToRotate.transform.Rotate(0, -Time.deltaTime * speed, 0, Space.Self);
        }
        if (ReverseZ == true)
        {
            objectToRotate.transform.Rotate(0, 0, -Time.deltaTime * speed, Space.Self);
        }

    }
}
