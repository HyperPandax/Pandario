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

    private IEnumerator coroutine;

    void Start () {

        Rigidbody2D = GetComponent<Rigidbody2D> ();
        gravityStore = Rigidbody2D.gravityScale;
        groundCheck = transform.Find ("GroundCheck");
        //print("GroundCheck" + groundCheck);
        gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();

        StartCoroutine(jumpAndWait(2.0f));
    }

    public void FixedUpdate () {
        grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll (groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject != gameObject)
                grounded = true;
        }

        float move = Input.GetAxis("Horizontal");
        bool run = Input.GetKey(KeyCode.LeftShift);

        if (move > 0 && !facingRight)
            Flip ();
        else if (move < 0 && facingRight)
            Flip ();

        if (run)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed*2, GetComponent<Rigidbody2D>().velocity.y);
        }
        else { GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y); }
    }
  
    private IEnumerator jumpAndWait(float waitTime)
    {
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
        print("space is down");
        if (grounded & GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            print("grounded" + grounded);

            Jump();
            yield return new WaitForSeconds(waitTime);
        }
        StartCoroutine(jumpAndWait(0.5f));
    }

    void Flip () {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void gotoRespawnLocation (Vector3 respawn) {
        
         transform.position = respawn;
       
        //find way for good respawn
    }

    public void Jump () {  
        GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
    }

    public void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag ("Dead")) {
            print(collision.transform.position);

            Vector3 meep = collision.transform.position + new Vector3(-80, 220);
            gotoRespawnLocation (meep);
        }
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            gm.score += 100;

        }
        if (collision.CompareTag("Enemy"))
        {
            gm.health--;
            // bounch player back so only 1 point gets removed
            Vector2 knockbackVelocity = new Vector2((transform.position.x - GetComponent<Rigidbody2D>().transform.position.x) * 2, (transform.position.y - GetComponent<Rigidbody2D>().transform.position.y) * 2);
            GetComponent<Rigidbody2D>().velocity = -knockbackVelocity;
        }
    }
}