using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvlpassed : MonoBehaviour
{
    
    public DodecCheckState dodec;
    public CubeCheckState cube;
    [SerializeField]
    private GameObject _go;
    void Update()
    {
        if (dodec.DodecSolved && cube.CubeSolved)
        {
            _go.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
