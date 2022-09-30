using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject boss;
    public GameObject bossHealth;
    public GameObject textObj;
    public Transform bossPos;
    public AudioSource playSound;
    public AudioSource ammansound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            textObj.SetActive(true);
            boss.SetActive(true);
            bossHealth.SetActive(true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine("Info");
            playSound.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            ammansound.Stop();
        }
    }

    IEnumerator Info()
    {
        yield return new WaitForSeconds(3f);
        textObj.SetActive(false);
    }
}
