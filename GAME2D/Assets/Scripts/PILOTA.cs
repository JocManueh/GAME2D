using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PilaTextures : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField inputNombre; // Campo de texto para ingresar nombres
    [SerializeField] private TMP_Text txtLista;          // Lista completa en forma de pila
    [SerializeField] private TMP_Text txtMensaje;        // Mensaje de estado (Push, Pop, Peek, Clear)

    private readonly Stack<string> pilanombres = new Stack<string>();

    // === PUSH ===
    public void PushDesdeInput()
    {
        string nombre = inputNombre ? inputNombre.text.Trim() : string.Empty;

        if (!string.IsNullOrEmpty(nombre))
        {
            pilanombres.Push(nombre);
            inputNombre.text = "";
            MostrarMensaje($"Se ha agregado: {nombre}");
        }
        else
        {
            MostrarMensaje("⚠️ Ingresa un nombre antes de agregar.");
        }

        RefrescarUI();
    }

    // === POP ===
    public void PopString()
    {
        if (pilanombres.Count > 0)
        {
            string eliminado = pilanombres.Pop();
            MostrarMensaje($"Se ha quitado: {eliminado}");
        }
        else
        {
            MostrarMensaje("⚠️ La pila está vacía (Pop).");
        }

        RefrescarUI();
    }

    // === PEEK ===
    public void PeekString()
    {
        if (pilanombres.Count > 0)
        {
            string tope = pilanombres.Peek();
            MostrarMensaje($"El último elemento es: {tope}");
        }
        else
        {
            MostrarMensaje("⚠️ La pila está vacía (Peek).");
        }

        RefrescarUI();
    }

    // === CLEAR ===
    public void ClearStack()
    {
        pilanombres.Clear();
        MostrarMensaje("La pila fue limpiada.");
        RefrescarUI();
    }

    // 
    private void RefrescarUI()
    {
        if (txtLista)
        {
            if (pilanombres.Count > 0)
            {
                // Mostrar como pila: el último agregado arriba
                txtLista.text = "Pila:\n" + string.Join("\n", pilanombres);
            }
            else
            {
                txtLista.text = "Pila vacía";
            }
        }
    }

    // === Mostrar mensajes en el TMP_Text ===
    private void MostrarMensaje(string mensaje)
    {
        if (txtMensaje) txtMensaje.text = mensaje;
    }
}
