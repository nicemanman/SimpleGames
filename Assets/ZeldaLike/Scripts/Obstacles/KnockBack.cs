using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockBackForce;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null) StartCoroutine(KnockCoroutine(enemy));
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D obj)
    {
        Vector2 forceDirection = obj.transform.position - transform.position;
        Vector2 force = forceDirection.normalized * knockBackForce;

        obj.velocity = force;
        yield return new WaitForSeconds(.3f);

        obj.velocity = new Vector2();
    }
}
