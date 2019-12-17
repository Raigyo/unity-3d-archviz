using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class Clock : MonoBehaviour {
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Simple Clock Script / Andre "AEG" Bürger / VIS-Games 2012
    //
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------

    //-- set start time 00:00
    //public int minutes = 0;
    //public int hour = 0;
    private int minutes;
    private int hour;

    //used for smartphone hour display
    public TextMeshPro hourText;
    public TextMeshPro dayText;
    public TextMeshPro dateText;
    //public TextMeshPro yearText;
    private string formattedTime;

    //-- time speed factor
    public float clockSpeed = 1.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    //-- internal vars
    int seconds;
    float msecs;
    GameObject pointerSeconds;
    GameObject pointerMinutes;
    GameObject pointerHours;
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
void Start() 
{
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        pointerSeconds = transform.Find("rotation_axis_pointer_seconds").gameObject;
    pointerMinutes = transform.Find("rotation_axis_pointer_minutes").gameObject;
    pointerHours   = transform.Find("rotation_axis_pointer_hour").gameObject;

    msecs = 0.0f;
    seconds = 0;
}
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
void Update() 
{
    //-- calculate time
    msecs += Time.deltaTime * clockSpeed;
    if(msecs >= 1.0f)
    {
        msecs -= 1.0f;
        seconds++;
        if(seconds >= 60)
        {
            seconds = 0;
            minutes++;
            if(minutes > 60)
            {
                minutes = 0;
                hour++;
                if(hour >= 24)
                    hour = 0;
            }
        }
    }


    //-- calculate pointer angles
    float rotationSeconds = (360.0f / 60.0f)  * seconds;
    float rotationMinutes = (360.0f / 60.0f)  * minutes;
    float rotationHours   = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

    //-- draw pointers
    pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
    pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
    pointerHours.transform.localEulerAngles   = new Vector3(0.0f, 0.0f, rotationHours);
        //formattedTime = string.Format("{0:00}:{1:00}:{2:00}", hour, minutes, seconds);
        formattedTime = string.Format("{0:00}:{1:00}", hour, minutes);
        hourText.text =  formattedTime;
        //dayText.text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        dayText.text = DateTime.Now.ToString("dddd").ToUpper();
        //yearText.text = DateTime.Now.ToString("yyyy");
        dateText.text = DateTime.Now.ToString("dd-MM-yyyy");
    }
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
}
