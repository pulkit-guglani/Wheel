using UnityEngine;

public class Stick : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 1;


    private Vector3 direction;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void DisableStick()
    {
        Debug.Log("Disabling stick...");
        // fade-out anim
        gameObject.SetActive(false);
    }

    public void Move(Touch touch)
    {
        float delX = touch.deltaPosition.x;
        float delY = touch.deltaPosition.y;
        // rb.MovePosition(transform.localPosition + new Vector3(delX, delY, 0) * touch.deltaPosition.magnitude * (speed * 0.01f) * Time.fixedDeltaTime);
        rb.MovePosition(new Vector3(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y, 0) * Time.fixedDeltaTime);
    }

    public void EnableStick(Touch touch)
    {
        Debug.Log("Enabling stick...");
        gameObject.SetActive(true);
        // fade-in anim
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y, 0);
    }
}
