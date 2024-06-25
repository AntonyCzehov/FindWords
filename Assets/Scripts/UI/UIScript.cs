using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] SaveData saveData;

    [SerializeField] private GameObject tickerPrefab;

    private GameObject tickerPanel;
    private bool tickerPanelActive;
    

    [SerializeField] Cell cell;
    [SerializeField] private Sprite currentImage;
    [SerializeField] private Sprite[] backgroundImage;

    [SerializeField] private GameObject[] wordPanels;

    [SerializeField] private Vector2 cellSize;
    [SerializeField] private Vector2 bigCellSize;

    private bool findHelp;
    private int litterInLevel;
    private int litterEndLevel;
    public  List<int> foundWord;

    [SerializeField] private GameObject message;
    [SerializeField] private Text messageText;
    [SerializeField] private string[] messageVariants;

    [SerializeField] private Text moneyText;

    [SerializeField] private GameObject menu;
    public bool levelEnd;





    private void Update()
    {
        if (litterInLevel == litterEndLevel)
        {
            LevelEnd();

        }
        moneyText.text = "" + saveData.money;
    }
    public void MoveTicker(string litter)
    {
        int rand = Random.Range(0, backgroundImage.Length);
         
        
        if (tickerPanelActive == false && levelEnd == false)
        {
           tickerPanel = Instantiate(tickerPrefab, transform);
            tickerPanelActive = true;
        }

        cell.cellText.text = litter;
        cell.cellImage.sprite = backgroundImage[rand];

        Instantiate(cell, tickerPanel.transform);
    }

    public void ClearMoveTicker()
    {
        Destroy(tickerPanel);
        tickerPanelActive = false;

    }

    public void MoveWordPanel(int index, string word , bool newWord)
    {
        
        
        if (newWord == true)
        {
            for (int i = 0; i < word.Length; i++)
            {
                cell.cellText.text = "";
                cell.cellImage.sprite = currentImage;
                cell.litter = word[i].ToString();
                litterEndLevel++;
                Instantiate(cell, wordPanels[index].transform);
                

            }
        }
        else 
        {
            
            for (int i = 0; i < word.Length; i++)
            {
                Message(0);
                if (wordPanels[index].transform.GetChild(i).gameObject.GetComponent<Cell>().cellOpen != true)
                {
                    litterInLevel++;
                    StartCoroutine(PanelCellSize(index));


                    wordPanels[index].transform.GetChild(i).gameObject.GetComponent<Cell>().cellText.text = word[i].ToString();
                    wordPanels[index].transform.GetChild(i).gameObject.GetComponent<Cell>().cellImage.sprite = backgroundImage[Random.Range(0, backgroundImage.Length)];
                    wordPanels[index].transform.GetChild(i).gameObject.GetComponent<Cell>().cellOpen = true;
                }
            }

        }
    }

    public void Repeat(int index) 
    {
        Message(2);
        StartCoroutine(PanelCellSize(index));
    }

    public void HelpButton() 
    {
       
        for(int i = 0; i < wordPanels.Length;) 
        {
            for(int n = 0; n < wordPanels[i].transform.childCount; n ++)
            {
                if (wordPanels[i].transform.GetChild(n).gameObject.GetComponentInChildren<Cell>().cellOpen == false) 
                {
                    wordPanels[i].transform.GetChild(n).gameObject.GetComponentInChildren<Cell>().cellText.text = wordPanels[i].transform.GetChild(n).gameObject.GetComponentInChildren<Cell>().litter;
                    wordPanels[i].transform.GetChild(n).gameObject.GetComponentInChildren<Cell>().cellOpen = true;
                    findHelp = true;
                    litterInLevel++;
                    break;
                }
            }
            if(findHelp == true)
            {
                findHelp = false;
                break;
            }
            else
            {
                i++;
            }
        }
    }

    public void Advertising()
    {
       
    }

    public void Message(int i)
    {
        messageText.text = messageVariants[i];
        StartCoroutine(MessagePanel());
    }

    private void LevelEnd()
    {
        levelEnd = true;
        menu.SetActive(true);
        menu.GetComponent<Menu>().MoveLevelEnd();

        saveData.scene++;

        litterEndLevel++;
    }

    public IEnumerator MessagePanel()
    {
        message.SetActive(true);
        yield return new WaitForSeconds(2f);
        message.SetActive(false);

    }
    public IEnumerator PanelCellSize(int index) 
    {
        wordPanels[index].transform.GetComponent<GridLayoutGroup>().cellSize = bigCellSize;
        yield return new WaitForSeconds(0.5f);
        wordPanels[index].transform.GetComponent<GridLayoutGroup>().cellSize = cellSize;
    }
}
