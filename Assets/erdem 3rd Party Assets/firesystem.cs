using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firesystem : MonoBehaviour
{
    public Transform firepoint;
    public GameObject mermiPrefab;
    public float mermiHýzý = 10f;
    public AudioSource seskaynak;
    public float guncool;
    public float firetime;
    public ParticleSystem muzzleFlash;
    RaycastHit hit;
    public GameObject bloodeffect;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > firetime + guncool)
        {
            AteþEt();
            firetime = Time.time;
        }
    }

    void AteþEt()
    {
        GameObject mermi = Instantiate(mermiPrefab, firepoint.position, firepoint.rotation);
        
        
        mermi.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        Rigidbody rb = mermi.GetComponent<Rigidbody>();
        rb.velocity = firepoint.forward * mermiHýzý;
         
        seskaynak.Play();
        muzzleFlash.Play();
        if (Physics.Raycast(firepoint.position, firepoint.forward, out hit))
        {
            Destroy(mermi,1f);
            Debug.Log("Vurulan Nesne: " + hit.collider.gameObject.name);
        }
        if (hit.transform.tag == "enemy")
        {

            Instantiate(bloodeffect, hit.point, Quaternion.LookRotation(hit.normal));
            

        }

    }
     
    
}

