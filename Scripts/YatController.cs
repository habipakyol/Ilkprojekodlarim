using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class YatController : MonoBehaviour
{
    //private Rigidbody rb;
    //public Camera mainCamera;
    //public float Menzil;
    //// Referans alýnacak objeyi tanýmlayýn
    //public GameObject binecekObjem;

    //public void Start()
    //{
    //    rb = GetComponent<Rigidbody>();

    //}

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;

    //        if (Physics.Raycast(ray, out hit) && Vector3.Distance(transform.position, hit.point) <= Menzil)
    //        {
    //            if (rb != null)
    //            {
    //                rb.MovePosition(hit.point);


    //                // Binecek objeyi hareket ettirin
    //                if (binecekObjem != null)
    //                {
    //                    binecekObjem.transform.position = hit.point;
    //                }
    //            }
    //        }
    //    }
    //}
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, Menzil);
    //}

    public float speed = 2f;
    public float rotationSpeed = 2f;
    public GameObject Yaqi;
    private Rigidbody rb;
    public GameObject Fyebas;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {


        float hzInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * hzInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * vInput);

        if (Yaqi != null)
        {
            Yaqi.transform.position = transform.position;
        }
        if (Input.GetKey(KeyCode.G))
        {
            gameObject.GetComponent<YatController>().enabled = false;
            Yaqi.gameObject.SetActive(true);
            
        }


    }
  
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Fyebas.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                gameObject.GetComponent<YatController>().enabled = true;
                collision.gameObject.SetActive(false);
                Fyebas.SetActive(false);
                
            }
           
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Fyebas.SetActive(false);
    }


}
