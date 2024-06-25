using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Sprite currentImage;
    [SerializeField] private Sprite backgroundImage;

    public Text cellText;
    public Image cellImage;

    public bool cellOpen;
    public string litter;

    private void Start()
    {
        //cellText = transform.GetChild(1).GetComponent<Text>();
       // cellImage = transform.GetChild(0).GetComponent<Image>();
    }

   
}
