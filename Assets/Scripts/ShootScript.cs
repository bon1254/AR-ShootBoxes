using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public PlayerStats playerStats;
    public UIController UIcontroller;
    public GameObject floatingText;

    public GameObject arCamera;
    public GameObject smoke;    

    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            if (hit.transform.name == "Crate_12(Clone)" || hit.transform.name == "Crate_14(Clone)" || hit.transform.name == "Crate_15(Clone)")
            {
                Destroy(hit.transform.gameObject);

                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));

                GameObject ft = Instantiate(floatingText, hit.point,  transform.rotation);
                Destroy(ft, 2f);

                playerStats.GetPoints();
            }
            else if (hit.transform.name == "Crate_13(Clone)")
            { 
                playerStats.TakeDamge(1);
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));

                Destroy(hit.transform.gameObject);
            }
        }
    }
}
