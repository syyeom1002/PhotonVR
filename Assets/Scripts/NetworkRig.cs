using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkRig : MonoBehaviour
{
    public NetworkHead headset;
    public NetworkHand rightHand;
    public NetworkHand leftHand;
    public PhotonView pv;

    public void Awake()
    {
        this.pv = this.GetComponent<PhotonView>();
        if (this.pv.IsMine)
        {
            var hardwareRig = GameObject.FindObjectOfType<HardwareRig>();
            hardwareRig.Init(this,this.leftHand.anim,this.rightHand.anim);
            //hardwareRig.networkRig = this;
        }
    }

    public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
    {
        this.transform.position = position;
        this.transform.rotation = rotation;
    }
}

