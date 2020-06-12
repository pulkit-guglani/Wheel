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
                stick.EnableStick(touch);

            if(touch.phase == TouchPhase.Moved)
                stick.Move(touch);

            if(touch.phase == TouchPhase.Ended)
                stick.DisableStick();
        }
    }
}
