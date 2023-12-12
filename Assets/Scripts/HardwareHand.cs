using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardwareHand : MonoBehaviour
{
    [SerializeField]
    private  OVRInput.Controller controller;
    private Animator anim;
    public HandGrabInteractor handGrabInteractor;


    private void Start()
    {
        if (this.controller == OVRInput.Controller.RTouch)
        {

            this.handGrabInteractor.WhenInteractableSelected.Action += interactable =>
            {
                var grabbable = interactable.transform.GetComponentInParent<Grabbable>();
                //var weapon = grabbable.gameObject.GetComponent<Weapon>();
                //Debug.LogFormat("{0}을 집었습니다", weapon.GetWeaponType());
                Debug.LogFormat("{0}을 집었습니다", grabbable.gameObject.tag);
                if(grabbable.gameObject.CompareTag("HandGun"))
                {
                    Debug.Log("권총을 집었습니다.");
                }
                else if (grabbable.gameObject.CompareTag("Rifle"))
                {
                    Debug.Log("Rifle을 집었습니다.");
                }
            };

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (anim != null)
        {
            float grab = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);
            this.anim.SetFloat("Grab", grab);
        }
    }
    public void SetAnim(Animator anim)
    {
        this.anim = anim;
    }

}
