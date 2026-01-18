using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour, ICubeFactory
{
    public static CubeFactory Instance {get; private set;}
    
    [SerializeField] private Cube cubePrefab;
    [SerializeField] private CubeController playerCubePrefab;
    private readonly Vector3 playerCubePosition = new Vector3(0, 0.5f, -4.4f);
    
    private List<Cube> cubes;
    
    [SerializeField] private CubeVisualConfigSO visualConfigSo;

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

        newCube.Initialize(number, visualConfigSo);
        
        return newCube;
    }

    public CubeController CreateCubeToPlayer()
    {
        int[] numbers = { 2, 4, 8, 16 };
        
        var newCube = Instantiate(playerCubePrefab, playerCubePosition, Quaternion.identity);

        var cube = newCube.GetComponent<Cube>();
        
        cube.Initialize(numbers[Random.Range(0, numbers.Length)], visualConfigSo);
        
        return newCube;
    }

    public void ClearAll()
    {
        foreach (var cube in cubes)
            Destroy(cube);
        
        cubes.Clear();
    }
}