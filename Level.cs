using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    public List<GameObject> modules = new List<GameObject>();
    public List<GameObject> activeModules = new List<GameObject>();
    public List<GameObject> chunks = new List<GameObject>();

    public GameObject chunkPrefab;
    public GameObject chunkLoaderPrefab;

    public int numParts = 10;
    public int chunkUnloadDelay = 10;
    
    private float offset = 4.0f;
    private int previousRand = 0;
    private int modulesSpawned = 0;
    private int chunksSpawned = 0;
    private int previouschunk = 0;

	// Use this for initialization

    void GenerateInititalChunk()
        {
            GameObject chunk = Instantiate(chunkPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            chunks.Add(chunk);
            
           for(int i = 0; i < numParts; i++)
           {
                int randomPart = Random.Range(0, modules.Count);
                
               if (previousRand != randomPart)
                {
                previousRand = randomPart;
                }
               
               else if (previousRand == randomPart)
               {
                randomPart = Random.Range(0, modules.Count);
               }

            GameObject part = Instantiate(modules[randomPart], new Vector3(i * offset, 0.0f, 0.0f), Quaternion.identity) as GameObject;
            part.transform.parent = chunks[chunks.Count-1].transform;
            activeModules.Add(part);
            modulesSpawned++;
            if (modulesSpawned == numParts - 1)
            {
                Debug.Log("Test");
                GameObject chunkLoader = Instantiate(chunkLoaderPrefab, new Vector3(i * offset, 0.0f, 0.0f), Quaternion.identity) as GameObject;
                chunkLoader.transform.parent = part.transform;
                chunkLoader.transform.localPosition = Vector3.zero;
            }
            }

           Debug.Log(modulesSpawned);
           modulesSpawned = 0;
           previouschunk = chunksSpawned - 1;
            chunksSpawned++;
        }

    
    void Start () {
        GenerateInititalChunk();
	}

    IEnumerator DespawnPreviousChunk()
    {
        yield return new WaitForSeconds(chunkUnloadDelay);
        chunks[previouschunk].SetActive(false);
    }

    void GenerateChunk()
    {
        GameObject chunk = Instantiate(chunkPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        chunks.Add(chunk);

        float chunkWidth = chunksSpawned * numParts;
        float chunkOffset = chunkWidth * offset;
       
        Vector3 chunkPosition = new Vector3(chunkOffset, 0.0f, 0.0f);
        chunk.transform.position = chunkPosition;

        for (int i = 0; i < numParts; i++)
        {
            int randomPart = Random.Range(0, modules.Count);

            if (previousRand != randomPart)
            {
                previousRand = randomPart;
            }

            else if (previousRand == randomPart)
            {
                randomPart = Random.Range(0, modules.Count);
            }

           
            
            Debug.Log("Spawned New Chunk at: " + chunkOffset);
            GameObject part = Instantiate(modules[randomPart], new Vector3(chunkOffset + (i * offset), 0.0f, 0.0f), Quaternion.identity) as GameObject;
            
            part.transform.parent = chunks[chunks.Count-1].transform;
            activeModules.Add(part);
            modulesSpawned++;
            if (modulesSpawned == numParts - 1)
            {
                
                Debug.Log("Test");
                GameObject chunkLoader = Instantiate(chunkLoaderPrefab, new Vector3((numParts / 2 * chunks.Count +1) * offset + (i * offset), 0.0f, 0.0f), Quaternion.identity) as GameObject;
                chunkLoader.transform.parent = part.transform;
                chunkLoader.transform.localPosition = Vector3.zero;
                
            }
        }
        previouschunk = chunksSpawned -1;
        chunksSpawned++;
        modulesSpawned = 0;
        StartCoroutine(DespawnPreviousChunk());
    }

	// Update is called once per frame
	void Update () {
	
 


	}

 
}

