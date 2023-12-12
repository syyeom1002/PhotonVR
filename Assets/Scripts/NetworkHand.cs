using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkHand : MonoBehaviour
{
   public  Animator anim;
    public void SetLocalPosition(Vector3 pos)
    {
        this.transform.localPosition = pos;
    }

    public void SetLocalRotation(Quaternion rot)
    {
        this.transform.localRotation = rot;
    }

}
