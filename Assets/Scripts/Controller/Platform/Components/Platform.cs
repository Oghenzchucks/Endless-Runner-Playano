using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public EnumClass.PlatformType platformType;
    public bool recycle;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (recycle)
            {
                Recycle();
            }
        }
    }

    public void Recycle()
    {
        FactoryManager.Instance.prefabsPoolFactory.RecyclePlatform(this);
    }
}
