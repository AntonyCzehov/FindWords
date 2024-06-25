using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private SaveData SaveData;
    public UIScript uIScript;

    [SerializeField] private List<string> words;
    [SerializeField] private List<string> repeatWord;
    [SerializeField] private bool repeat;

    [SerializeField] private GameObject cursor;
    private GameObject thisCursor;

    public string word;
    public int maxLitters;

    private int levelEnd;
    private int levelNow;






    private void Start()
    {
        levelEnd = words.Count;
        for (int i = 0; i < words.Count; i++)
        {
            uIScript.MoveWordPanel(i, words[i], true);
        }


    }
    private void Update()
    {
        if(levelNow == levelEnd)
        {
            gameObject.SetActive(false);
        }
            
        if (Input.GetMouseButtonDown(0))
        {

            thisCursor = Instantiate(cursor);

        }
        if (Input.GetMouseButtonUp(0) || word.Count() > maxLitters)
        {
            Destroy(thisCursor);
            CheckWord();
            uIScript.ClearMoveTicker();
            word = "";
        }
    }
    public void GetLitter(string litter)
    {

        word += litter;
        uIScript.MoveTicker(litter);
    }

    private void CheckWord()
    {
        for(int n = 0; n < repeatWord.Count; n++) 
        {
            if (repeatWord[n] == word) 
            {
                repeat = true; 
                break;
            }
            else
            {
                repeat = false;
            }
            
        }

        for (int i = 0; i < words.Count; i++)

        {
            if (words[i] == word && repeat == false)
            {
                Reward(word);
                uIScript.MoveWordPanel(i, word, false);
                repeatWord.Add(word);
                levelNow++;
            }
            else if (words[i] == word && repeat == true)
            {
                uIScript.Repeat(i);
            }
            

        }
    }

    private void Reward(string word)
    {
        SaveData.litterCounter += word.Count();
        SaveData.money += word.Count();
        SaveData.wordCounter ++;
         
        for (int i = 0; i < word.Length; i++) 
        {
            SaveData.point += i;
        }
        
    }
}
