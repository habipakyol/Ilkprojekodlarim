using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NegatifTas : MonoBehaviour
{
    public Text taþSayýsýText; // UI üzerindeki toplam taþ sayýsýný gösterecek Text bileþeni
    private int toplananTaþlar = 0; // Toplanan taþ sayýsý

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Karakter, "1tas" etiketine sahip bir objeyle çarpýþýrsa
        {
            Destroy(gameObject);
            toplananTaþlar++; // Toplanan taþ sayýsýný artýr
            GüncelleTaþSayýsýText(); // Toplanan taþ sayýsýný UI'da güncelle
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player")) // Karakter, "1tas" etiketine sahip bir objeyle çarpýþýrsa
    //    {
    //        Destroy(gameObject);
    //        toplananTaþlar++; // Toplanan taþ sayýsýný artýr
    //        GüncelleTaþSayýsýText(); // Toplanan taþ sayýsýný UI'da güncelle
    //    }
    //}
    private void GüncelleTaþSayýsýText()
    {
        taþSayýsýText.text = toplananTaþlar.ToString(); // UI üzerindeki toplam taþ sayýsýný güncelle
    }
}
