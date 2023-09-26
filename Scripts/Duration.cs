using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Duration : MonoBehaviour
{
    public TextMeshProUGUI geriSayimText;
    private float sure = 30 * 40; 
    private bool saymaDevamEdiyor = true;

    void Start()
    {
        StartCoroutine(GeriyeSayimRoutine());
    }

    IEnumerator GeriyeSayimRoutine()
    {
        while (saymaDevamEdiyor)
        {
            int dakika = Mathf.FloorToInt(sure / 60);
            int saniye = Mathf.FloorToInt(sure % 60);
            float salise = Mathf.FloorToInt((sure % 1) * 100); 
            string sureMetni = string.Format("{0:00}:{1:00}:{2:00}", dakika, saniye, salise); 

            geriSayimText.text = sureMetni;

            yield return new WaitForSeconds(0.01f); 

            sure -= 0.01f; 

            if (sure <= 0)
            {
                saymaDevamEdiyor = false;
                geriSayimText.text = "Süre Bitti!";
                
            }
        }
    }
}
