using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    public float moveSpeed=1f;//h�z�n �iddetini belirleyebilmek i�in
    //1.kuveetin �iddetini belirleyebilmek i�in,2.bir saniyede 1 defa z�plas�n (s�kl�k),3.bir sonraki z�play�� ne zaman onun bilgisi;

    bool facingRight = true;

    //yere de�iyor mu tespiti i�in gerekenler (daire ile kontrol) //public olan de�i�kenler unityden kontrol edilebilir oluyor
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
    void Update()//her frame de yap dediklerini,FPSe ba�l� method
    {
        HorizontalMove();
        onGroundCheck();

        if (playerRB.velocity.x<0 && facingRight)//y�z� sa�a do�ru ba�lang��taki gibi ama ivme negatif ,y�z�n� �evir
        {
            FlipFace();//Yuzunu cevir metodu
        }
        else if(playerRB.velocity.x>0 && !facingRight)
        {
            FlipFace(); //Yuzunu cevir metodu
        }
        

    }
    void FixedUpdate()//her saniyede 50 kez yap dediklerini, zamana ba�l� metod
    {
        
    }
    void HorizontalMove()
    {
        // print(Input.GetAxis("Horizontal")); consol ekran�na yazd�r�yor g�rmek i�indi gerek yok
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetBool("isRunning", Input.GetAxis("Horizontal") != 0);//animasyonu �al��t�r

    }
        void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale =transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;

    }
   

    void onGroundCheck()
    {
       isGrounded= Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);//olu�turuulan daire yere de�iyor mu, de�iyorsa boolu de�i�tiriyor.
       playerAnimator.SetBool("isGroundedAnim",isGrounded); 
    }
}

