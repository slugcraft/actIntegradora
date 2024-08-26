using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flor : MonoBehaviour
{
    private float angulo = 0f;
    public GameObject prefab1;
    public GameObject prefab2;
    public Transform spawnPosition; 
    private float timeSinceLastSpawn = 0f;
    public float timeLimit = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void attack(){
        // Incrementar el tiempo transcurrido
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > timeLimit)
        {
            
            for(int i = 0; i<6 ; i++){
                // Convertir el ángulo a un Quaternion para la rotación
                Quaternion rotation = Quaternion.Euler(0, 0, angulo);
                // Instanciar el objeto con la posición y la rotación especificadas
                Instantiate(prefab1, spawnPosition.position, rotation);
                Instantiate(prefab2, spawnPosition.position, rotation);
                
                angulo += 60f;
            }    
            timeSinceLastSpawn = 0f;
            angulo = 0f;
        }
    }
}
