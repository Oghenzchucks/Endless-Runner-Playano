using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformModels 
{
    [System.Serializable]
    public struct PlatformTypesData
    {
        public EnumClass.PlatformType platformType;
        public Platform platform;
    }

    [System.Serializable]
    public class PlatformLevelData
    {
        public int level;
        public List<PlatformBaseData> platformBaseData;

        public PlatformBaseData? GetRandomData()
        {
            if (platformBaseData.Count == 0)
            {
                Debug.Log("No Platform Base Data");
                return null;
            }

            return platformBaseData[Random.Range(0, platformBaseData.Count)];
        }
    }

    [System.Serializable]
    public struct PlatformBaseData
    {
        public List<EnumClass.PlatformType> levelSequence;
    }
}
