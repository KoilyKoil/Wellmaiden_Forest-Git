using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootholdMovement : MonoBehaviour
{
    //����
    public float limitation;        //�̵�Ƚ�� ����
    public float moveSpeed;     //�̵� �ӵ� ����
    float speedNow;         //���� �̵� �ӵ� �� ����
    float counter=0;            //�̵� Ƚ��
    bool updown=true;       //���ϼ���. ��=��, ����=��

    //ó��
    void Update()
    {
        //�̵�
        gameObject.transform.position=new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+speedNow, gameObject.transform.position.z);

        //�̵� Ƚ�� ó��
        counter+=moveSpeed;

        //��ǥġ ���� �� ���� ����
        if(counter>=limitation)
            numberUpdate();
    }

    //��ǥ�� ���� �� �� ������Ʈ
    void numberUpdate()
    {
        //Ƚ�� ó�� �� �ʱ�ȭ
        counter=0;
        //������ ���� ���� Ȯ��
        if(updown==true)
        {
            //��� ������ ���޽� �̵����� �Ʒ��� ����
            updown=false;
            //���� �̵��ϸ� ��������� ó��
            speedNow=moveSpeed*1;
        }
        else
        {
            //�Ϻ� ������ ���޽� �̵����� ���� ����
            updown=true;
            //�Ʒ��� �̵��ϸ� ���������� ����
            speedNow=moveSpeed*(-1);
        }
    }

    //�÷��̾ ������ ��� �ְ� ������ �ϰ��� �� ó��
     void OnCollisionStay2D(Collision2D col)
     {
        if(col.gameObject.tag=="Player")
        {
            //col.gameObject.GetComponent<Rigidbody2D>().gravityScale=1;
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up*moveSpeed*10);
        }
     }
/*
     void OnCollisionExit2D(Collision2D col)
     {
        if(col.gameObject.tag=="Player")
        {
            col.gameObject.GetComponent<Rigidbody2D>().gravityScale=80;
        }
     }
     */
}
