using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LoadDelay = 1.0f;
    [SerializeField] ParticleSystem carashVFX;
    /* void OnCollisionEnter(Collision other)
     {
         Debug.Log(this.name + " ---Colide with other--- " + other.gameObject.name);
     }*/

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log( $"{this.name} ***Colide with other*** {other.gameObject.name}");
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
       carashVFX.Play();
       GetComponent<PlayerController>().enabled = false;
       GetComponent<BoxCollider>().enabled = false;
       GetComponent<MeshRenderer>().enabled = false;
       Invoke("ReloadLevel1", LoadDelay);
    }

    void ReloadLevel1()
    {
        int curentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curentSceneIndex);
    }
}
