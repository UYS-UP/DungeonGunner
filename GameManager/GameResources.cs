using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameResources : MonoBehaviour
{
    private static GameResources instance;

    public static GameResources Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<GameResources>("GameResources");
            }

            return instance;
        }
    }

    public RoomNodeTypeListSO roomNodeTypeList;
    public Material dimmedMaterial;
    
}
