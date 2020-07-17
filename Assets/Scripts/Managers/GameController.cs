﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Board m_gameBoard;

    [SerializeField]
    Spawner m_spawner;

    [SerializeField]
    Shape m_activeShape;

    float m_dropInterval = 0.25f;

    float m_timeToDrop;

    // Start is called before the first frame update
    void Start()
    {
        m_gameBoard = GameObject.FindWithTag("Board").GetComponent<Board>();
        m_spawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();

        if (m_spawner)
        {
            if (m_activeShape == null)
            {
                m_activeShape = m_spawner.SpawnShape();
            }
            m_spawner.transform.position = Vectorf.Round(m_spawner.transform.position);
        }

        if (!m_gameBoard)
        {
            Debug.LogWarning("WARNING! There is no game board defined!");
        }

        if (!m_spawner)
        {
            Debug.LogWarning("WARNING! There is no spawner defined!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > m_timeToDrop)
        {
            m_timeToDrop = Time.time + m_dropInterval;
            if (m_activeShape)
            {
                m_activeShape.MoveDown();

                if (!m_gameBoard.IsValidPosition(m_activeShape))
                {
                    m_activeShape.MoveUp();
                    m_gameBoard.StoreShapeInGrid(m_activeShape);

                    if (m_spawner)
                    {
                        m_activeShape = m_spawner.SpawnShape();
                    }
                }
            }        
        }
    }
}
