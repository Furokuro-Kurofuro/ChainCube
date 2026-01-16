using UnityEngine;

public class CubeFactory : MonoBehaviour, ICubeFactory
{
    [SerializeField] private Cube _cubePrefab;
    
    public Cube CreateCube(Vector3 position)
    {
        var newCube = Instantiate(_cubePrefab, position, Quaternion.identity);
        
        newCube.transform.position = position;
        
        return newCube;
    }
}