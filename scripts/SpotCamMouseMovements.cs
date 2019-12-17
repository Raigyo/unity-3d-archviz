using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotCamMouseMovements : MonoBehaviour
{
    //public Transform firstTarget; // target = camera hotspot
    public static SpotCamMouseMovements instance; // instance of class 

    //Scriptable Object ScriptableVars.cs
    public ScriptableVars MenuData;

    // first hotspot
    //public Transform firstTarget;
    //reference of SpotCam (Main Camera)
    public GameObject m_SpotCam;

    //Parameters for the SpotCam
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;
    public float distanceMin = .5f;
    public float distanceMax = 15f;
    private Rigidbody thisRigidbody;
    float x = 0.0f;
    float y = 0.0f;
    public float smoothing = 5f;
    public Transform target;

    //Objects that have to become transparent if the camera collides to them
    public List<GameObject> colliderTransparencyObj;
    private Transform _selection;

    // Use this for initialization
    void Start()
    {
        //target = MenuData.targetGlobal;
        instance = this;
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        thisRigidbody = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (thisRigidbody != null)
        {
            thisRigidbody.freezeRotation = true;
        }
    }

    void Update()
    {
        //Target = Camera hotspot / Can be changed by SpotCamChangeRoom
        if (target)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            y = ClampAngle(y, yMinLimit, yMaxLimit);
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);


            //camera position
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;
            transform.rotation = rotation;
            transform.position = position;
        }
    }

    //Calculate camera angle
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
        {
            angle += 360F;
        }
        if (angle > 360F)
        {
            angle -= 360F;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
