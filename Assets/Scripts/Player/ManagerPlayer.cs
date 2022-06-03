using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPlayer : MonoBehaviour
{
    public float speed = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;
    Rigidbody rb;
    Vector3 velocity;

    bool isGrounded;

    //public Enemy enemy;
    //public EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Run();
    }

    void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (x != 0.0f || z != 0.0f)
        {
            Vector3 dir = transform.forward * z + transform.right * x;

            rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
        }
       
    }

    /*void Run()
    {
        if (enemy.detected==true || enemyController.inside==true)
        {
            speed = 5;
        }
        if (enemy.detected == false || enemyController.inside==false)
        {
            speed = 3;
        }

        if (enemyController.inside == true)
        {
            speed = 5;
        }
        if (enemyController.inside == false)
        {
            speed = 3;
        }
    }*/
}
