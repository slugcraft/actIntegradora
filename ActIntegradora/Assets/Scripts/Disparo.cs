using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public int val = 5;
    public float muerte = 3;

    void Start()
    {
        Destroy(gameObject, muerte);
    }

    void Update()
    {    
        transform.Translate(Vector3.up * val * Time.deltaTime);   
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si la bala ha tocado al jugador
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
