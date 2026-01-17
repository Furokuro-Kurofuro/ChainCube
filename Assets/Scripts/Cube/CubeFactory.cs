using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour, ICubeFactory
{
    public static CubeFactory Instance {get; private set;}
    
    [SerializeField] private Cube cubePrefab;
    
    private List<Cube> cubes;
    
    [SerializeField] private CubeVisualConfig visualConfig;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        
        cubes = new List<Cube>();
    }

    public Cube CreateCube(Vector3 position, int number)
    {
        var newCube = Instantiate(cubePrefab, position, Quaternion.identity);
        
        cubes.Add(newCube);
        
        newCube.transform.position = position;

        newCube.Initialize(number, visualConfig);
        
        return newCube;
    }

    public void ClearAll()
    {
        foreach (var cube in cubes)
            Destroy(cube);
        
        cubes.Clear();
    }
}