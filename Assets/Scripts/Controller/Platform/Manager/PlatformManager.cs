using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private PlatformLevelStore platformLevelStore;
    [SerializeField] private Vector3 offset;
    [SerializeField] private int level;

    public List<Platform> spawnedPlatforms = new List<Platform>();
    public Transform lastParent;

    private void Start()
    {
        LoadLevelData(); //test
    }

    private void LoadLevelData()
    {
        if(platformLevelStore.platformLevelData.Count == 0)
        {
            Debug.Log("No Platform Level Data");
            return;
        }

        Transform platformsParent = new GameObject("PlatfomParent").transform;
        //if(spawnedPlatforms)

        PlatformModels.PlatformBaseData? platformBaseData = platformLevelStore.platformLevelData[level - 1].GetRandomData();

        for (int i = 0; i < platformBaseData.Value.levelSequence.Count; i++)
        {
            Platform go = FactoryManager.Instance.prefabsPoolFactory.GetPlatform(platformBaseData.Value.levelSequence[i]);
            go.transform.position = (offset * i);
            go.gameObject.SetActive(true);
            spawnedPlatforms.Add(go);
            go.transform.SetParent(platformsParent);
        }

        lastParent = platformsParent;
    }
}
