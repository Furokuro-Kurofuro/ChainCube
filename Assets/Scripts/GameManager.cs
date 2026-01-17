using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelPreset[] levelPresets;

    private void Start()
    {
        RestartLevel();
    }
    
    private void RestartLevel()
    {
        CubeFactory.Instance.ClearAll();
        InitialPlacement();
    }

    private void InitialPlacement()
    {
        var randomLevel = Random.Range(0, levelPresets.Length);

        foreach (var cube in levelPresets[randomLevel].Cubes)
        {
            CubeFactory.Instance.CreateCube(cube.Position, cube.Number);
        }
    }
}
