using UnityEngine;

public class DodecGetShot : MonoBehaviour
{
    public void TakeDamage()
    {
        var pos = transform.localEulerAngles;
        transform.localEulerAngles = new Vector3(pos.x, pos.y, pos.z+72f);
    }
}
