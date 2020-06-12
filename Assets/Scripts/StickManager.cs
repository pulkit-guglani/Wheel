using UnityEngine;

public class StickManager : MonoBehaviour
{
    [SerializeField]
    private Stick stick;

    [SerializeField]
    private float maxSwipe = 5;

    void FixedUpdate()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                stick.EnableStick(touch);
            }

            if(touch.phase == TouchPhase.Moved)
            {
                Debug.Log("move magni : " + touch.deltaPosition.magnitude);

                // if(touch.deltaPosition.magnitude < maxSwipe)
                if(true)
                {
                    stick.Move(touch); 
                }
                else
                {
                    stick.DisableStick();
                }
            }
        }
    }
}
