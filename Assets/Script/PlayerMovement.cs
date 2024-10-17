using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //변수 선언
    float h;
    ////이동
    public Rigidbody2D plrRigidbody;              //플레이어의 리짓바디 컴포넌트를 가져옴
    public Vector2 plrSpeed=new Vector2(50f, 0f);                       //플레이어의 이동속도를 결정
    public float speedLimit=80f;                   //최대 이동속도
    ////점프
    public int jumpCount=0;
    public int maxJumpCount=1;
    public float jumpPower=10f;
    ////애니메이션 처리
    SpriteRenderer sprRnder;
    Animator anim;
    Vector3 dirVec;     //방향 좌표
    //아이템 사용 처리
    Inventory inv;

    //사운드 처리
    public AudioSource jumpsnd, groundsnd;

    void Awake()
    {
        sprRnder=GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
        inv=GameObject.Find("GameManager").GetComponent<Inventory>();
        jumpsnd=jumpsnd.GetComponent<AudioSource>();
        groundsnd=groundsnd.GetComponent<AudioSource>();
    }

    void Update()
    {
        ////이동 구현
        //버튼에서 손을 떼면 이동 정지
        if(Input.GetButtonUp("Horizontal"))     //수평방향 방향키에서 손을 땠을 때 참
        {
            plrRigidbody.velocity=new Vector2(plrRigidbody.velocity.normalized.x*0.2f, plrRigidbody.velocity.y);
        }

        ////점프 구현
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount<maxJumpCount)       //스페이스바 눌림이 확인됐고, 점프 가능한 횟수일 때,
        {
            jumpsnd.Play();
            plrRigidbody.velocity=Vector2.up*jumpPower;
            jumpCount++;
        }

        ////방향전환
        //플립
        if(Input.GetButton("Horizontal"))       //수평방향 버튼 입력이 이루어지면
            sprRnder.flipX=Input.GetAxisRaw("Horizontal")==-1;       //오른쪽 보면 1, 아니면 0 반환 및 반환값을 이용한 플립여부 처리
        //바라보는 방향
        h=Input.GetAxisRaw("Horizontal");     //수평방향 방향키 입력을 받아냄. 우측이 1, 좌측이 -1, 중립이 0
        if(h==-1)
            dirVec=Vector3.left;
        else if(h==1)
            dirVec=Vector3.right;

        ////애니메이션 처리
        //걷기
        //if(Mathf.Abs(plrRigidbody.velocity.x)<0.2f)
        if(Input.GetButton("Horizontal"))
        {
            //Debug.Log("참");
            anim.SetBool("isWalk", true);
        }
        else
        {
            //Debug.Log("거짓");
            anim.SetBool("isWalk", false);
        }
        //점프
        if(jumpCount==0)
        {
            anim.SetBool("isJump", false);
        }
        else
        {
            //점프 시작
            //상승중
            //상승종료
            //하강중
            anim.SetBool("isJump", true);
        }

        //아이템 사용 처리
        if(Input.GetKeyDown(KeyCode.Z))
        {
            inv.UseItem(0);
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            inv.UseItem(1);
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            inv.UseItem(2);
        }
    }

    GameObject scanObject;

    void FixedUpdate()
    {
        ////이동구현
        //좌우 이동
        h=Input.GetAxisRaw("Horizontal");     //수평방향 방향키 입력을 받아냄. 우측이 1, 좌측이 -1, 중립이 0
        plrRigidbody.AddForce(plrSpeed*h, ForceMode2D.Impulse);        //기존 속도에서 h로 속도만 조정

        //최대 스피드를 넘지 못하게 함
        if(plrRigidbody.velocity.x>speedLimit)
            plrRigidbody.velocity=new Vector2(speedLimit, plrRigidbody.velocity.y);
        else if(plrRigidbody.velocity.x<-speedLimit)
            plrRigidbody.velocity=new Vector2(-speedLimit, plrRigidbody.velocity.y);

        ////점프 구현
        
        /*
        //레이저를 이용해 벽과 땅 구분
        //몸체의 y값이 0이하일 때,
        if(plrRigidbody.velocity.y<0)
        {
            //레이저 생성. 각각 전방과 하단에 생성
            Debug.DrawRay(plrRigidbody.position, Vector3.down, new Color(1,0,0));
            RaycastHit2D downRay=Physics2D.Raycast(plrRigidbody.position, Vector3.down, 1, LayerMask.GetMask("Ground"));

            //레이저의 물체인식이 거짓이 아니고, 레이저의 길이가 0.5 이하가 됐을 때
            if(downRay.collider != null && downRay.distance<0.5f)
            {
                Debug.Log("땅");
                jumpCount=0;
            }
        }

        //조사를 위한 Ray
        Debug.DrawRay(plrRigidbody.position, dirVec*1.5f, new Color(1,0,0));
        RaycastHit2D rayHit2=Physics2D.Raycast(plrRigidbody.position, dirVec, 1.5f, LayerMask.GetMask("Object"));

        if(rayHit2.collider!=null)
        {
            scanObject=rayHit2.collider.gameObject;
        }
        else
        {
            scanObject=null;
        }
        */
    }

    //점프 카운트 처리
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.CompareTo("Floor")==0 || collision.gameObject.tag.CompareTo("Monster")==0 || collision.gameObject.tag.CompareTo("Item")==0)          //플레이어의 피격판정이 "바닥" 태그의 물체와 부딫히면
        {
            groundsnd.Play();
            //점프카운트 초기화
            jumpCount--;
            if(jumpCount<0)
                jumpCount=0;
            plrSpeed=new Vector2(50f, 0f);
        }
        if(collision.gameObject.tag.CompareTo("Wall")==0)
        {
            plrSpeed=new Vector2(10f,0f);
        }
    }
/*
    void OnCollisionStay2D(Collision2D collision)
    {
        if()
        {
            
        }
    }
    */
}
