using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    

    private Vector3 cursorPos;
    public int speed;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPos.z = 0;
        transform.position = cursorPos;//Vector3.MoveTowards(transform.position, cursorPos, speed * Time.deltaTime);
    }

}
