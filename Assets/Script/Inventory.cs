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
    float dir;      //방향전환용 값

    //인터페이스 처리
    public GameObject plrItemSlot;
    public GameObject plrUsageSlot;
    GameObject targetImg;

    //아이템 획득 처리 메소드
    public void GetItem(string data, int limit, float delT)
    {
        for(int i=0;i<3;i++)
        {
            if(inventory[i]=="empty")
            {
                //데이터 설정
                inventory[i]=data;
                usage[i]=limit;
                deleteTime[i]=delT;
                //인터페이스
                string target=data+"Img";
                plrUsageSlot.transform.GetChild(i).gameObject.GetComponent<Text>().text=limit.ToString();

                targetImg=GameObject.Find(data+"Img");
                plrItemSlot.transform.GetChild(i).GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite=targetImg.GetComponent<SpriteRenderer>().sprite;
                break;
            }
        }
    }

    //아이템 사용처리 메소드
    public void UseItem(int data)
    {
        if(useNow==false)
        {
            useNow=true;
            //관련 오브젝트 가져옴
            if(inventory[data]!="empty")
            {
                GameObject callObj=GameObject.Find(inventory[data]);        //재생할 애니메이션 탐색
                //출력 위치 조정
                Transform ezpos=playerData.transform;
                //출력 방향 설정
                if(playerData.GetComponent<SpriteRenderer>().flipX==false)
                    dir=1;
                else
                    dir=-1;
                //출력 위치 설정
                Vector3 destination=new Vector3(ezpos.position.x+(60f*dir), ezpos.position.y, ezpos.position.z);
                //클론 생성 및 출력
                GameObject clone=Instantiate(callObj,destination,ezpos.rotation);
                clone.gameObject.GetComponent<SpriteRenderer>().flipX=dir==-1;
                //클론의 추적 스크립트 추가
                clone.gameObject.AddComponent<AnimSetting>();
                clone.gameObject.GetComponent<AnimSetting>().player=playerData;
                //일정 시간 뒤 제거
                Destroy(clone, deleteTime[data]);
            }

            //사용 횟수 처리
            usage[data]--;
            plrUsageSlot.transform.GetChild(data).gameObject.GetComponent<Text>().text=usage[data].ToString();
            if(usage[data]<=0 && inventory[data]!="empty")
            {
                usage[data]=0;
                inventory[data]="empty";
                //인터페이스
                plrItemSlot.transform.GetChild(data).GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite=null;
            }
            if(usage[data]<=0)
            {
                usage[data]=0;
            }
            useNow=false;
        }
    }

    //아이템 제거 처리 메소드
    public void DeleteItem(int data)
    {
        usage[data]=0;
        inventory[data]="empty";
        //인터페이스
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
