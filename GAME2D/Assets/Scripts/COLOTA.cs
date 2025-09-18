using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class COLOTA : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField inputNombre;
    [SerializeField] private TMP_InputField inputMail;
    [SerializeField] private TMP_InputField inputDireccion;
    [SerializeField] private TMP_Text txtLista;          
    [SerializeField] private TMP_Text txtMensaje;

    private readonly Queue<string> ColaTO = new Queue<string>();

    public void EnqueueDesdeInput()
    {
        string nombre = inputNombre ? inputNombre.text.Trim() : string.Empty;

        if (!string.IsNullOrEmpty(nombre))
        {
            ColaTO.Enqueue(nombre);
            inputNombre.text = "";
            MostrarMensaje($"Se ha agregado: {nombre}");
        }
        else
        {
            MostrarMensaje("Ingresa un nombre antes de agregar.");
        }

        RefrescarUI();
    }

    public void DequeueString()
    {
        if (ColaTO.Count > 0)
        {
            string eliminado = ColaTO.Dequeue();
            MostrarMensaje("Se ha quitado: {eliminado}");
        }
        else
        {
            MostrarMensaje(" La cola está vacía (Pop).");
        }

        RefrescarUI();
    }

    public void PeekString()
    {
        if (ColaTO.Count > 0)
        {
            string tope = ColaTO.Peek();
            MostrarMensaje($"El último elemento es: {tope}");
        }
        else
        {
            MostrarMensaje("La cola está vacía (Peek).");
        }

        RefrescarUI();
    }
    private void RefrescarUI()
    {
        if (txtLista)
        {
            if (ColaTO.Count > 0)
            {
                // Mostrar la cola en orden de llegada
                txtLista.text = "Cola:\n" + string.Join(" <- ", ColaTO);
            }
            else
            {
                txtLista.text = "Cola vacía";
            }
        }
    }
    public void ClearQueue()
    {
        ColaTO.Clear();
        MostrarMensaje("La Cola fue limpiada.");
        RefrescarUI();
    }
    // === Mostrar mensajes en el TMP_Text ===
    private void MostrarMensaje(string mensaje)
    {
        if (txtMensaje) txtMensaje.text = mensaje;
    }
}

        
    








