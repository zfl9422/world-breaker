using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // state variable to keep track of all breakable blocks
    // Serialized for debugging
    [SerializeField] int totalBlocks;

    // cache reference
    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void AddBlock()
    {
        totalBlocks++;
    }

    public void RemoveBlock()
    {
        totalBlocks--;
        if (totalBlocks <= 0)
        {
            sceneloader.NextScene();
        }
    }
}
