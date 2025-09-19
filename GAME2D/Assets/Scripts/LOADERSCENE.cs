using UnityEngine;
using UnityEngine.SceneManagement;

public class LOADERSCENE : MonoBehaviour
{

    public string nameScene;
     public string nameScene2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
     public void PasaEscena()
    {
        SceneManager.LoadScene(nameScene);
    }
} 
