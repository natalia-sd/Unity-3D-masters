using UnityEngine;

public class DodecGetShot : MonoBehaviour
{
    public bool inRightPlace;
    Vector3 correctPositon;

    private void Awake() {
        correctPositon = transform.localEulerAngles;
        var pos = transform.localEulerAngles;
        transform.localEulerAngles = new Vector3(pos.x, pos.y, pos.z+144f);
        //targetPosition = transform.localEulerAngles;
    }
    private void Update() 
    {
         var pos = transform.localEulerAngles;
        if (Vector3.Distance(pos, correctPositon) <= 10)
        {
            inRightPlace = true;
        }
    }
    public void TakeDamage()
    {
        var pos = transform.localEulerAngles;
        if (Vector3.Distance(pos, correctPositon) >= 10)
        {
            transform.localEulerAngles = new Vector3(pos.x, pos.y, pos.z+72f);
        }
    }
}

