using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyHard : MonoBehaviour
{

    private float speed = 5f;
    private Rigidbody enemyRb;
    private GameObject player;
    private float fallDistance = -20f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized ;
        enemyRb.AddForce(lookDirection * speed); 
        DestroyFallenEnemy();

    }

    private void DestroyFallenEnemy(){
        
        if (transform.position.y < fallDistance){
            Destroy(gameObject);
        }
    }
}
