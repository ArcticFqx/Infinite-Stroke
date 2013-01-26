using UnityEngine;
using System.Collections;

public class ChunkLoader : MonoBehaviour {

    private bool used = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && used == false)
        {
            used = false;
            Camera.mainCamera.gameObject.SendMessage("GenerateChunk");
        }
    }
	
}
