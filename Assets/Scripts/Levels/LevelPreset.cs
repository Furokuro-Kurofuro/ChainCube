using UnityEngine;

[CreateAssetMenu(menuName = "LevelPreset")]
public class LevelPreset : ScriptableObject
{
    [SerializeField] private Vector3[] _cubePositions;
}
