using UnityEngine;

public class DodecCheckState : MonoBehaviour
{
    public DodecGetShot[] tiles;
    public Light lightl;
    public bool DodecSolved = false;

    // Update is called once per frame
    void Update()
    {
        int correctTiles = 0;
        foreach (var a in tiles)
        {
            if (a != null)
            {
                if (a.inRightPlace)
                {
                    correctTiles++;
                }
            }
        }
        if (correctTiles == tiles.Length)
        {
            lightl.enabled = true;
            DodecSolved = true;
        }
    }
}