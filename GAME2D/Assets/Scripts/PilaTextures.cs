//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class PilaTextures : MonoBehaviour {

//    // Pila global para toda la clase
//    Stack<string> pilanombres = new Stack<string>();
//    [SerializeField] private TMP_InputField inputNombre;  

//    void Start()
//    {
//        Debug.Log("Pila inicializada, pero vacía");
//    }


//    // Método para botón 1
//    public void PushString()
//    {

//        string nombre = inputNombre ? inputNombre.text.Trim() : string.Empty;

//        if (!string.IsNullOrEmpty(nombre))
//        {
//            pilanombres.Push(nombre);
//            MostrarMensaje($"Se agregó: {nombre}");
//            inputNombre.text = ""; // limpiar input
//        }
//        else
//        {
//            MostrarMensaje("⚠️ Ingresa un nombre antes de agregar.");
//        }
//        Debug.Log("El elemento del tope es:" + pilanombres.Peek());
//        RefrescarUI();
//    }

//}

//// Método para botón 2
//public void PeekString()
//    {
//        if (pilanombres.Count > 0)
//        {
//            Debug.Log("Elemento en el tope de la pila: " + pilanombres.Peek());
//        }
//        else
//        {
//            Debug.Log("La pila está vacía (Peek).");
//        }
//    }

//    // Método para botón 3
//    public void PopString()
//    {
//        if (pilanombres.Count > 0)
//        {
//            string eliminado = pilanombres.Pop();
//            Debug.Log("Se eliminó de la pila: " + eliminado);
//        }
//        else
//        {
//            Debug.Log("La pila está vacía (Pop).");
//        }
//    }
//}






