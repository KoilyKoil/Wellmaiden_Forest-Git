using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCall : MonoBehaviour
{
    public GameObject boss;

    void OnCollisionEnter2D(Collision2D other)
    {
        Transform myParent=gameObject.transform;
        GameObject bossClone=Instantiate(boss, myParent.position, myParent.rotation);

        Vector3 forPos=bossClone.transform.position;
        forPos.z=500f;
        bossClone.transform.position=forPos;

        bossClone.SetActive(true);
        gameObject.SetActive(false);
    }
}
