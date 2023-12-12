using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSceneMain : MonoBehaviour
{
    [SerializeField] private Animator animDefault;
    [SerializeField] private Animator animWithGun;
    [SerializeField] private GameObject rHandDefault;
    [SerializeField] private GameObject rHandWithGun;
    public bool isDefault=true;
    void Update()
    {
        if (isDefault)
        {
            this.rHandDefault.SetActive(true);
            this.rHandWithGun.SetActive(false);
            var handTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
            this.animDefault.SetFloat("Grab", handTrigger);
        }
        else
        {
            this.rHandDefault.SetActive(false);
            this.rHandWithGun.SetActive(true);
            var indexTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
            this.animWithGun.SetFloat("Grab", indexTrigger * 0.5f);
            
        }
    }
}
