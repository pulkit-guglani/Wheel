using UnityEngine;

public class Stick : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 1;


    private Vector3 direction;
    private Vector3 touchPosition;
    private float moveSpeed = 20f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void DisableStick()
    {
        Debug.Log("Disabling stick...");
        rb.velocity = Vector2.zero;
        // fade-out anim
        gameObject.SetActive(false);
    }

    public void Move(Touch touch)
    {
        touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        touchPosition.z = 0;
        direction = (touchPosition - transform.position);
        rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
    }

    public void EnableStick(Touch touch)
    {
        Debug.Log("Enabling stick...");
        gameObject.SetActive(true);
        // fade-in anim
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y, 0);
    }
}
