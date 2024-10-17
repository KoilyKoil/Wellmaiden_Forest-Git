using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    //��ȹ
    /*
    ���� �ð����� ���ð� ����
    ���� Ȯ���� ������ �������� ����, �ϴÿ��� ���ڰ� ������.
    �����ڰ� ��Ÿ���� �� ���� �����
    ������ ü���� 10
    ���� �ð� ���� ���� �������� ������
    ���� ü�� ���ϸ� ���� �״� �ִϸ��̼� ��� �� ���� Ŭ���� �ΰ� ���
    */
    //��ġ ����
    public int bossHP=5;
    public float attackCool=10f;
    //float weaponCool=100f;
    int pattern=1;

    //��� �ִϸ��̼�, ������Ʈ
    //public Animator idleAnime;
    //public Animator insiderAnime;
    //public Animator outsiderAnim;
    public GameObject spearObj;
    //public GameObject sporeObj;
    public GameObject notification;
    public GameObject weaponList;

    //������� ����
    private bool loadNow=false;

    //���Žð� ����
    public float notfTime;
    public float spikeTime;
    public float termTime;
    //public float sporeTime;

    //���� ó����
    int invicibleTime=2;

    //���� �ִϸ��̼ǿ�
    float delAnimTime=1.9f;
    public GameObject anim;
    public GameObject clear;


    //�ֿ� ��� �Լ�
    //Invoke("�޼ҵ��", �ð�)
    //Instantiate(������, ��ġ(����3), ����(����3))
    //Animator.Play(����� �ִϸ��̼�)

    //����Ǵ� ����
    //�Լ��� �ߺ�ó��
    //���� �ð� �ڿ� �Լ��� �ѹ��� �Ĺٹ� ��� ȣ��Ǵ°� �Ƴ�...?
    //bool ���� ������ �ּ� �ش� bool�� ���̸� �۵� ����?

    void Update()
    {
        if(loadNow==false)
        {
            Debug.Log("���� ����,"+pattern);
            loadNow=true;
            //���� �ð� ���Ŀ� ���� ���� ������ Invoke
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

        //������ ü���� ���ϸ�
        if(bossHP<=0)
        {
            //�ı�����
            GameObject cloneAnim=Instantiate(anim, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(cloneAnim, delAnimTime);
            Destroy(gameObject);
            //����Ŭ���� ����
            clear.SetActive(true);
        }
    }

    //���� ����
    void SpawnSpear()
    {
        //������ ���� ��ġ �Ͻ�
        GameObject notif=Instantiate(notification, gameObject.transform.position, gameObject.transform.rotation);
        notif.transform.position=new Vector3(gameObject.transform.position.x-200, gameObject.transform.position.y, 0);
        //notif.GetComponent<Animator>().enabled=true;
        Destroy(notif, notfTime);
        //���� ������Ʈ ����
        Invoke("RealSpike",notfTime+termTime);
        //���� �� ���� �ִϸ��̼� ���
        loadNow=false;
    }
    
    //���� ���� �ð��� ȣ���
    void RealSpike()
    {
        GameObject atk=Instantiate(spearObj, gameObject.transform.position, gameObject.transform.rotation);
        atk.transform.position=new Vector3(gameObject.transform.position.x-200, gameObject.transform.position.y, 0);
        Destroy(atk, spikeTime);
    }

    //���� ����
    void SpawnSpear2()
    {
        //������ ���� ��ġ �Ͻ�
        GameObject notif=Instantiate(notification, gameObject.transform.position, gameObject.transform.rotation);
        notif.transform.position=new Vector3(gameObject.transform.position.x-280, gameObject.transform.position.y, 0);
        //notif.GetComponent<Animator>().enabled=true;
        Destroy(notif, notfTime);
        //���� ������Ʈ ����
        Invoke("RealSpike2",notfTime+termTime);
        //���� �� ���� �ִϸ��̼� ���
        loadNow=false;
    }
    
    //���� ���� �ð��� ȣ���
    void RealSpike2()
    {
        GameObject atk=Instantiate(spearObj, gameObject.transform.position, gameObject.transform.rotation);
        atk.transform.position=new Vector3(gameObject.transform.position.x-280, gameObject.transform.position.y, 0);
        Destroy(atk, spikeTime);
    }

    //���� ����
    void SpawnSpear3()
    {
        //������ ���� ��ġ �Ͻ�
        GameObject notif=Instantiate(notification, gameObject.transform.position, gameObject.transform.rotation);
        notif.transform.position=new Vector3(gameObject.transform.position.x-360, gameObject.transform.position.y, 0);
        //notif.GetComponent<Animator>().enabled=true;
        Destroy(notif, notfTime);
        //���� ������Ʈ ����
        Invoke("RealSpike3",notfTime+termTime);
        //���� �� ���� �ִϸ��̼� ���
        loadNow=false;
    }
    
    //���� ���� �ð��� ȣ���
    void RealSpike3()
    {
        GameObject atk=Instantiate(spearObj, gameObject.transform.position, gameObject.transform.rotation);
        atk.transform.position=new Vector3(gameObject.transform.position.x-360, gameObject.transform.position.y, 0);
        Destroy(atk, spikeTime);
    }

    //���� ����
    void SpawnSpear4()
    {
        SpawnSpear();
        SpawnSpear3();
        //���� �� ���� �ִϸ��̼� ���
        loadNow=false;
    }
/*
    //���� ����
    void SpawnSpore()
    {
        //������� �ִϸ��̼� ���
        //insiderAnime.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled=false;
        //��� �Ϸ� �� ���� ������Ʈ ����
        GameObject spore=Instantiate(sporeObj, gameObject.transform.position, gameObject.transform.rotation);
        spore.transform.position=new Vector3(gameObject.transform.position.x-170, gameObject.transform.position.y+100, 0);
        GameObject spore2=Instantiate(sporeObj, gameObject.transform.position, gameObject.transform.rotation);
        spore2.transform.position=new Vector3(gameObject.transform.position.x-220, gameObject.transform.position.y+120, 0);
        GameObject spore3=Instantiate(sporeObj, gameObject.transform.position, gameObject.transform.rotation);
        spore3.transform.position=new Vector3(gameObject.transform.position.x-270, gameObject.transform.position.y+140, 0);
        GameObject spore4=Instantiate(sporeObj, gameObject.transform.position, gameObject.transform.rotation);
        spore4.transform.position=new Vector3(gameObject.transform.position.x-320, gameObject.transform.position.y+160, 0);
        //��Ÿ���� �ִϸ��̼� ���
        Destroy(spore,sporeTime);
        Destroy(spore2,sporeTime);
        Destroy(spore3,sporeTime);
        Destroy(spore4,sporeTime);
        //���� �� ���� �ִϸ��̼� ���
        //outsiderAnim.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled=true;
        loadNow=false;
    }
*/
    //���� ����
    void SpawnWeapon()
    {
        int randNum=Random.Range(0,1);
        //�ϴÿ��� ���� ������ ���� ����
        GameObject weapon=Instantiate(weaponList.transform.GetChild(randNum).gameObject, gameObject.transform.position, gameObject.transform.rotation);
        weapon.transform.position=new Vector3(gameObject.transform.position.x-170, gameObject.transform.position.y, 0);
        //��� Ƚ���� 1~2�� ����
        loadNow=false;
    }

    //�ǰ� ó��
    void OnCollisionEnter2D(Collision2D atk)
    {
        if(atk.gameObject.tag.CompareTo("Attack")==0)
        {
            //���� Ÿ�ݽ� ü�� ���� ó���� Interaction���� ����
            SetInvicible();
        }
    }

    //���� ���� ó��
    void SetInvicible()
    {
        //�±׸� ���� ���·� ����
        gameObject.tag="Invicible";
        Invoke("EndInvicible",invicibleTime);
        //���� �ð�ó��
        gameObject.GetComponent<SpriteRenderer>().color=new Color(1,1,1,0.5f);
    }

    //���� ����
    void EndInvicible()
    {
        gameObject.GetComponent<SpriteRenderer>().color=new Color(1,1,1,1);
        gameObject.tag="Boss";
    }
}
