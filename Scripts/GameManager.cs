using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int toplanmasýgerekentassayisi = 10;
    public int toplananTassayisi;
    public GameObject kapýSon;
    public GameObject kapýSonefekt;
    public GameObject shark;
    public GameObject E1;
    public GameObject E11;
    public GameObject E2;
    public GameObject E22;
    public GameObject E3;
    public GameObject E33;
    public GameObject E4;
    public GameObject E44;
    public TextMeshProUGUI tas;

    public GameObject tas1;
    public GameObject tas2;
    public GameObject tas3;

    public GameObject efektSon;
    public GameObject oyunbitti;
    private void Start()
    {
        shark.SetActive(false);
        E1.SetActive(false);
        E11.SetActive(false);
        E2.SetActive(false);
        E3.SetActive(false);
        E4.SetActive(false);
        E22.SetActive(false);
        E33.SetActive(false);
        E44.SetActive(false);
    }
    private void Update()
    {
        tas.text = "Taþ:" + toplananTassayisi.ToString();
        if(toplananTassayisi == 2)
        {
            tas1.SetActive(true);
            tas2.SetActive(true);
            tas3.SetActive(true);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Topla"))
        {
            Destroy(other.gameObject);
            Tastopla();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("e1"))
        {
            E1.SetActive (true);
            E11.SetActive (true);
        }
        if (collision.gameObject.CompareTag("e2"))
        {
            E2.SetActive(true);
            E22.SetActive(true);
        }
        if (collision.gameObject.CompareTag("e3"))
        {
            E3.SetActive(true);
            E33.SetActive(true);
        }
        if (collision.gameObject.CompareTag("e4"))
        {
            E4.SetActive(true);
            E44.SetActive(true);
        }
        if (collision.gameObject.CompareTag("F"))
        {
            efektSon.SetActive (true);
            oyunbitti.SetActive (true);
            Time.timeScale = 0f;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("e1"))
        {
            E11.SetActive(false);
        }
        if (collision.gameObject.CompareTag("e2"))
        {
            E22.SetActive(false);
        }
        if (collision.gameObject.CompareTag("e3"))
        {
            E33.SetActive(false);
        }
        if (collision.gameObject.CompareTag("e4"))
        {
            E44.SetActive(false);
        }
    }
    public void Balýk()
    {
        if (toplananTassayisi == 8)
        {
            shark.SetActive(true);
        }
    }
    public void Tastopla()
    {
        toplananTassayisi++;
        if (toplananTassayisi == 10)
        {
            kapýSon.SetActive(false);
            kapýSonefekt.SetActive(true);
            Debug.Log("Oyun bitti");
        }
    }

   
}
