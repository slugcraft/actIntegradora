using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bala : MonoBehaviour
{
    public int val = 0;
    public float muerte = 0;
   
    private BulletCounter bulletCounter;

    public float timeSinceLastSpawn = 0f;

    void Start()
    {
        // Encuentra el objeto con el BulletCounter (puede ajustarse según tu escena)
        bulletCounter = FindObjectOfType<BulletCounter>();

        bulletCounter.IncreaseBulletCount();
    }

    void Update()
    {    
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > muerte){
            bulletCounter.DecreaseBulletCount();
            Destroy(gameObject);
        }else{
            transform.Translate(Vector3.up * val * Time.deltaTime);   
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si la bala ha tocado al jugador
        if (other.CompareTag("Player") || other.CompareTag("Disparo"))
        {
            bulletCounter.DecreaseBulletCount();
            // Destruir la bala después de que termine el sonido
            Destroy(gameObject);
        }
    }
}