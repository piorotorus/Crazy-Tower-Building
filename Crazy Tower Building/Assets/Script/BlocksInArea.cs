using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class BlocksInArea : MonoBehaviour
{
    private const string BLOCKS_TAG = "Block";
    GameObject[]  blocksInGame;

   public void GetAllBlocks()
    {
        blocksInGame = GameObject.FindGameObjectsWithTag(BLOCKS_TAG);
        List<GameObject> blocksInSceneList = blocksInGame.ToList();
        List<GameObject> blocksInGameAreaList=new List<GameObject>();
        for (int i = 0; i <blocksInSceneList.Count; i++)
        {
            if (!blocksInSceneList[i].GetComponent<CreateObject>())
            {
               blocksInGameAreaList.Add(blocksInSceneList[i]);
            }
        }
        
        TurnOffBlockKinematic(blocksInGameAreaList);
    }
    void TurnOffBlockKinematic(List<GameObject> blockInGameAreaList)
    {
        foreach (var block in blockInGameAreaList)
        {
            block.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
