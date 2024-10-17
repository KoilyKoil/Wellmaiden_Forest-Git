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
            myChild=GameObject.Find(whatSpawn);     //��� Ž��
            timer=0;            //�ð� �ʱ�ȭ
            needSpawn=false;       //������ �ʿ俩�� ��Ȱ��ȭ   
            GameObject clone=Instantiate(myChild, gameObject.transform.position, gameObject.transform.rotation);    //������
            clone.transform.parent=gameObject.transform;        //���� ��ũ�� ������ ��� ������
            
            Vector3 setDepth=clone.transform.position;      //������ ��ġ�� ������
            setDepth.z=500f;            //�̹��� ���� ����
            clone.transform.position=setDepth;      //�̹��� ���� ����
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
