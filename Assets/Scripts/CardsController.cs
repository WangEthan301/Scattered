using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CardsController : MonoBehaviour
{
    [SerializeField] Card cardPrefab;
    [SerializeField] Transform gridTransform;
    [SerializeField] Sprite[] sprites;
    private List<Card> allCards = new List<Card>();


    public AudioClip matchCard; // The sound to play
    public AudioClip wrongCard;
    public AudioClip cardsFall;
    private AudioSource audioSource;

    private List<Sprite> spritePairs;

    Card firstSelected;
    Card secondSelected;

    int matchCounts;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PrepareSprites();
        CreateCards();
    }
    public void PrepareSprites()
    {
        spritePairs = new List<Sprite>();
        for (int i = 0; i < sprites.Length; i++)
        {
            spritePairs.Add(sprites[i]);
            spritePairs.Add(sprites[i]);
        }

        ShuffleSprites(spritePairs);
    }

    void CreateCards()
    {
        Debug.Log($"Creating {spritePairs.Count} cards (sprites length = {sprites.Length})");
        for (int i = 0; i < spritePairs.Count; i++)
        {
            Card card = Instantiate(cardPrefab, gridTransform);
            card.SetIconSprite(spritePairs[i]);
            card.controller = this;

            allCards.Add(card);
        }
    }

    public void SetSelected(Card card)
    {
        if (card.isSelected ==false)
        {
            card.show();

            if(firstSelected==null)
            {
                firstSelected = card;
                return;
            }

            if (secondSelected == null)
            {
                secondSelected = card;
                StartCoroutine(CheckMatching(firstSelected, secondSelected));
                firstSelected = null;
                secondSelected = null;
            }
        }
    }

    IEnumerator CheckMatching(Card a, Card b)
    {
        yield return new WaitForSeconds(0.5f);
        if(a.iconSprite == b.iconSprite)
        {
            matchCounts++;
            audioSource.PlayOneShot(matchCard);
            if (matchCounts >= spritePairs.Count / 2)
            {
                yield return new WaitForSeconds(1);
                audioSource.PlayOneShot(cardsFall);
                MakeCardsFall();

                StartCoroutine(LoadSceneAfterDelay(5f)); // waits 2 seconds
            }
        }
        else
        {
            a.hide();
            b.hide();
            audioSource.PlayOneShot(wrongCard);
        }
    }
    void ShuffleSprites(List<Sprite> spriteList)
    {
        for (int i = spriteList.Count -1; i>0;i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            Sprite temp = spriteList[i];
            spriteList[i] = spriteList[randomIndex];
            spriteList[randomIndex] = temp;
        }
    }

    void MakeCardsFall()
    {
        Debug.Log("All pairs matched — making cards fall!");

        // Find all card objects in the scene
        GameObject[] allCards = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject card in allCards)
        {
            // Add Rigidbody2D if not already there
            Rigidbody2D rb = card.GetComponent<Rigidbody2D>();
            if (rb == null)
                rb = card.AddComponent<Rigidbody2D>();

            // Basic fall settings
            rb.gravityScale = 10f;
            rb.mass = 3f;
            rb.linearDamping = 0.5f;
            rb.angularDamping = 1.0f;

            // Optional: random spin
            rb.angularVelocity = Random.Range(-180f, 180f);
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Scene 2D");
    }
}

