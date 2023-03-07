using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    public GameObject Button;
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    public string fullText2;
    private string currentText2 = "";
    


    void Start()
    {
        StartCoroutine(ShowText());
        Button.SetActive(false);
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
      
        
        yield return new WaitForSeconds(delay * 10);
        
        
        for (int i = 0; i <= fullText2.Length; i++)
        {
            currentText2 = fullText2.Substring(0, i);
            this.GetComponent<Text>().text = currentText2;
            yield return new WaitForSeconds(delay);
        }
        
        AudioSource.FindObjectOfType<AudioSource>().Pause();   
        yield return new WaitForSeconds(delay*10);
        Button.SetActive(true);
    }
}
