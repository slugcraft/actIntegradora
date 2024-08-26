using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Petalo : MonoBehaviour
{
    public int val = 0;
    public float angulo = 0f;
    public int muerte = 0;
    
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
            
            transform.Translate(Vector3.up * Time.deltaTime * val);
            
            // Obtener la rotación actual en ángulos de Euler
            Vector3 currentRotation = transform.rotation.eulerAngles;

            // Incrementar la rotación en el eje Y
            float newRotationZ = currentRotation.z + angulo * Time.deltaTime;

            // Aplicar la nueva rotación
            transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, newRotationZ);
    
        }
            
    }       
    

}
