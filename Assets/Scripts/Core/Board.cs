using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] Transform m_emptySprite;
    [SerializeField] int m_height = 30;
    [SerializeField] int m_width = 30;

    // Start is called before the first frame update
    void Start()
    {
        DrawEmptyCells();
    }

    private void DrawEmptyCells()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
