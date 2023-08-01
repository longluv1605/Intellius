using UnityEngine;
public class Character : MonoBehaviour
{
    private float horizontal = 0;
    private bool isFacingRight = false;
    private float direction = -1;

    private float movingH = 0;
    private float movingV = 0;
    private bool moving = false;
    
    //private bool running = false;
    private float speed = 10;

    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //fixRotation();
        move();
        flipHorizontal();
    }

    private void fixRotation()
    {
        Vector3 fixRotate = transform.eulerAngles;
        if (fixRotate.z != 0)
            fixRotate.z = 0;
        transform.eulerAngles = fixRotate;
    }    

    private void move()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            direction = 1;
            horizontal = 0;

            movingV = 1;
            movingH = 0;

            moving = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direction = -1;
            horizontal = 0;

            movingV = -1;
            movingH = 0;

            moving = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
            direction = 0;

            movingV = 0;
            movingH = 1;

            moving = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
            direction = 0;

            movingV = 0;
            movingH = -1;

            moving = true;
        }
        else
        {
            movingV = 0;
            movingH = 0;

            moving = false;
        }

        // move
        rb.velocity = new Vector2(movingH * speed, movingV * speed);

        // anim
        animator.SetFloat("direction", direction);
        animator.SetBool("moving", moving);
    }

    private void flipHorizontal()
    {
        if ((isFacingRight && horizontal < 0) || (!isFacingRight && horizontal > 0))
        {
            isFacingRight = !isFacingRight;
            //transform.localScale.x = transform.localScale.x * -1;
            Vector3 scale = transform.localScale;
            scale.x = transform.localScale.x * -1;
            transform.localScale = scale;
        }
    }
}
