using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("Configuración")]
    public string playerTag = "Player";
    private bool yaActivado = false;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar que sea el jugador y que no se haya activado ya
        if (other.CompareTag(playerTag) && !yaActivado)
        {
            yaActivado = true;
            Debug.Log("¡Checkpoint alcanzado!");

            // Buscar el GameController2 y terminar la escena
            GameController2 gameController = UnityEngine.Object.FindFirstObjectByType<GameController2>();
            if (gameController != null)
            {
                gameController.EndScene2();
            }
            else
            {
                Debug.LogError("No se encontró GameController2 en la escena");
            }
        }
    }
}
