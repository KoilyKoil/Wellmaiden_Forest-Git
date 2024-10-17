using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAnimSetting : MonoBehaviour
{
    public GameObject anim;
    public GameObject anim2;
    //public string animName;
    public float deleteTime=1f, fX, fY;

    void OnCollisionEnter2D(Collision2D col)
    {
        Vector3 dest=new Vector3(gameObject.transform.position.x+fX, gameObject.transform.position.y+fY, col.gameObject.transform.position.z); 
        if(col.gameObject.tag.CompareTo("Animation")==0)
        {
            if(anim)
            {
                GameObject showAnim=Instantiate(anim, dest, gameObject.transform.rotation);
                Destroy(showAnim, deleteTime);
            }
        }
        else if(col.gameObject.tag.CompareTo("Attack")==0)
        {
            if(anim2)
            {
                GameObject showAnim=Instantiate(anim2, dest, gameObject.transform.rotation);
                Destroy(showAnim, deleteTime);
            }
        }
    }
}
