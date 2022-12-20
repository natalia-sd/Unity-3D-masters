using UnityEngine;

public class CubeCheckState : MonoBehaviour
{
    public CubeGetShot[] tiles;
    public Light lightl;
    public GameObject wall;
    
    public bool CubeSolved = false;
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
            wall.SetActive(false);
            CubeSolved = true;
        }
    }

}
