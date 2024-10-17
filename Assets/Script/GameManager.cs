using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerHP=3;              //�÷��̾� ü��
    //public int invicibleTime=0;         //�����ð�
    public GameObject player;       //  �÷��̾� ������Ʈ
    public GameObject screenChanger;

    public GameObject[] HPState;

    public float[] spawnpoint={-330f, 619f,0f};
    
    public Inventory destroyer;

    void Update()
    {
        //�÷��̾��� ü���� 0�� �Ǵ� ������ ����
        if(playerHP==0)
        {
            //����ȭ������ �̵�
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
        //���� ó��
         if(invicibleTime!=0)
        {
            Debug.Log("����");
            //player.GameObject.tag="Invicible";             //�÷��̾��� ���¸� �������� ����
            //Time.timeScale=0;

            //���� �ð�ó��
            float i=0f;
            while((int)i<invicibleTime)
            {
                //Debug.Log("°��");
                i=Time.deltaTime;          //�� �ʸ��� �� ����
                    //player.GameObject.tag="Player";        //�÷��̾� ���� ���� ��
                    //break;
                //}
            }
            invicibleTime=0;
            Debug.Log("���� ��");
        }
        */
    }
}
