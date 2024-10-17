using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //���� ����
    float h;
    ////�̵�
    public Rigidbody2D plrRigidbody;              //�÷��̾��� �����ٵ� ������Ʈ�� ������
    public Vector2 plrSpeed=new Vector2(50f, 0f);                       //�÷��̾��� �̵��ӵ��� ����
    public float speedLimit=80f;                   //�ִ� �̵��ӵ�
    ////����
    public int jumpCount=0;
    public int maxJumpCount=1;
    public float jumpPower=10f;
    ////�ִϸ��̼� ó��
    SpriteRenderer sprRnder;
    Animator anim;
    Vector3 dirVec;     //���� ��ǥ
    //������ ��� ó��
    Inventory inv;

    //���� ó��
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
        ////�̵� ����
        //��ư���� ���� ���� �̵� ����
        if(Input.GetButtonUp("Horizontal"))     //������� ����Ű���� ���� ���� �� ��
        {
            plrRigidbody.velocity=new Vector2(plrRigidbody.velocity.normalized.x*0.2f, plrRigidbody.velocity.y);
        }

        ////���� ����
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount<maxJumpCount)       //�����̽��� ������ Ȯ�εư�, ���� ������ Ƚ���� ��,
        {
            jumpsnd.Play();
            plrRigidbody.velocity=Vector2.up*jumpPower;
            jumpCount++;
        }

        ////������ȯ
        //�ø�
        if(Input.GetButton("Horizontal"))       //������� ��ư �Է��� �̷������
            sprRnder.flipX=Input.GetAxisRaw("Horizontal")==-1;       //������ ���� 1, �ƴϸ� 0 ��ȯ �� ��ȯ���� �̿��� �ø����� ó��
        //�ٶ󺸴� ����
        h=Input.GetAxisRaw("Horizontal");     //������� ����Ű �Է��� �޾Ƴ�. ������ 1, ������ -1, �߸��� 0
        if(h==-1)
            dirVec=Vector3.left;
        else if(h==1)
            dirVec=Vector3.right;

        ////�ִϸ��̼� ó��
        //�ȱ�
        //if(Mathf.Abs(plrRigidbody.velocity.x)<0.2f)
        if(Input.GetButton("Horizontal"))
        {
            //Debug.Log("��");
            anim.SetBool("isWalk", true);
        }
        else
        {
            //Debug.Log("����");
            anim.SetBool("isWalk", false);
        }
        //����
        if(jumpCount==0)
        {
            anim.SetBool("isJump", false);
        }
        else
        {
            //���� ����
            //�����
            //�������
            //�ϰ���
            anim.SetBool("isJump", true);
        }

        //������ ��� ó��
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
        ////�̵�����
        //�¿� �̵�
        h=Input.GetAxisRaw("Horizontal");     //������� ����Ű �Է��� �޾Ƴ�. ������ 1, ������ -1, �߸��� 0
        plrRigidbody.AddForce(plrSpeed*h, ForceMode2D.Impulse);        //���� �ӵ����� h�� �ӵ��� ����

        //�ִ� ���ǵ带 ���� ���ϰ� ��
        if(plrRigidbody.velocity.x>speedLimit)
            plrRigidbody.velocity=new Vector2(speedLimit, plrRigidbody.velocity.y);
        else if(plrRigidbody.velocity.x<-speedLimit)
            plrRigidbody.velocity=new Vector2(-speedLimit, plrRigidbody.velocity.y);

        ////���� ����
        
        /*
        //�������� �̿��� ���� �� ����
        //��ü�� y���� 0������ ��,
        if(plrRigidbody.velocity.y<0)
        {
            //������ ����. ���� ����� �ϴܿ� ����
            Debug.DrawRay(plrRigidbody.position, Vector3.down, new Color(1,0,0));
            RaycastHit2D downRay=Physics2D.Raycast(plrRigidbody.position, Vector3.down, 1, LayerMask.GetMask("Ground"));

            //�������� ��ü�ν��� ������ �ƴϰ�, �������� ���̰� 0.5 ���ϰ� ���� ��
            if(downRay.collider != null && downRay.distance<0.5f)
            {
                Debug.Log("��");
                jumpCount=0;
            }
        }

        //���縦 ���� Ray
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

    //���� ī��Ʈ ó��
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.CompareTo("Floor")==0 || collision.gameObject.tag.CompareTo("Monster")==0 || collision.gameObject.tag.CompareTo("Item")==0)          //�÷��̾��� �ǰ������� "�ٴ�" �±��� ��ü�� �΋H����
        {
            groundsnd.Play();
            //����ī��Ʈ �ʱ�ȭ
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
