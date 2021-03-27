using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantImp : MonoBehaviour
{
    [System.Serializable]
    public class StageData
    {
        [SerializeField] public float m_startGrowthRate;
        [SerializeField] public Sprite m_sprite;
    }

    [HideInInspector] public float m_growthRate = 10f;
    [HideInInspector] public List<StageData> m_stages;

    [HideInInspector] public float m_dailyGrowth = 0f;
    [HideInInspector] [Range(0f, 100f)] public float m_currentGrowth = 0f;
    [HideInInspector] public int m_currentStage;

    private SpriteRenderer m_spriteRenderer;
    private bool m_isWatered = false;

    public void Init(float _growthRate, List<StageData> _stages)
    {
        if(m_spriteRenderer == null) {
            m_spriteRenderer = GetComponent<SpriteRenderer>();
        }

        m_growthRate = _growthRate;
        m_stages = _stages;

        if (m_stages.Count > 0)
        {
            m_currentStage = 0;
            m_spriteRenderer.sprite = m_stages[0].m_sprite;
        }
        else
        {
            Debug.LogError("no stages list is empty can't initialize sprite");
        }
    }

    public void WaterImp()
    {
        if (m_isWatered) {
            return;
        }

        Debug.Log("PlantImp::WaterImp: plant has been watered");
        m_dailyGrowth += m_growthRate;
        m_isWatered = true;
    }

    public void EndDay()
    {
        m_currentGrowth += m_dailyGrowth;

        //move the plant to the next stage if it passed its initial growth rate
        while ( (m_currentStage < m_stages.Count - 1) && (m_currentGrowth >= m_stages[m_currentStage + 1].m_startGrowthRate) )
        {
            ++m_currentStage;
            m_spriteRenderer.sprite = m_stages[m_currentStage].m_sprite;
        }

        m_isWatered = false;
        m_dailyGrowth = 0;
    }
}
