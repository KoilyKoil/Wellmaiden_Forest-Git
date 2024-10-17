using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSetting : MonoBehaviour
{
    //방향 전환용
    SpriteRenderer sprRnder;
    Vector3 dirVec;     //방향 좌표
    //플레이어 추적용
    float h;
    public GameObject player;
    Vector3 plrpos;

    void Awake()
    {
        sprRnder=GetComponent<SpriteRenderer>(); //스프라이트 랜더를 가져옴
    }

    void Update()
    {
        plrpos=player.transform.position;
        //오브젝트 방향전환
        //플립
        if(Input.GetButton("Horizontal"))       //수평방향 버튼 입력이 이루어지면
            sprRnder.flipX=Input.GetAxisRaw("Horizontal")==-1;       //오른쪽 보면 1, 아니면 0 반환 및 반환값을 이용한 플립여부 처리
        //바라보는 방향
        h=Input.GetAxisRaw("Horizontal");     //수평방향 방향키 입력을 받아냄. 우측이 1, 좌측이 -1, 중립이 0
        if(h==-1)
        {
            dirVec=Vector3.left;
            //오브젝트 실시간 이동
            gameObject.transform.position=new Vector3(plrpos.x-60f, plrpos.y, plrpos.z);
        }
        else if(h==1)
        {
            dirVec=Vector3.right;
            //오브젝트 실시간 이동
            gameObject.transform.position=new Vector3(plrpos.x+60f, plrpos.y, plrpos.z);
        }
    }
}
