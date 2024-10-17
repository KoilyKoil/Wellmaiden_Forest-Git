using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    //���� ����
    public float power=500f;    //�ο��� ���� ũ��
    public float direction=1;   //1=��, 2=��, 3=��, 4=��
    public AudioSource push;

    //�������� ������ �۵�
    void OnCollisionEnter2D(Collision2D other)
    {
        push.Play();
        switch(direction)
        {
            //�������� ����
            case 1:
                other.gameObject.GetComponent<Rigidbody2D>().velocity=transform.right*power+transform.up*power;
                break;
            //�������� ����
            case 2:
                other.gameObject.GetComponent<Rigidbody2D>().velocity=transform.right*power*(-1)+transform.up*power;
                break;
            //�������� ����
            case 3:
                other.gameObject.GetComponent<Rigidbody2D>().velocity=transform.up*power*(-1);
                break;  
            //�������� ����
            case 4:
                other.gameObject.GetComponent<Rigidbody2D>().velocity=transform.up*power;
                break;
            //�׿�?
            default:
                break;
        }
    }
}
