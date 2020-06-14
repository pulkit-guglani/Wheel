using System;
using UnityEngine;

public class StickManager : MonoBehaviour
{
    [SerializeField]
    private Stick stick;

    [SerializeField]
    private float maxSwipe = 10000;

    private float distanceTravelled = 0;

    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                stick.EnableStick(touch);
            }

            if(touch.phase == TouchPhase.Moved)
            {
                if(GetCurrentDistance(touch.deltaPosition.magnitude) < maxSwipe)
                {
                    stick.Move(touch);
                }
                else
                {
                    stick.DisableStick();
                }
            }

            if(touch.phase == TouchPhase.Ended)
            {
                stick.DisableStick();
                distanceTravelled = 0;
            }
        }
    }
    
    private float GetCurrentDistance(float currentDistanceMoved)
    {
        distanceTravelled += currentDistanceMoved;
        return distanceTravelled;
    }
}
