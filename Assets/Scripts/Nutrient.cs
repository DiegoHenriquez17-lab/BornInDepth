using UnityEngine;

public class Nutrient : MonoBehaviour
{
    public int valor = 1; // Energía que aporta el nutriente

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerEvolution player = other.GetComponent<PlayerEvolution>();
        if (player != null)
        {
            player.GanarEnergia(valor);
            Destroy(gameObject); // El nutriente desaparece
        }
    }
}
