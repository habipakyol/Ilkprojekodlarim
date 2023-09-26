using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PozitifTas : MonoBehaviour
{
    public Text ta�Say�s�Text; // UI �zerindeki toplam ta� say�s�n� g�sterecek Text bile�eni
    private int toplananTa�lar = 0; // Toplanan ta� say�s�

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sword")) // Karakter, "1tas" etiketine sahip bir objeyle �arp���rsa
        {
            Destroy(gameObject);
            toplananTa�lar++; // Toplanan ta� say�s�n� art�r
            G�ncelleTa�Say�s�Text(); // Toplanan ta� say�s�n� UI'da g�ncelle
        }
    }
    private void G�ncelleTa�Say�s�Text()
    {
        ta�Say�s�Text.text = toplananTa�lar.ToString(); // UI �zerindeki toplam ta� say�s�n� g�ncelle
    }
}
