using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    public float moveSpeed=1f;//hýzýn þiddetini belirleyebilmek için
    public float jumpSpeed = 1f, jumpFrequency=1f, nextJumpTime;//1.kuveetin þiddetini belirleyebilmek için,2.bir saniyede 1 defa zýplasýn (sýklýk),3.bir sonraki zýplayýþ ne zaman onun bilgisi;

    bool facingRight = true;

    //yere deðiyor mu tespiti için gerekenler (daire ile kontrol) //public olan deðiþkenler unityden kontrol edilebilir oluyor
    public bool isGrounded = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRB=GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()//her frame de yap dediklerini,FPSe baðlý method
    {
        HorizontalMove();
        onGroundCheck();

        if (playerRB.velocity.x<0 && facingRight)//yüzü saða doðru baþlangýçtaki gibi ama ivme negatif ,yüzünü çevir
        {
            FlipFace();//Yuzunu cevir metodu
        }
        else if(playerRB.velocity.x>0 && !facingRight)
        {
            FlipFace(); //Yuzunu cevir metodu
        }
        if (Input.GetAxis("Vertical")>0 && isGrounded && (nextJumpTime<Time.timeSinceLevelLoad))//kullanýcý yukarý tuþa basýyorsa ve karakter yere deðiyorsa zýpla
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }

    }
    void FixedUpdate()//her saniyede 50 kez yap dediklerini, zamana baðlý metod
    {
        
    }
    void HorizontalMove()
    {
        // print(Input.GetAxis("Horizontal")); consol ekranýna yazdýrýyor görmek içindi gerek yok
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed",Mathf.Abs(playerRB.velocity.x));

    }
        void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale =transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;

    }
    void Jump()
    {
        playerRB.AddForce(new Vector2(0f,jumpSpeed));
    }

    void onGroundCheck()
    {
       isGrounded= Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);//oluþturuulan daire yere deðiyor mu, deðiyorsa boolu deðiþtiriyor.
       playerAnimator.SetBool("isGroundedAnim",isGrounded); 
    }
}

