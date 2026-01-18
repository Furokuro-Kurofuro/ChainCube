using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    private CubeController cubeController;

    private void Start()
    {
        Instance = this;
        
        var newCube = CubeFactory.Instance.CreateCubeToPlayer();

        cubeController = newCube.GetComponent<CubeController>();
        
        cubeController.cubePushed += NextCubeStart;
    }
    
    public IEnumerator NextCube()
    {
        yield return new WaitForSeconds(1);
        
        var newCube = CubeFactory.Instance.CreateCubeToPlayer();
        
        
        var newCubeController = newCube.GetComponent<CubeController>();
        
        newCubeController.enabled = true;
        newCubeController.cubePushed += NextCubeStart;
    }

    public void NextCubeStart()
    {
        StartCoroutine(NextCube());
    }
}