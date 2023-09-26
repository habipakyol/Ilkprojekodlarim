using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YaqiHealth : MonoBehaviour
{
    public int maxCan = 100; 
    public int currentCan; 
    public Text txtCan;
    public Animator animator;
   
    public void Start()
    {
    
        animator = GetComponent<Animator>();
        currentCan = maxCan; 
        StartCoroutine(IncreaseHealthOverTime());
    }
    private void Update()
    {
        txtCan.text = "Yaqi:" + currentCan.ToString();
        
    }
    private IEnumerator IncreaseHealthOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f); 

            if (currentCan < maxCan)
            {
                currentCan += 1; 

                if (currentCan > maxCan)
                    currentCan = maxCan; 
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        enemyattack enemy = other.GetComponent<enemyattack>();
        if(enemy != null)
        {
            HasarAl(enemy.damage);
        }
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("canUp"))
        {
            currentCan = 100;
            Destroy(collision.gameObject);  

        }
        //enemyattack enemy = collision.gameObject.GetComponent<enemyattack>();   
        //if (enemy != null)
        //{
        //    HasarAl(enemy.damage); // Rakip nesnesine temas ederse hasar al
        //}
        if (collision.gameObject.CompareTag("zemin"))
        {
            OyuncuOlum();
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
    public void HasarAl(int hasar)
    {
        currentCan -= hasar; 

        if (currentCan <= 0)
        {
            OyuncuOlum(); 
        }
    }

    public void OyuncuOlum()
    {
        Debug.Log("Oyuncu öldü.");
        animator.SetBool("Dead", true);

    }
}

