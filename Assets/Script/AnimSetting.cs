using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSetting : MonoBehaviour
{
    //���� ��ȯ��
    SpriteRenderer sprRnder;
    Vector3 dirVec;     //���� ��ǥ
    //�÷��̾� ������
    float h;
    public GameObject player;
    Vector3 plrpos;

    void Awake()
    {
        sprRnder=GetComponent<SpriteRenderer>(); //��������Ʈ ������ ������
    }

    void Update()
    {
        plrpos=player.transform.position;
        //������Ʈ ������ȯ
        //�ø�
        if(Input.GetButton("Horizontal"))       //������� ��ư �Է��� �̷������
            sprRnder.flipX=Input.GetAxisRaw("Horizontal")==-1;       //������ ���� 1, �ƴϸ� 0 ��ȯ �� ��ȯ���� �̿��� �ø����� ó��
        //�ٶ󺸴� ����
        h=Input.GetAxisRaw("Horizontal");     //������� ����Ű �Է��� �޾Ƴ�. ������ 1, ������ -1, �߸��� 0
        if(h==-1)
        {
            dirVec=Vector3.left;
            //������Ʈ �ǽð� �̵�
            gameObject.transform.position=new Vector3(plrpos.x-60f, plrpos.y, plrpos.z);
        }
        else if(h==1)
        {
            dirVec=Vector3.right;
            //������Ʈ �ǽð� �̵�
            gameObject.transform.position=new Vector3(plrpos.x+60f, plrpos.y, plrpos.z);
        }
    }
}
