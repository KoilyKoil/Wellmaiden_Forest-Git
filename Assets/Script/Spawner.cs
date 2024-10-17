using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    bool needSpawn=false;
    float timer=0;
    GameObject myChild;
    public string whatSpawn;

    void Update()
    {
        timer+=Time.deltaTime;
        if(needSpawn==false)
        {
            timer=0;
        }
        if(needSpawn==true && timer>5) 
        {
            myChild=GameObject.Find(whatSpawn);     //재료 탐색
            timer=0;            //시간 초기화
            needSpawn=false;       //리스폰 필요여부 비활성화   
            GameObject clone=Instantiate(myChild, gameObject.transform.position, gameObject.transform.rotation);    //리스폰
            clone.transform.parent=gameObject.transform;        //메인 스크린 아이템 출력 방지용
            
            Vector3 setDepth=clone.transform.position;      //아이템 위치값 가져옴
            setDepth.z=500f;            //이미지 깊이 조정
            clone.transform.position=setDepth;      //이미지 깊이 적용
        }
    }

    private void OnTriggerStay2D()
    {
        needSpawn=false;
    }

    private void OnTriggerExit2D()
    {
        needSpawn=true;
    }
}
