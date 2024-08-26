using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Palkia : MonoBehaviour
{
   
    public float vida = 30;
    public AudioClip deadSound;  // Asigna el sonido desde el Inspector

    private AudioSource audioSource;

    public Renderer objectRenderer;  // Referencia al Renderer del objeto
    public Color originalColor;  // Color original del objeto
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Obtener el Renderer del objeto
        objectRenderer = GetComponentInChildren<Renderer>();

        // Guardar el color original del objeto
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si la bala ha tocado al jugador
        if (other.CompareTag("Disparo"))
        {
            vida -= 1;
            StartCoroutine(FlashRed());
        }
        if(vida < 0){
            //audioSource.PlayOneShot(deadSound);
            //Destroy(gameObject, deadSound.length);
            Destroy(gameObject);
        }
    }

    private IEnumerator FlashRed()
    {
        // Cambiar el color del material a rojo
        objectRenderer.material.color = Color.red;

        // Esperar 0.2 segundos
        yield return new WaitForSeconds(0.2f);

        // Volver al color original
        objectRenderer.material.color = originalColor;
    }
}
