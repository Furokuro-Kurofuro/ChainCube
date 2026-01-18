using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelPreset")]
public class LevelPresetConfigSO : ScriptableObject
{
    public List<CubePresetData> Cubes;
}