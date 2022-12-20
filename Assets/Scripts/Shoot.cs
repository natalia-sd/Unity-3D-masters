using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float range = 100f;
    public Camera fpsCam;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootF();
        }
    }
    void ShootF()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position,
         fpsCam.transform.forward, out hit, range))
         {
            Debug.Log(hit.transform.name);
            CubeGetShot cubetarget = hit.transform.GetComponent<CubeGetShot>();
            if (cubetarget != null)
            {
                cubetarget.TakeDamage();
            }
            DodecGetShot dodectarget = hit.transform.GetComponent<DodecGetShot>();
            if (dodectarget != null)
            {
                dodectarget.TakeDamage();
            }
         }

    }
}
