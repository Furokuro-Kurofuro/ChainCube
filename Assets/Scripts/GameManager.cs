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

        foreach (var position in levelPresets[randomLevel].CubePositions)
        {
            CubeFactory.Instance.CreateCube(position);
        }
    }
}
