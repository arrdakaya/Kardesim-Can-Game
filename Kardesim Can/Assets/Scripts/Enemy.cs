using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private float iFramesDuration;
    private SpriteRenderer spriteRend;

    public int maxHealth = 100;
    private int currentHealth;
    //public float speed;

    private Animator anim;
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        //anim.SetBool("isRunning", true);
    }
    private void Awake()
    {

        currentHealth = maxHealth;
        //anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject,1);
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth > 0)
        {
            StartCoroutine("Invunerability");
        }

        if (currentHealth <= 0)
        {
            Die();
            StartCoroutine("Invunerability");

        }
    }
    void Die()
    {
        anim.SetTrigger("die");
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(8, 7, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.7f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 7, true);
    }
}
