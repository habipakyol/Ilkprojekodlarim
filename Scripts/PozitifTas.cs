using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PozitifTas : MonoBehaviour
{
    public Text taşSayısıText; // UI üzerindeki toplam taş sayısını gösterecek Text bileşeni
    private int toplananTaşlar = 0; // Toplanan taş sayısı

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sword")) // Karakter, "1tas" etiketine sahip bir objeyle çarpışırsa
        {
            Destroy(gameObject);
            toplananTaşlar++; // Toplanan taş sayısını artır
            GüncelleTaşSayısıText(); // Toplanan taş sayısını UI'da güncelle
        }
    }
    private void GüncelleTaşSayısıText()
    {
        taşSayısıText.text = toplananTaşlar.ToString(); // UI üzerindeki toplam taş sayısını güncelle
    }
}
