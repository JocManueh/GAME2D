using UnityEngine;
using UnityEngine.SceneManagement;

public class CHECKPOINT : MonoBehaviour
{
     public string nextSceneName;

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
        if (collision.CompareTag("Player"))
        {
            // Cambiar a la escena especificada
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
