using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    public bool smoothClock;
    public Transform longArm;
    public Transform shortArm;
    public Transform secondsArm;

    const float degreesPerHour = 30f;
    const float degreesPerSecond = 6f;
    const float degreesPerMinute = 6f;

    // Update is called once per frame
    void Update()
    {
        if ( smoothClock)
        {
            UpdateSmooth();
        }
        else
        {
            UpdateDiscrete();
        }
    }

    void UpdateDiscrete()
    {
        DateTime time = DateTime.Now;
        shortArm.localRotation = Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
        longArm.localRotation = Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
        secondsArm.localRotation = Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
    }

    void UpdateSmooth()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        shortArm.localRotation = Quaternion.Euler(0f, (float) time.TotalHours * degreesPerHour, 0f);
        longArm.localRotation = Quaternion.Euler(0f, (float) time.TotalMinutes * degreesPerMinute, 0f);
        secondsArm.localRotation = Quaternion.Euler(0f, (float) time.TotalSeconds * degreesPerSecond, 0f);
    }
}
