using UnityEngine;
using System.Collections;


public class CollideEffects : MonoBehaviour {
    public GameObject particlePrefab;
    private float timeOut = 2.5f;
    private bool timedOut = false;

    public void OnCrash()
    {
        if (!timedOut)
        {
            timedOut = true;
            GameObject particle = Instantiate(particlePrefab, new Vector3(transform.position.x,transform.position.y,-1.5f), Quaternion.identity) as GameObject; 
        }
    }

    void Update()
    {
        if (timedOut)
        {
            timeOut -= 1 * Time.deltaTime;

            if (timeOut <= 0.0f)
            {
                timeOut = 2.5f;
                timedOut = false;
            }
        }
    }
}
