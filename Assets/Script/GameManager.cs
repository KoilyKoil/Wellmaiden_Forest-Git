using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerHP=3;              //플레이어 체력
    //public int invicibleTime=0;         //무적시간
    public GameObject player;       //  플레이어 오브젝트
    public GameObject screenChanger;

    public GameObject[] HPState;

    public float[] spawnpoint={-330f, 619f,0f};
    
    public Inventory destroyer;

    void Update()
    {
        //플레이어의 체력이 0이 되는 순간이 오면
        if(playerHP==0)
        {
            //메인화면으로 이동
            playerHP=3;
            player.transform.localPosition=new Vector3(spawnpoint[0], spawnpoint[1], spawnpoint[2]);
            Destroy(GameObject.Find("Boss(Clone)"));
            destroyer.GetComponent<Inventory>().SetDie();
            
            screenChanger.GetComponent<IntroScreen>().GameOver();
            for(int i=0;i<3;i++)
            {
                HPState[i].SetActive(true);
            }
        }

/*
        //무적 처리
         if(invicibleTime!=0)
        {
            Debug.Log("무적");
            //player.GameObject.tag="Invicible";             //플레이어의 상태를 무적으로 설정
            //Time.timeScale=0;

            //무적 시간처리
            float i=0f;
            while((int)i<invicibleTime)
            {
                //Debug.Log("째깍");
                i=Time.deltaTime;          //매 초마다 값 증가
                    //player.GameObject.tag="Player";        //플레이어 무적 해제 후
                    //break;
                //}
            }
            invicibleTime=0;
            Debug.Log("무적 끗");
        }
        */
    }
}
