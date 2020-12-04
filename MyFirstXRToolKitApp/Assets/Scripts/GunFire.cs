using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public float speed = 10;
    public GameObject bullet;
    public Transform spawnPoint;
    public AudioSource audioSource;
    public AudioClip audioClip;


    public void Fire()
    {
        GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * spawnPoint.forward;
        if(audioClip!=null)
            audioSource.PlayOneShot(audioClip);
        Destroy(spawnedBullet, 2);

    }
}
