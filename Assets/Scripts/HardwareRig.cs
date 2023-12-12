using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardwareRig : MonoBehaviour
{
    public HardwareHead headset;
    public HardwareHand leftHand;
    public HardwareHand rightHand;

    public NetworkRig networkRig;

    private void Update()
    {
        if (networkRig != null)
        {
            this.networkRig.SetPositionAndRotation(this.transform.position,this.transform.rotation);

            this.networkRig.leftHand.SetLocalPosition(this.leftHand.transform.localPosition);
            this.networkRig.leftHand.SetLocalRotation(this.leftHand.transform.localRotation);

            this.networkRig.rightHand.SetLocalPosition(this.rightHand.transform.localPosition);
            this.networkRig.rightHand.SetLocalRotation(this.rightHand.transform.localRotation);


            this.networkRig.headset.SetLocalPosition(this.headset.transform.localPosition);
            this.networkRig.headset.SetLocalRotation(this.headset.transform.localRotation);
        }
    }

    public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
    {
        this.transform.position = position;
        this.transform.rotation = rotation;
        
        this.networkRig.SetPositionAndRotation(position, rotation);
    }

    public void Init(NetworkRig networkRig,Animator leftHandAnim,Animator rightHandAnim)
    {
        this.networkRig = networkRig;
        this.leftHand.SetAnim(leftHandAnim);
        this.rightHand.SetAnim(rightHandAnim);
    }
}
