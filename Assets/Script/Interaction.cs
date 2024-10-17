using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    Inventory inv;
    public int menu;
    public float data=0f;

    void Awake()
    {
        inv=GameObject.Find("GameManager").GetComponent<Inventory>();
    }

    //�ǰ����� ���� �� ����
    void OnCollisionEnter2D(Collision2D col)
    {
        switch(menu)
        {
            case 1:
            //���� - �� ó��
                if(col.gameObject.tag.CompareTo("Door")==0)
                {
                    Destroy(col.gameObject);
                    for(int i=0;i<3;i++)
                    {
                        if(inv.inventory[i]=="Key")
                        {
                            inv.DeleteItem(i);
                            break;
                        } 
                    }
                }
                break;
            case 2:
            //�� - ���� ó��
                if(col.gameObject.tag.CompareTo("Monster")==0)
                {
                    Destroy(col.gameObject);
                }
            //�� - ���� ó��
                else if(col.gameObject.tag.CompareTo("Boss")==0)
                {
                    if(col.gameObject.GetComponent<BossMove>().bossHP>0)
                    {
                        col.gameObject.GetComponent<BossMove>().bossHP--;
                    }
                    /*
                    else
                    {
                        //���� ������Ʈ �ı�
                        Vector3 endPos=col.gameObject.transform.position;
                        Destroy(col.gameObject);
                        //���� Ŭ���� �̺�Ʈ �߻�
                    }
                    */
                }
                break;
            case 3:
            //��Ʈ���� - �÷��̾� ó��
                if(col.gameObject.tag.CompareTo("Player")==0)
                {
                    col.gameObject.GetComponent<Rigidbody2D>().velocity=Vector2.up*500f;
                    gameObject.GetComponent<BoxCollider2D>().enabled=false;
                }
                break;
            case 4:
            //�Ѿ� �߻� ó��
                gameObject.GetComponent<BoxCollider2D>().enabled=false;
                Debug.Log("Ȯ�ο�1");
                Invoke("ForCase4", data);
                Debug.Log("Ȯ�ο�2");
                break;
            case 5:
            //�������� - �÷��̾� ó��
                if(col.gameObject.tag.CompareTo("Player")==0)
                {
                    if(col.gameObject.GetComponent<SpriteRenderer>().flipX==true)
                    {
                        col.gameObject.GetComponent<Rigidbody2D>().velocity=Vector2.right*(-1000f)+Vector2.up*100f;
                    }
                    else
                    {
                        col.gameObject.GetComponent<Rigidbody2D>().velocity=Vector2.right*1000f+Vector2.up*100f;
                    }
                    gameObject.GetComponent<BoxCollider2D>().enabled=false;
                }
                break;
            default:
            //�÷��̾� ���� ��
                if(col.gameObject.tag.CompareTo("Player")==0)
                {
                    
                }
                break;
        }
    }

    //�߰� �޼ҵ� ����
    void ForCase4()
    {
        //�Ѿ� ȣ��
        GameObject bulletOrigin=GameObject.Find("Bullet");
        GameObject bullet=Instantiate(bulletOrigin, gameObject.transform.position, gameObject.transform.rotation);
        bullet.GetComponent<MoveConstant>().dir=gameObject.GetComponent<SpriteRenderer>().flipX==true;
        Destroy(bullet, 2f);
    }
}

