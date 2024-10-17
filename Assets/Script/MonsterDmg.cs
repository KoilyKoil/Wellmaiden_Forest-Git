using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDmg : MonoBehaviour
{
    GameManager gm;         //ü�� ó���� �ν��Ͻ�
    GameObject plr;          //Ÿ�� ��� ó���� �ν��Ͻ�
    public GameObject plrLifeImg;

    //���� ó��
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
            plr=col.gameObject;         //�÷��̾� ������Ʈ�� �ʱ�ȭ
            //�÷��̾ ������� ó��
            gm.playerHP--;              //�÷��̾� ü�� ����
            plrLifeImg.transform.GetChild(gm.playerHP).gameObject.SetActive(false);
            plr.GetComponent<Invicible>().SetInvicible(plr);
        }
    }
}
