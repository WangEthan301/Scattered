using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    [SerializeField] private Image iconIage;
    public AudioClip flipCard; // The sound to play
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public Sprite hiddenIconSprite;
    public Sprite iconSprite;

    public bool isSelected;
    public CardsController controller;

    public void OnCardClick()
    {
        controller.SetSelected(this);
        audioSource.PlayOneShot(flipCard);
    }

    public void SetIconSprite(Sprite sp)
    {
        iconSprite = sp;
    }


    public void show()
    {
        iconIage.sprite = iconSprite;
        isSelected = true;
    }

    public void hide()
    {
        iconIage.sprite = hiddenIconSprite;
        isSelected = false;
    }

}
