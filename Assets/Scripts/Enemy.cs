using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int hitPoints = 7;

    ScoreBoard scoreBoard;
    [SerializeField] private int scorePerHit = 15;

    void Start()
    {
        scoreBoard = FindAnyObjectByType<ScoreBoard>();
        AddRigidbody();
        AddParent();
    }

    private void AddParent()
    {
       // parent = Spawner.instance.transform;
       parent = GameObject.FindGameObjectWithTag("SpawnAtRunTime").transform;
    }

    private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }



    void OnParticleCollision(GameObject other)
    {
        // Debug.Log("Hit by: "+ other.gameObject.name);
        ProcessHit();
        if(hitPoints < 1)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        hitPoints--;
    }

    void KillEnemy()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject vfx = Instantiate(deathFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
