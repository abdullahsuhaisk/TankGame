using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : Sense
{

    float fieldofView;//Görüş alanı açı olarak
    float viewDistance = 100f; //Görüş Uzunluğu
    public Transform playerTank;
    //Vector3 dir;
    public Transform rayOrgin;
    public Animator anim;

    public override void Initialize()
    {
        fieldofView = 60f;
        viewDistance = 100f;
        playerTank = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log("Başarılı");
        detectedtime = 0.3f;
    }

    public override void UpdateSense()
    {

        var dir = (playerTank.position - rayOrgin.position).normalized;
        Debug.DrawRay(rayOrgin.position, dir, Color.red);

        if (Vector3.Angle(dir, rayOrgin.forward) < 30 * 2)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrgin.position, dir, out hitInfo, viewDistance))
            {
                Aspect aspect = hitInfo.collider.GetComponent<Aspect>();
                if (aspect != null)
                    if (aspect.tankAspect == taspect)
                    {
                        anim.SetBool("isVisible", true);
                        Debug.Log("Düşman görüldü");
                        
                    }
                anim.SetBool("isVisible", false);
            }
            

        }
        else
        {
            Debug.Log("Görüş açısı dışında");
            anim.SetBool("isVisible", false);
        }
    }

}
