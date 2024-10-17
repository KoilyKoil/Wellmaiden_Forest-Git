using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invicible : MonoBehaviour
{
    GameObject plr;

    //公利 贸府侩
    int invicibleTime=3;


    public void SetInvicible(GameObject what)
    {
        plr=what;
        //怕弊甫 公利 惑怕肺 函版
        plr.tag="Invicible";
        //公利 矫阿贸府
        plr.GetComponent<SpriteRenderer>().color=new Color(1,1,1,0.5f);
        //公利 辆丰 龋免贸府
        Invoke("EndInvicible",invicibleTime);
    }

    //公利 辆丰
    public void EndInvicible()
    {
        plr.GetComponent<SpriteRenderer>().color=new Color(1,1,1,1);
        plr.tag="Player";
        
    }
}
