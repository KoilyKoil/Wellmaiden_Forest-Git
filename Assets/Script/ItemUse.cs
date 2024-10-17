using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    Inventory inventory;        //�κ��丮 ��ũ��Ʈ�� ������
    public string namer="empty";
    public int limit=0;
    public float delTime=1f;

    //���� ó��
    AudioSource getitemsnd;

    void Awake()
    {
        inventory=GameObject.Find("GameManager").GetComponent<Inventory>();
        getitemsnd=GameObject.Find("GetItemSound").GetComponent<AudioSource>();
    }

    //��ü �΋H���� �������� ��
    void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.tag.CompareTo("Player")==0 || col.gameObject.tag.CompareTo("Invicible")==0)
        {
            if(inventory.usage[0]==0 || inventory.usage[1]==0 || inventory.usage[2]==0)
            {
                getitemsnd.Play();
                inventory.GetItem(namer, limit, delTime);
                Destroy(gameObject);
            }
        }
    }
}
