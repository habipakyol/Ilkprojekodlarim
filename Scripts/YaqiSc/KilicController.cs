using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilicController : MonoBehaviour
{
    [SerializeField] private CapsuleCollider capsuleCollider;
    public int damage = 5;
    public AudioSource kilic;
    public AudioSource kilic2;
    public AudioSource kilic3;
    public GameObject hasar;
    public GameObject hasar2;
    public GameObject hasar3;


    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        kilic.Stop();
        kilic2.Stop();
        kilic3.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            kilic.Play();
            capsuleCollider.enabled = true;
            ActivateSwordEffect2(transform.position);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            capsuleCollider.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            kilic2.Play();
            capsuleCollider.enabled = true;
            ActivateSwordEffect(transform.position);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            capsuleCollider.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            kilic3.Play();
            capsuleCollider.enabled = true;
            ActivateSwordEffect3(transform.position);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            capsuleCollider.enabled = false;
        }
    }



    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("enemy"))
    //    {
    //        ActivateSwordEffect(transform.position);
    //    }
    //}

    private void ActivateSwordEffect(Vector3 position)
    {
        if (hasar != null)
        {
            GameObject effectInstance = Instantiate(hasar, position, Quaternion.identity);
            Destroy(effectInstance, effectInstance.GetComponent<ParticleSystem>().main.duration);
        }
    }
    private void ActivateSwordEffect2(Vector3 position)
    {
        if (hasar2 != null)
        {
            GameObject effectInstance = Instantiate(hasar2, position, Quaternion.identity);
            Destroy(effectInstance, effectInstance.GetComponent<ParticleSystem>().main.duration);
        }
    }
    private void ActivateSwordEffect3(Vector3 position)
    {
        if (hasar3 != null)
        {
            GameObject effectInstance = Instantiate(hasar3, position, Quaternion.identity);
            Destroy(effectInstance, effectInstance.GetComponent<ParticleSystem>().main.duration);
        }
    }

}
