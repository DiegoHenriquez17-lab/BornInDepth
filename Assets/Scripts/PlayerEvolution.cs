using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class PlayerEvolution : MonoBehaviour
{
    [Header("Energía")]
    public int energiaActual = 0;
    public int energiaMax = 20;

    [Header("UI")]
    public TMP_Text txtEnergia;
    public Slider barraEnergia;

    [Header("Tutorial (mensaje de bienvenida)")]
    public TMP_Text txtInstruccion;             // puedes arrastrar o dejar vacío
    public string nombreTxtInstruccion = "TextoInstruccion"; // <- nombre en Hierarchy
    public float segundosMensaje = 4f;

    [Header("Sprites de evolución")]
    public Sprite spriteBase;
    public Sprite spriteEvol1;
    public Sprite spriteEvol2;
    private SpriteRenderer sr;
    private int nivelEvolucion = 0;

    [Header("Feedback")]
    public ParticleSystem fxEvolucion;
    public AudioSource sfxEvolucion;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (!txtInstruccion)  // <-- auto-link si quedó None
            txtInstruccion = GameObject.Find(nombreTxtInstruccion)?.GetComponent<TMP_Text>();

        if (sr && spriteBase) sr.sprite = spriteBase;
        ActualizarUI();
    }

    void Start()
    {
        if (txtInstruccion)
        {
            txtInstruccion.gameObject.SetActive(true);
            StartCoroutine(EsconderMensajeInicial());
        }
    }

    IEnumerator EsconderMensajeInicial()
    {
        yield return new WaitForSeconds(segundosMensaje);
        if (txtInstruccion) txtInstruccion.gameObject.SetActive(false);
    }

    public void GanarEnergia(int cantidad)
    {
        energiaActual = Mathf.Clamp(energiaActual + cantidad, 0, energiaMax);
        ActualizarUI();

        if (energiaActual >= energiaMax)
        {
            Evolucionar();
            energiaActual = 0;
            ActualizarUI();
        }
    }

    void Evolucionar()
    {
        nivelEvolucion++;

        if (nivelEvolucion == 1 && spriteEvol1) sr.sprite = spriteEvol1;
        else if (nivelEvolucion == 2 && spriteEvol2) sr.sprite = spriteEvol2;

        if (fxEvolucion) fxEvolucion.Play();
        if (sfxEvolucion) sfxEvolucion.Play();
    }

    void ActualizarUI()
    {
        if (txtEnergia) txtEnergia.text = $"Energía: {energiaActual} / {energiaMax}";
        if (barraEnergia)
        {
            barraEnergia.maxValue = energiaMax;
            barraEnergia.value = energiaActual;
        }
    }
}
