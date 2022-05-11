using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneChangeMemoryGameEnd : MonoBehaviour
{
    [SerializeField]
    private Image fadeOutImage;

    private Color32 originalColor;
    private Color32 fadedColor;

    //private GameManager gameManager;

    void Start()
    {
        //gameManager = FindObjectOfType<GameManager>();
    
        originalColor = fadeOutImage.color;        
        fadedColor = originalColor;
        fadedColor.a = 255;    
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeImageToNextScene());            
        }
    }
    public IEnumerator FadeImageToNextScene()
    {
        float elapsedTime = 0;
        float fadingTime = 2;

        while (elapsedTime < fadingTime)
        {
            fadeOutImage.color = Color32.Lerp(originalColor, fadedColor, elapsedTime / fadingTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
       
        SceneManager.LoadScene("LobbyScene");
    }

    public void PlayerWin()
    {
        //gameManager.MemorygameWin = true;
        StartCoroutine(FadeImageToNextScene());
    }

}
