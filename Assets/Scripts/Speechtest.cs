using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
public class Speechtest : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string,Action> actions = new Dictionary<string,Action>();
    private string lastRecognizedPhrase = "g+";
    // Start is called before the first frame update
    void Start()
    {
        actions.Add("g+", IncreaseGravity);
        actions.Add("g minus", DecreaseGravity);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log("You said: " + speech.text);
        if (speech.text != lastRecognizedPhrase && actions.ContainsKey(speech.text))
        {
            actions[speech.text].Invoke();
            lastRecognizedPhrase = speech.text;
        }
        else
        {
            Debug.LogWarning("Command not recognized or already executed: " + speech.text);
        }
    }
    private void IncreaseGravity()
    {
        transform.Rotate(0, 100, 0);
        Debug.Log("Gravity increased: ");
       
    }

    private void DecreaseGravity()
    {
        
        transform.Rotate(0, -100, 0);
        Debug.Log("Gravity decreased:");
    }
}
