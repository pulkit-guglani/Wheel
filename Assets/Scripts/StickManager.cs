using System;
using UnityEngine;

public class StickManager : MonoBehaviour
{
    [SerializeField]
    private Stick stick;

    [SerializeField]
    private float maxSwipe = 5;

    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                StartMeasuringDistance();
                stick.EnableStick(touch);
            }

            if(touch.phase == TouchPhase.Moved)
            {
                if(GetCurrentDistance() < maxSwipe)
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
            }
        }
    }

    // TODO : Pulkit
    private float GetCurrentDistance()
    {
        throw new NotImplementedException();
    }

    // TODO : Pulkit
    private void StartMeasuringDistance()
    {
        throw new NotImplementedException();
    }
}
