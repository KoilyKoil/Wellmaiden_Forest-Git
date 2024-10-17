using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    //계획
    /*
    일정 시간마다 가시가 나옴
    일정 확률로 보스가 땅속으로 들어가고, 하늘에서 포자가 떨어짐.
    ㄴ포자가 나타났을 때 보스 재등장
    보스의 체력은 10
    일정 시간 마다 무기 아이템을 떨궈줌
    보스 체력 다하면 보스 죽는 애니메이션 재생 후 게임 클리어 로고 출력
    */
    //수치 설정
    public int bossHP=5;
    public float attackCool=10f;
    //float weaponCool=100f;
    int pattern=1;

    //대상 애니메이션, 오브젝트
    //public Animator idleAnime;
    //public Animator insiderAnime;
    //public Animator outsiderAnim;
    public GameObject spearObj;
    //public GameObject sporeObj;
    public GameObject notification;
    public GameObject weaponList;

    //실행상태 구분
    private bool loadNow=false;

    //제거시간 구분
    public float notfTime;
    public float spikeTime;
    public float termTime;
    //public float sporeTime;

    //무적 처리용
    int invicibleTime=2;

    //격퇴 애니메이션용
    float delAnimTime=1.9f;
    public GameObject anim;
    public GameObject clear;


    //주요 사용 함수
    //Invoke("메소드명", 시간)
    //Instantiate(오브제, 위치(벡터3), 각도(벡터3))
    //Animator.Play(재생할 애니메이션)

    //예상되는 문제
    //함수의 중복처리
    //일정 시간 뒤에 함수가 한번에 파바박 계속 호출되는거 아냐...?
    //bool 전역 변수를 둬서 해당 bool이 참이면 작동 중지?

    void Update()
    {
        if(loadNow==false)
        {
            Debug.Log("패턴 실행,"+pattern);
            loadNow=true;
            //일정 시간 이후에 둘중 랜덤 오브제 Invoke
            switch(pattern)
            {
                case 1:
                    Invoke("SpawnSpear",attackCool);
                    break;
                case 2:
                    Invoke("SpawnSpear2",attackCool);
                    break;
                case 3:
                    Invoke("SpawnSpear3",attackCool);
                    break;
                case 4:
                    Invoke("SpawnSpear4",attackCool);
                    break;
                case 5:
                    Invoke("SpawnWeapon", attackCool);
                    break;
                default:
                    break;
            }
            pattern++;
            if(pattern>5)
                pattern=1;
        }

        //보스의 체력이 다하면
        if(bossHP<=0)
        {
            //파괴연출
            GameObject cloneAnim=Instantiate(anim, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(cloneAnim, delAnimTime);
            Destroy(gameObject);
            //게임클리어 연출
            clear.SetActive(true);
        }
    }

    //가시 스폰
    void SpawnSpear()
    {
        //오브제 복사 위치 암시
        GameObject notif=Instantiate(notification, gameObject.transform.position, gameObject.transform.rotation);
        notif.transform.position=new Vector3(gameObject.transform.position.x-200, gameObject.transform.position.y, 0);
        //notif.GetComponent<Animator>().enabled=true;
        Destroy(notif, notfTime);
        //가시 오브젝트 복사
        Invoke("RealSpike",notfTime+termTime);
        //종료 후 메인 애니메이션 재생
        loadNow=false;
    }
    
    //가시 스폰 시간차 호출용
    void RealSpike()
    {
        GameObject atk=Instantiate(spearObj, gameObject.transform.position, gameObject.transform.rotation);
        atk.transform.position=new Vector3(gameObject.transform.position.x-200, gameObject.transform.position.y, 0);
        Destroy(atk, spikeTime);
    }

    //가시 스폰
    void SpawnSpear2()
    {
        //오브제 복사 위치 암시
        GameObject notif=Instantiate(notification, gameObject.transform.position, gameObject.transform.rotation);
        notif.transform.position=new Vector3(gameObject.transform.position.x-280, gameObject.transform.position.y, 0);
        //notif.GetComponent<Animator>().enabled=true;
        Destroy(notif, notfTime);
        //가시 오브젝트 복사
        Invoke("RealSpike2",notfTime+termTime);
        //종료 후 메인 애니메이션 재생
        loadNow=false;
    }
    
    //가시 스폰 시간차 호출용
    void RealSpike2()
    {
        GameObject atk=Instantiate(spearObj, gameObject.transform.position, gameObject.transform.rotation);
        atk.transform.position=new Vector3(gameObject.transform.position.x-280, gameObject.transform.position.y, 0);
        Destroy(atk, spikeTime);
    }

    //가시 스폰
    void SpawnSpear3()
    {
        //오브제 복사 위치 암시
        GameObject notif=Instantiate(notification, gameObject.transform.position, gameObject.transform.rotation);
        notif.transform.position=new Vector3(gameObject.transform.position.x-360, gameObject.transform.position.y, 0);
        //notif.GetComponent<Animator>().enabled=true;
        Destroy(notif, notfTime);
        //가시 오브젝트 복사
        Invoke("RealSpike3",notfTime+termTime);
        //종료 후 메인 애니메이션 재생
        loadNow=false;
    }
    
    //가시 스폰 시간차 호출용
    void RealSpike3()
    {
        GameObject atk=Instantiate(spearObj, gameObject.transform.position, gameObject.transform.rotation);
        atk.transform.position=new Vector3(gameObject.transform.position.x-360, gameObject.transform.position.y, 0);
        Destroy(atk, spikeTime);
    }

    //가시 스폰
    void SpawnSpear4()
    {
        SpawnSpear();
        SpawnSpear3();
        //종료 후 메인 애니메이션 재생
        loadNow=false;
    }
/*
    //포자 스폰
    void SpawnSpore()
    {
        //사라지는 애니메이션 재생
        //insiderAnime.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled=false;
        //재생 완료 후 포자 오브젝트 복사
        GameObject spore=Instantiate(sporeObj, gameObject.transform.position, gameObject.transform.rotation);
        spore.transform.position=new Vector3(gameObject.transform.position.x-170, gameObject.transform.position.y+100, 0);
        GameObject spore2=Instantiate(sporeObj, gameObject.transform.position, gameObject.transform.rotation);
        spore2.transform.position=new Vector3(gameObject.transform.position.x-220, gameObject.transform.position.y+120, 0);
        GameObject spore3=Instantiate(sporeObj, gameObject.transform.position, gameObject.transform.rotation);
        spore3.transform.position=new Vector3(gameObject.transform.position.x-270, gameObject.transform.position.y+140, 0);
        GameObject spore4=Instantiate(sporeObj, gameObject.transform.position, gameObject.transform.rotation);
        spore4.transform.position=new Vector3(gameObject.transform.position.x-320, gameObject.transform.position.y+160, 0);
        //나타나는 애니메이션 재생
        Destroy(spore,sporeTime);
        Destroy(spore2,sporeTime);
        Destroy(spore3,sporeTime);
        Destroy(spore4,sporeTime);
        //종료 후 메인 애니메이션 재생
        //outsiderAnim.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled=true;
        loadNow=false;
    }
*/
    //무기 스폰
    void SpawnWeapon()
    {
        int randNum=Random.Range(0,1);
        //하늘에서 무기 아이템 랜덤 스폰
        GameObject weapon=Instantiate(weaponList.transform.GetChild(randNum).gameObject, gameObject.transform.position, gameObject.transform.rotation);
        weapon.transform.position=new Vector3(gameObject.transform.position.x-170, gameObject.transform.position.y, 0);
        //대신 횟수는 1~2로 설정
        loadNow=false;
    }

    //피격 처리
    void OnCollisionEnter2D(Collision2D atk)
    {
        if(atk.gameObject.tag.CompareTo("Attack")==0)
        {
            //보스 타격시 체력 감소 처리는 Interaction에서 관할
            SetInvicible();
        }
    }

    //보스 무적 처리
    void SetInvicible()
    {
        //태그를 무적 상태로 변경
        gameObject.tag="Invicible";
        Invoke("EndInvicible",invicibleTime);
        //무적 시각처리
        gameObject.GetComponent<SpriteRenderer>().color=new Color(1,1,1,0.5f);
    }

    //무적 종료
    void EndInvicible()
    {
        gameObject.GetComponent<SpriteRenderer>().color=new Color(1,1,1,1);
        gameObject.tag="Boss";
    }
}
