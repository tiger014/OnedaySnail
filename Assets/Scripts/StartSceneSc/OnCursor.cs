using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private AudioSource audioSource;
    public AudioClip OnCursorSE;
    public float nottime;
    public bool cursorstay;

    void Update()
    {
        audioSource.GetComponent<AudioSource>();
        nottime += 0.03f;

        if (nottime >= 1.0f)
        {
            cursorstay = true;

            nottime = 1.0f;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)  //èdÇ»Ç¡ÇΩÇ∆Ç´
    {
        if (cursorstay == true)
        {
            //Debug.Log("èdÇ»Ç¡ÇΩÇ∫");
            audioSource.PlayOneShot(OnCursorSE);
        }
    }

    public void OnPointerExit(PointerEventData eventData)   //ó£ÇÍÇΩÇ∆Ç´
    {
        if (cursorstay == true)
        {
            //Debug.Log("ó£ÇÍó£ÇÍÇæÇ∫");
            nottime = 0.0f;
            cursorstay = false;
        }
    }
}
