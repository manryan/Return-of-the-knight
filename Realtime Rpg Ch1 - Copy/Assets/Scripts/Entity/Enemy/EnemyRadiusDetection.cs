using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadiusDetection : MonoBehaviour {

    public Enemy enemy;

    void OnTriggerEnter2D(Collider2D c)
    {

        if (c.gameObject.tag == "Player")
        {
            if (enemy.enemyState != EnemyState.Wait)
            {
                enemy.manager.addEnemyToARing(enemy);
                enemy.nav.isStopped = false;

                //       movement[0] = 2;
                //  target = c.transform;
                //  nav.destination = target.position;
         //      enemy.enemyState = EnemyState.Chasing;
            }
            //  nav.agent.stoppingDistance = 2;
            enemy.alerted = true;
            //   StartCoroutine(startAttacking());
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            enemy.alerted = false;
                enemy.switching();
            if (enemy.posRef != null)
                enemy.manager.leaveSpot(enemy);
        }
    }

}
