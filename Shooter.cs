using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.2f;
    
    [SerializeField] AudioClip projectileVFX;
    [SerializeField] float volume;
    
    public bool isFiring;

    Coroutine firingCoroutine;

    void Start()
    {

    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuosly());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuosly()
    {
        while(true)
        {                                      //what              where            rotation (zero)
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            
            Rigidbody2D myRigidbody = instance.GetComponent<Rigidbody2D>();
            if(myRigidbody != null)
            {
                myRigidbody.velocity = transform.right * projectileSpeed;
            }
            
            AudioSource.PlayClipAtPoint(projectileVFX, Camera.main.transform.position, volume);
                    //what     when
            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
    }
}
