using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    //변수 선언
    public float power=500f;    //부여할 힘의 크기
    public float direction=1;   //1=동, 2=서, 3=남, 4=북
    public AudioSource push;

    //오브제가 닿으면 작동
    void OnCollisionEnter2D(Collision2D other)
    {
        push.Play();
        switch(direction)
        {
            //동쪽으로 보냄
            case 1:
                other.gameObject.GetComponent<Rigidbody2D>().velocity=transform.right*power+transform.up*power;
                break;
            //서쪽으로 보냄
            case 2:
                other.gameObject.GetComponent<Rigidbody2D>().velocity=transform.right*power*(-1)+transform.up*power;
                break;
            //남쪽으로 보냄
            case 3:
                other.gameObject.GetComponent<Rigidbody2D>().velocity=transform.up*power*(-1);
                break;  
            //북쪽으로 보냄
            case 4:
                other.gameObject.GetComponent<Rigidbody2D>().velocity=transform.up*power;
                break;
            //그외?
            default:
                break;
        }
    }
}
