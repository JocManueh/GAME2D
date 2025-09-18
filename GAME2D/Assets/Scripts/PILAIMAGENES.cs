//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;
//public class PilaImagenes : MonoBehaviour
//    {
//        [Header("Configuración")]
//        [SerializeField] private Image imagenPredeterminada; // Imagen que se usará en todos los Push

//        [Header("UI")]
//        [SerializeField] private Image imgPreview;   // Muestra el último elemento (Peek)
//        [SerializeField] private TMP_Text txtMensaje; // Mensajes de estado

//        private readonly Stack<Image> pilaImagenes = new Stack<Image>();

//        // === PUSH ===
//        public void PushImagen()
//        {
//            if (imagenPredeterminada != null)
//            {
//                pilaImagenes.Push(imagenPredeterminada);
//                MostrarMensaje("Se ha agregado una imagen a la pila.");
//            }
//            else
//            {
//                MostrarMensaje("No se asignó ninguna imagen predeterminada.");
//            }

//            RefrescarUI();
//        }

//        // === POP ===
//        public void PopImagen()
//        {
//            if (pilaImagenes.Count > 0)
//            {
//                pilaImagenes.Pop();
//                MostrarMensaje("Se quitó la última imagen de la pila.");
//            }
//            else
//            {
//                MostrarMensaje("La pila está vacía (Pop).");
//            }

//            RefrescarUI();
//        }

//        // === PEEK ===
//        public void PeekImagen()
//        {
//            if (pilaImagenes.Count > 0)
//            {
//                pilaImagenes.Peek();
//                MostrarMensaje("El último elemento es una imagen.");
//            }
//            else
//            {
//                MostrarMensaje("La pila está vacía (Peek).");
//            }
//        }

//        // === CLEAR ===
//        public void ClearStack()
//        {
//            pilaImagenes.Clear();
//            MostrarMensaje("La pila fue limpiada.");
//            RefrescarUI();
//        }

//        // === Actualiza la vista del Preview ===
//        private void RefrescarUI()
//        {
//            if (imgPreview)
//            {
//                if (pilaImagenes.Count > 0)
//                    imgPreview.sprite = pilaImagenes.Peek();
//                else
//                    imgPreview.sprite = null; // vacío
//            }
//        }

//        private void MostrarMensaje(string mensaje)
//        {
//            if (txtMensaje) txtMensaje.text = mensaje;
//            Debug.Log(mensaje); // opcional
//        }
//    }