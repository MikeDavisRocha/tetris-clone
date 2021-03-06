﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] Transform m_emptySprite;
    [SerializeField] int m_height = 30;
    [SerializeField] int m_width = 10;
    [SerializeField] int m_header = 8;

    Transform[,] m_grid;

    private void Awake()
    {
        m_grid = new Transform[m_width, m_height];
    }

    // Start is called before the first frame update
    void Start()
    {
        DrawEmptyCells();
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    bool IsWithinBoard(int x, int y)
    {
        return (x >= 0 && x < m_width && y >= 0);
    }

    bool IsOccupied(int x, int y, Shape shape)
    {
        return (m_grid[x, y] != null && m_grid[x, y].parent != shape.transform);
    }

    public bool IsValidPosition(Shape shape)
    {
        foreach (Transform child in shape.transform)
        {
            Vector2 pos = Vectorf.Round(child.position);

            if (!IsWithinBoard((int) pos.x, (int) pos.y))
            {
                return false;
            }

            if (IsOccupied((int) pos.x, (int) pos.y, shape))
            {
                return false;
            }
        }
        return true;
    }

    void DrawEmptyCells()
    {
        for (int y = 0; y < m_height - m_header; y++)
        {
            for (int x = 0; x < m_width; x++)
            {
                Transform clone;
                clone = Instantiate(m_emptySprite, new Vector3(x, y, 0), Quaternion.identity) as Transform;
                clone.name = "Board Space ( x = " + x.ToString() + " , y =" + y.ToString() + " )";
                clone.transform.parent = transform;
            }
        }
    }

    public void StoreShapeInGrid(Shape shape)
    {
        if (shape == null)
        {
            return;
        }

        foreach (Transform child in shape.transform)
        {
            Vector2 pos = Vectorf.Round(child.position);
            m_grid[(int)pos.x, (int)pos.y] = child;
        }
    }
}
