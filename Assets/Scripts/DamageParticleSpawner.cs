using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageParticleSpawner : MonoBehaviour
{
    public GameObject particles;
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void Spawn()
    {
        StartCoroutine(SpawnFor(particles,duration));
    }

    IEnumerator SpawnFor(GameObject g,float dur)
    {
        g.SetActive(true);
        yield return new WaitForSeconds(dur);
        g.SetActive(false);
    }
}
