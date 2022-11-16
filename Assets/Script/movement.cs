using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public float playerHP;
    public float ColorC;

    public bool isMoving;
    public bool facingRight;
    public bool Jumping;
    public bool CanJump;

    public float Speed;
    public float JumpForce;

    public GameObject Win;
    public GameObject Lose;
    public GameObject Creater;
    public GameObject WinAudio;

    public UnityEngine.Rendering.Universal.Light2D BackGround;

    private Rigidbody2D RG;
    // Start is called before the first frame update

    private void Start()
    {
        playerHP = 10;
        RG = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(x, y);

        Walk(dir);


        if (CanJump == true &&Input.GetKeyDown(KeyCode.Space))
        {
            Jumping = true;
            CanJump = false;
        }

        //if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(RG.velocity.y) < 0.5f && Mathf.Abs(RG.velocity.y) > -0.5f)
        //{
        //    Jumping = true;
        //}
        ////isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 0.15f, groundLayer); // checks if you are within 0.15 position in the Y of the ground
        ////Flip();
    }

    void Walk(Vector2 dir)
    {
        RG.velocity = new Vector2(dir.x * Speed, RG.velocity.y);

        isMoving = Mathf.Abs(RG.velocity.x) > Mathf.Epsilon;
    }

    private void FixedUpdate()
    {

        var movement = Input.GetAxis("Horizontal");
        if (gameObject.transform.rotation.y == 0) facingRight = false;
        else facingRight = true;

        //transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * Speed;

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;


        if (Jumping)
        {
            RG.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            Jumping = false;
        }


        ColorC = this.gameObject.transform.position.y;
        BackGround.color = new Color(0.5f - ColorC, 0.5f + ColorC, 0.5f - ColorC, 1f);

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "killPlayer")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (other.tag == "block")
        {
            CanJump = true;
        }

        if (other.tag == "win")
        {
            Win.SetActive(true);
            WinAudio.SetActive(true);
            //Lose.SetActive(false);
            Creater.SetActive(false);
        }
    }

}
