using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    public TextMeshProUGUI damageText;  // Referencia al TextMeshPro
    public float vida = 10;
    public float speed = 5.0f;
    public float clone ;

    private Vector3 movement;

    public float horizontalInput;
    public float forwardInput;

    public AudioClip destroySound;  // Asigna el sonido desde el Inspector

    private AudioSource audioSource;

    public GameObject bulletPrefab;  // El prefab de la bala
    public Transform bulletSpawnPoint;  // El punto desde donde se disparará la bala
    public float bulletSpeed = 10f;  // Velocidad de la bala
    public KeyCode shootKey = KeyCode.Space;  // Tecla para disparar
    public KeyCode slower = KeyCode.LeftShift; // Tecla para frenar

    public Renderer objectRenderer;  // Referencia al Renderer del objeto
    public Color originalColor;  // Color original del objeto

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Obtener el Renderer del objeto
        objectRenderer = GetComponent<Renderer>();
        // Guardar el color original del objeto
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }

        clone = speed/2;
        
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        damageText.text =""+vida;
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        

        if (Input.GetKeyDown(shootKey))
        {
            Shoot();
        }

        // Crear un vector de movimiento basado en la entrada del teclado
        movement = new Vector3(horizontalInput, forwardInput, 0.0f);
        // Establecer los parámetros en el Animator
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        
        if (Input.GetKey(slower)){
            Debug.Log("Se apreto");
            transform.Translate(movement * 0 * Time.deltaTime, Space.World);
        }else{
        /*
        if (Input.GetKeyUp(slower)) {
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }*/
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
        
        
        
    }

    

    void OnTriggerEnter(Collider other)
    {
        // Verificar si la bala ha tocado al jugador
        if (other.CompareTag("Bullet"))
        {
            vida -= 1;
            // Reproducir el sonido de destrucción
            audioSource.PlayOneShot(destroySound);
            StartCoroutine(FlashRed());
        }
    }

    void Shoot()
    {
        Quaternion rotation;

        if(horizontalInput < 0){
            rotation = Quaternion.Euler(0,0,90);
        }else if(horizontalInput > 0){
            rotation = Quaternion.Euler(0,0,-90);
        }else if(forwardInput < 0){
            rotation = Quaternion.Euler(0,0,180);
        }
        else{
            rotation = Quaternion.Euler(0,0,0);
        }
        // Instanciar la bala en la posición y rotación del punto de disparo
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, rotation);
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