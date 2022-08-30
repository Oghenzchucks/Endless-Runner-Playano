using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Platform/" + nameof(PlatformLevelStore))]
public class PlatformLevelStore : ScriptableObject
{
    public List<PlatformModels.PlatformLevelData> platformLevelData = new List<PlatformModels.PlatformLevelData>();
}
