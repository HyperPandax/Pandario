using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

//[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{

    public float maxSpeed = 10f;

    bool facingRight = true;

    [SerializeField]
    private LayerMask whatIsGround;
    private Transform groundCheck;
    const float groundedRadius = .2f;
    private bool grounded;

    public float jumpForce = 1000f;

    float move;

    private Rigidbody2D Rigidbody2D;

    private float gravityStore;

    private float startPosX = 0;
    private float startPosY = 7;

    private GameManager gm;

    void Start () {

        Rigidbody2D = GetComponent<Rigidbody2D> ();
        gravityStore = Rigidbody2D.gravityScale;
        groundCheck = transform.Find ("GroundCheck");
        //print("GroundCheck" + groundCheck);
        gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
        //StartCoroutine (CoUpdate());
    }

    public void FixedUpdate () {
        //Jump();
        grounded = false;
       
        //print("groundCheck.position: " + groundCheck.position);
       // print("groundedRadius: " + groundedRadius);
        //print("whatIsGround: " + whatIsGround);

        Collider2D[] colliders = Physics2D.OverlapCircleAll (groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++) {
            //print("colliders[i]" + colliders[i].name);
            if (colliders[i].gameObject != gameObject)
                grounded = true;
        }
        //print("grounded: " + grounded);

        float move = Input.GetAxis("Horizontal");

        if (move > 0 && !facingRight)
            Flip ();
        else if (move < 0 && facingRight)
            Flip ();

        GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
    }
    
    void Update () {
       
            if (Input.GetKey(KeyCode.Space))
            {
                print("space is down");
                if (grounded)
                {
                    print("grounded");
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                    return;
                    //yield return new WaitForSeconds(2);
                }
            }
    }
    
    void Flip () {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void gotoRespawnLocation () {
        {
            transform.position = new Vector3 (startPosX, startPosY, 0);
        }
    }

    //public void Jump () {

    //    if (grounded) {
    //        //anim.SetBool ("Ground", false);
    //        GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
    //    }
    //}

    public void OnTriggerEnter2D (Collider2D collision) {
        //print(collision.name);
        if (collision.CompareTag ("Dead")) {

            gotoRespawnLocation ();
        }
        if (collision.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            gm.score += 100;

        }
    }
}