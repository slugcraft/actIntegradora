using UnityEngine;
using TMPro;

public class BulletCounter : MonoBehaviour
{
    public TextMeshProUGUI bulletCountText;  // Referencia al TextMeshPro para mostrar el conteo
    private int bulletCount = 0;  // Contador de balas activas

    void Start()
    {
        UpdateBulletCountText();
    }

    // Método para aumentar el conteo de balas
    public void IncreaseBulletCount()
    {
        bulletCount++;
        UpdateBulletCountText();
    }

    // Método para disminuir el conteo de balas
    public void DecreaseBulletCount()
    {
        bulletCount--;
        UpdateBulletCountText();
    }

    // Actualiza el texto con el conteo actual de balas
    private void UpdateBulletCountText()
    {
        bulletCountText.text = "Bullets: " + bulletCount.ToString();
    }
}
