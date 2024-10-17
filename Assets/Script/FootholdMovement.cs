using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootholdMovement : MonoBehaviour
{
    //선언
    public float limitation;        //이동횟수 제한
    public float moveSpeed;     //이동 속도 설정
    float speedNow;         //현재 이동 속도 및 방향
    float counter=0;            //이동 횟수
    bool updown=true;       //상하설정. 참=상, 거짓=하

    //처리
    void Update()
    {
        //이동
        gameObject.transform.position=new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+speedNow, gameObject.transform.position.z);

        //이동 횟수 처리
        counter+=moveSpeed;

        //목표치 도달 시 방향 변경
        if(counter>=limitation)
            numberUpdate();
    }

    //목표점 도달 시 값 업데이트
    void numberUpdate()
    {
        //횟수 처리 값 초기화
        counter=0;
        //목적지 도달 여부 확인
        if(updown==true)
        {
            //상부 목적지 도달시 이동방향 아래로 변경
            updown=false;
            //위로 이동하면 양수값으로 처리
            speedNow=moveSpeed*1;
        }
        else
        {
            //하부 목적지 도달시 이동방향 위로 변경
            updown=true;
            //아래로 이동하면 음수값으로 설정
            speedNow=moveSpeed*(-1);
        }
    }

    //플레이어가 발판을 밟고 있고 발판이 하강할 때 처리
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
