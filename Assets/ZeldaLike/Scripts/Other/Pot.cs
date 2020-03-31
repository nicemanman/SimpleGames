using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Pot : MonoBehaviour, Smashable
{
    [SerializeField] private Animator animator;
    public void Smash()
    {
        animator?.SetBool("GotDamage", true);
        StartCoroutine(waitAndDestroy());
    }

    private IEnumerator waitAndDestroy() 
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
    public void Awake()
    {
        tag = "Smashable";
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hurtable")) 
        {
            Smash();
        }
    }
}
