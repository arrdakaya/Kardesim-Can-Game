using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDestroy : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {
        StartCoroutine("panelDest");
    }
   
    IEnumerator panelDest()
    {
        yield return new WaitForSeconds(1.5f);
        panel.SetActive(false);
    }
}
