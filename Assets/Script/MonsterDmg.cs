using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDmg : MonoBehaviour
{
    GameManager gm;         //체력 처리용 인스턴스
    GameObject plr;          //타격 대상 처리용 인스턴스
    public GameObject plrLifeImg;

    //사운드 처리
    AudioSource dmgsnd;

    void Awake()
    {
        gm=GameObject.Find("GameManager").GetComponent<GameManager>();
        dmgsnd=GameObject.Find("HitSound").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {   
        if(col.gameObject.tag.CompareTo("Player")==0)
        {
            dmgsnd.Play();
            plr=col.gameObject;         //플레이어 오브젝트로 초기화
            //플레이어가 닿았을때 처리
            gm.playerHP--;              //플레이어 체력 감소
            plrLifeImg.transform.GetChild(gm.playerHP).gameObject.SetActive(false);
            plr.GetComponent<Invicible>().SetInvicible(plr);
        }
    }
}
