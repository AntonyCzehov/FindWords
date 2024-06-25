using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Litter : MonoBehaviour
{
    [SerializeField] private InputManager InputManager;

    [SerializeField] private string _litter;

    private void Start()
    {
        InputManager = transform.GetComponentInParent<InputManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<Cursor>() != null) 
        {
            InputManager.GetLitter(_litter);
        }
    }
}
