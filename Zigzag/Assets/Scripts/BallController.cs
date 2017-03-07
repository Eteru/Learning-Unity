using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    [SerializeField]
    private float speed;
    private bool start;
    private bool gameOver;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start ()
    {
        start = false;
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!start) {
            if (Input.GetMouseButtonDown(0)) {
                start = true;
                rb.velocity = new Vector3(speed, 0, 0);
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 1f)) {
            gameOver = true;
            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            rb.velocity = new Vector3(0, -25f, 0);
        }

        if (!gameOver && Input.GetMouseButtonDown(0)) {
            SwitchDirection();
        }
    }

    private void SwitchDirection()
    {
        rb.velocity = rb.velocity.z > 0 ? new Vector3(speed, 0, 0) : new Vector3(0, 0, speed);
    }
}
