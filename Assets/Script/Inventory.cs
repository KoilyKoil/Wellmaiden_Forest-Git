using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public string[] inventory=new string[]{"empty","empty","empty"};
    public int[] usage=new int[]{0,0,0};
    public float[] deleteTime=new float[]{0f,0f,0f};
    bool useNow=false;
    public GameObject playerData;
    float dir;      //������ȯ�� ��

    //�������̽� ó��
    public GameObject plrItemSlot;
    public GameObject plrUsageSlot;
    GameObject targetImg;

    //������ ȹ�� ó�� �޼ҵ�
    public void GetItem(string data, int limit, float delT)
    {
        for(int i=0;i<3;i++)
        {
            if(inventory[i]=="empty")
            {
                //������ ����
                inventory[i]=data;
                usage[i]=limit;
                deleteTime[i]=delT;
                //�������̽�
                string target=data+"Img";
                plrUsageSlot.transform.GetChild(i).gameObject.GetComponent<Text>().text=limit.ToString();

                targetImg=GameObject.Find(data+"Img");
                plrItemSlot.transform.GetChild(i).GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite=targetImg.GetComponent<SpriteRenderer>().sprite;
                break;
            }
        }
    }

    //������ ���ó�� �޼ҵ�
    public void UseItem(int data)
    {
        if(useNow==false)
        {
            useNow=true;
            //���� ������Ʈ ������
            if(inventory[data]!="empty")
            {
                GameObject callObj=GameObject.Find(inventory[data]);        //����� �ִϸ��̼� Ž��
                //��� ��ġ ����
                Transform ezpos=playerData.transform;
                //��� ���� ����
                if(playerData.GetComponent<SpriteRenderer>().flipX==false)
                    dir=1;
                else
                    dir=-1;
                //��� ��ġ ����
                Vector3 destination=new Vector3(ezpos.position.x+(60f*dir), ezpos.position.y, ezpos.position.z);
                //Ŭ�� ���� �� ���
                GameObject clone=Instantiate(callObj,destination,ezpos.rotation);
                clone.gameObject.GetComponent<SpriteRenderer>().flipX=dir==-1;
                //Ŭ���� ���� ��ũ��Ʈ �߰�
                clone.gameObject.AddComponent<AnimSetting>();
                clone.gameObject.GetComponent<AnimSetting>().player=playerData;
                //���� �ð� �� ����
                Destroy(clone, deleteTime[data]);
            }

            //��� Ƚ�� ó��
            usage[data]--;
            plrUsageSlot.transform.GetChild(data).gameObject.GetComponent<Text>().text=usage[data].ToString();
            if(usage[data]<=0 && inventory[data]!="empty")
            {
                usage[data]=0;
                inventory[data]="empty";
                //�������̽�
                plrItemSlot.transform.GetChild(data).GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite=null;
            }
            if(usage[data]<=0)
            {
                usage[data]=0;
            }
            useNow=false;
        }
    }

    //������ ���� ó�� �޼ҵ�
    public void DeleteItem(int data)
    {
        usage[data]=0;
        inventory[data]="empty";
        //�������̽�
        plrItemSlot.transform.GetChild(data).GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite=null;
        plrUsageSlot.transform.GetChild(data).gameObject.GetComponent<Text>().text=usage[data].ToString();
    }

    public void SetDie()
    {
        inventory[0]="empty";
        inventory[1]="empty";
        inventory[2]="empty";
        usage[0]=0;
        usage[1]=0;
        usage[2]=0;
        deleteTime[0]=0;
        deleteTime[1]=0;
        deleteTime[2]=0;

        plrUsageSlot.transform.GetChild(0).gameObject.GetComponent<Text>().text="0";
        plrUsageSlot.transform.GetChild(1).gameObject.GetComponent<Text>().text="0";
        plrUsageSlot.transform.GetChild(2).gameObject.GetComponent<Text>().text="0";

        plrItemSlot.transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite=null;
        plrItemSlot.transform.GetChild(1).GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite=null;
        plrItemSlot.transform.GetChild(2).GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite=null;
    }
}
