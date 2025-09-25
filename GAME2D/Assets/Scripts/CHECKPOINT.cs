using UnityEngine;
using UnityEngine.SceneManagement;
public class CHECKPOINT : MonoBehaviour
{
    public string nextSceneName;
    private bool yaActivado = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificamos que sea el jugador quien entra en el trigger
        if (collision.CompareTag("Player") && !yaActivado)
        {
            yaActivado = true;
            Debug.Log("¡Checkpoint 1 alcanzado! Guardando tiempo");

            // IMPORTANTE: Guardar el tiempo de la escena 1 antes de cambiar
            GameController1 gc1 = FindObjectOfType<GameController1>();
            if (gc1 != null)
            {
                gc1.addTime();
                Debug.Log("Tiempo de escena 1 guardado: " + GameManager.Instance.GlobalTime);
            }
            else
            {
                Debug.LogError("No se encontró GameController1 en la escena");
            }

            // Cambiar a la escena especificada
            SceneManager.LoadScene(nextSceneName);
        }
    }
}