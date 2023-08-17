using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;

    ScoreBoard scoreBoard;
    private int scorePerHit = 15;

    void Start()
    {
       scoreBoard = FindAnyObjectByType<ScoreBoard>();   
    }
    void OnParticleCollision(GameObject other)
    {
        // Debug.Log("Hit by: "+ other.gameObject.name);
        ProcessHit();
        KillEnemy();
    }

    void ProcessHit()
    {
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
