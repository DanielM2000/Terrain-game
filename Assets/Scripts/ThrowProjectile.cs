using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ThrowProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float throwSpeed = 2000;
    public AudioClip throwSound;
    private AudioSource throwSource;
    private float minThrowPitch = 0.75f;
    private float maxThrowPitch = 1.25f;
    void Start()
    {
        throwSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            float randomPitch = Random.Range(minThrowPitch, maxThrowPitch);
            throwSource.pitch = randomPitch;
            throwSource.clip = throwSound;
            throwSource.Play();
            GameObject rock = Instantiate(projectile, transform.position, transform.rotation) as
           GameObject;
            Rigidbody rb = rock.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Vector3.forward * throwSpeed);
        }
    }
}