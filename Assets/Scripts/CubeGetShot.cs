using UnityEngine;

public class CubeGetShot : MonoBehaviour
{
    public void TakeDamage()
    {
        var pos = transform.localEulerAngles;
        transform.localEulerAngles = new Vector3(pos.x, pos.y, pos.z+90f);
    }
}
