using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelPreset")]
public class LevelPreset : ScriptableObject
{
    public List<CubePresetData> Cubes;
}