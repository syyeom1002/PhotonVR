using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RHandWithGun : MonoBehaviour
{
    [SerializeField] private Transform rightHandAnchor;
    [SerializeField] private TMP_Text debugText;
    [SerializeField] private Image debugImg;
    [SerializeField] private Animator magazineAnim;
    [SerializeField] private GameObject magazineGo;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRange = 2f;
    [SerializeField] private LineRenderer lineRenderer;
    private bool hasMagazine=true;
    private void Update()
    {
        DrawArrow.ForDebug(this.rightHandAnchor.position, rightHandAnchor.right, 0, Color.red, ArrowType.Solid);
        DrawArrow.ForDebug(Vector3.zero, Vector3.up, 0, Color.blue, ArrowType.Solid);
        
        float dot=Vector3.Dot(Vector3.up, this.rightHandAnchor.right);
        this.debugText.text = dot.ToString();

        if (dot > 0.9f&& OVRInput.GetDown(OVRInput.Button.One))
        {
            if (hasMagazine)
            {
                this.hasMagazine = false;
                Debug.Log("탄창이 빠집니다.");
                magazineAnim.SetTrigger("Remove");
                debugImg.color = Color.red;
                this.StartCoroutine(CoWaitRemoveMagazine());
            }
            else
            {
                if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    Debug.Log("탄창이 없습니다.");
                }
            }
        }
        else
        {
            debugImg.color = Color.blue;
        }

        this.DrawLine();
    }

    private void DrawLine()
    {
        Ray ray=new Ray(this.firePoint.position, this.firePoint.forward);
        Debug.DrawRay(ray.origin, ray.direction*this.fireRange, Color.red);
        var end = this.firePoint.position + (this.firePoint.forward * fireRange);

        this.lineRenderer.SetPosition(0, firePoint.position);
        this.lineRenderer.SetPosition(1, end);
        
    }
    private IEnumerator CoWaitRemoveMagazine()
    {
        yield return new WaitForSeconds(0.25f);
        this.magazineGo.SetActive(false);
    }
}
