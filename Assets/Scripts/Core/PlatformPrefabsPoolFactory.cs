using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Pool/" + nameof(PlatformPrefabsPoolFactory))]
public class PlatformPrefabsPoolFactory : ScriptableObject
{
    [SerializeField] private List<PlatformModels.PlatformTypesData> platformPrefabs;

    private Dictionary<EnumClass.PlatformType, List<Platform>> platformPrefabsPool = new Dictionary<EnumClass.PlatformType, List<Platform>>();

    public Platform GetPlatform(EnumClass.PlatformType platformType)
    {
        Platform platform;

        if (platformPrefabsPool.ContainsKey(platformType))
        {
            platform = platformPrefabsPool.GetValueOrDefault(platformType).FirstOrDefault();
            platformPrefabsPool.GetValueOrDefault(platformType).Remove(platform);

            if(platformPrefabsPool.GetValueOrDefault(platformType).Count == 0)
            {
                platformPrefabsPool.Remove(platformType);
            }

            //Debug.Log("re-used Instance");
        }
        else
        {
            platform = Instantiate(platformPrefabs.Where(x => x.platformType == platformType).FirstOrDefault().platform);
            //Debug.Log("spawned new Instance");
        }

        return platform;
    }

    public void RecyclePlatform(Platform platform)
    {
        EnumClass.PlatformType platformType = platform.platformType;

        if (!platformPrefabsPool.ContainsKey(platformType))
        {
            List<Platform> newPlatformsList = new List<Platform>();
            newPlatformsList.Add(platform);
            platformPrefabsPool.Add(platformType, newPlatformsList);
        }
        else
        {
            platformPrefabsPool.GetValueOrDefault(platformType).Add(platform);
        }
        platform.gameObject.SetActive(false);

        //Debug.Log(platformPrefabsPool.GetValueOrDefault(platformType).Count);
        //Debug.Log("added to the list");
    }
}