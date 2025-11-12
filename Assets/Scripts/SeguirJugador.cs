using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    // --- Variables Públicas ---
    public Transform objetivo; // La referencia al objeto a seguir (el jugador).
    public float distanciaZ = -10f; // Profundidad estándar para la cámara 2D.

    // LateUpdate se ejecuta después de que todos los Updates han terminado, 
    // asegurando que la cámara siga al jugador una vez que este ya se movió.
    void LateUpdate()
    {
        if (objetivo != null)
        {
            Vector3 nuevaPosicion = objetivo.position;
            nuevaPosicion.z = distanciaZ;
            transform.position = nuevaPosicion;
        }
    }
}