using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockBackForce;
    public float timeToStop;
    //У нас есть только один триггер, который появляется во время взмаха мечом
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null) StartCoroutine(KnockingBack(enemy));
        }
    }

    private IEnumerator KnockingBack(Rigidbody2D enemy)
    {
        Vector2 force = enemy.transform.position - transform.position;
        force = force.normalized * knockBackForce;
        enemy.velocity = force;
        yield return new WaitForSeconds(timeToStop);
        enemy.velocity = new Vector2();
    }
   
}
