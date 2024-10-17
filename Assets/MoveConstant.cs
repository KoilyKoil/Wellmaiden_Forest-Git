using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConstant : MonoBehaviour
{
    public float speed=3f;
    public bool dir;
    int dir2int;

    void Update()
    {
        if(dir==true)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX=true;
            dir2int=-1;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX=false;
            dir2int=1;
        }
        //일정 속도로 이동
        gameObject.transform.position=new Vector3(gameObject.transform.position.x+speed*dir2int,gameObject.transform.position.y,gameObject.transform.position.z);
    }
}
