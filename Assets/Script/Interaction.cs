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

    //피격판정 닿을 시 동작
    void OnCollisionEnter2D(Collision2D col)
    {
        switch(menu)
        {
            case 1:
            //열쇠 - 문 처리
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
            //검 - 몬스터 처리
                if(col.gameObject.tag.CompareTo("Monster")==0)
                {
                    Destroy(col.gameObject);
                }
            //검 - 보스 처리
                else if(col.gameObject.tag.CompareTo("Boss")==0)
                {
                    if(col.gameObject.GetComponent<BossMove>().bossHP>0)
                    {
                        col.gameObject.GetComponent<BossMove>().bossHP--;
                    }
                    /*
                    else
                    {
                        //보스 오브젝트 파괴
                        Vector3 endPos=col.gameObject.transform.position;
                        Destroy(col.gameObject);
                        //게임 클리어 이벤트 발생
                    }
                    */
                }
                break;
            case 3:
            //민트포션 - 플레이어 처리
                if(col.gameObject.tag.CompareTo("Player")==0)
                {
                    col.gameObject.GetComponent<Rigidbody2D>().velocity=Vector2.up*500f;
                    gameObject.GetComponent<BoxCollider2D>().enabled=false;
                }
                break;
            case 4:
            //총알 발사 처리
                gameObject.GetComponent<BoxCollider2D>().enabled=false;
                Debug.Log("확인용1");
                Invoke("ForCase4", data);
                Debug.Log("확인용2");
                break;
            case 5:
            //레드포션 - 플레이어 처리
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
            //플레이어 닿을 시
                if(col.gameObject.tag.CompareTo("Player")==0)
                {
                    
                }
                break;
        }
    }

    //추가 메소드 영역
    void ForCase4()
    {
        //총알 호출
        GameObject bulletOrigin=GameObject.Find("Bullet");
        GameObject bullet=Instantiate(bulletOrigin, gameObject.transform.position, gameObject.transform.rotation);
        bullet.GetComponent<MoveConstant>().dir=gameObject.GetComponent<SpriteRenderer>().flipX==true;
        Destroy(bullet, 2f);
    }
}

