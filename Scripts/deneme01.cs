using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme01 : MonoBehaviour
{
    public int tascan = 50;
    public int currentCan;
    void Start()
    {
        
        currentCan = tascan;
    }
    private void OnTriggerEnter(Collider other)
    {
        KilicController kilicController = other.gameObject.GetComponent<KilicController>();
        if(kilicController != null )
        {
            HasarAlEnemy(kilicController.damage);
        }
        
    }
    public void HasarAlEnemy(int damage)
    {
        currentCan -= damage; 

        if (currentCan <= 0)
        {
            Destroy(gameObject); 
        }
    }
}
