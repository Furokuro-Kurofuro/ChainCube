using UnityEngine;

[CreateAssetMenu(menuName = "CubeVisualConfig")]
public class CubeVisualConfigSO : ScriptableObject
{
    [SerializeField] private CubeVisualData[] visualCubes;

    public Material GetMaterial(int number)
    {
        foreach (var visualCube in visualCubes)
        {
            if (visualCube.Number == number)
            {
                return visualCube.Material;
            }
        }
        
        return null;
    }
}