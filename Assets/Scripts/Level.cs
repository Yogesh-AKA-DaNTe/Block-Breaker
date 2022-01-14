using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // Number of breakable blocks
    SceneLoader sceneLoader; // For storing SceneLoader

    void Start()
    {
        // Assigning SceneLoader
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Function to count number of Breakable blocks
    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    // Function which decreases the number of breakable blocks when a block is destroyed
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            // Loads next scene when there are no more breakable blocks on the scene
            sceneLoader.LoadNextScene();
        }
    }
}
