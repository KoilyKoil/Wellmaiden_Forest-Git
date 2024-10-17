using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invicible : MonoBehaviour
{
    GameObject plr;

    //���� ó����
    int invicibleTime=3;


    public void SetInvicible(GameObject what)
    {
        plr=what;
        //�±׸� ���� ���·� ����
        plr.tag="Invicible";
        //���� �ð�ó��
        plr.GetComponent<SpriteRenderer>().color=new Color(1,1,1,0.5f);
        //���� ���� ȣ��ó��
        Invoke("EndInvicible",invicibleTime);
    }

    //���� ����
    public void EndInvicible()
    {
        plr.GetComponent<SpriteRenderer>().color=new Color(1,1,1,1);
        plr.tag="Player";
        
    }
}
