using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    private int dumbell = 0;
    [SerializeField] private TextMeshProUGUI dumbellText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dumbell"))
        {
            Destroy(collision.gameObject);
            dumbell++;
            dumbellText.text = "Güç: " + dumbell;
        }
    }
}
