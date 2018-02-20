using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;

    //private Rigidbody rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //float moveHorizontal = 0;
        //if (Input.GetKey("space"))
        //{
        //    moveHorizontal = speed;
        //}
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;


        var newPos = new Vector3(transform.position.x + (moveHorizontal), transform.position.y + (moveVertical), transform.position.z);
        transform.position = newPos;
    }
}