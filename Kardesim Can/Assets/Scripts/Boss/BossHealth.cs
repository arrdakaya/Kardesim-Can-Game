using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private float iFramesDuration;
    public int health = 300;
    public int currentHealth;
    private SpriteRenderer spriteRend;

    //public GameObject deathEffect;

    public bool isInvulnerable = false;

    private void Awake()
    {

        currentHealth = health;
        //anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;
       
        if (currentHealth > 0)
        {
            //anim.SetTrigger("hurt");
            StartCoroutine("Invunerability");
        }


        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SceneManager.LoadScene("WinScene");
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