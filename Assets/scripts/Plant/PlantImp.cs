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
    private Sprite m_wiltedSprite;
    private int m_daysToWilt;

    [HideInInspector] public int m_currentStage;

    private SpriteRenderer m_spriteRenderer;
    private bool m_isWatered = false;
    private int m_daysNotWatered;
    private delegate void m_endOfDayImp();
        public void Init(float _growthRate, List<StageData> _stages, int _daysToWilt = -1, Sprite _wiltedSprite = null)
        {
            m_daysToWilt = _daysToWilt;
            m_wiltedSprite = _wiltedSprite;
            if (m_spriteRenderer == null) {
                m_spriteRenderer = GetComponent<SpriteRenderer>();
            }

            m_growthRate = _growthRate;
            m_stages = _stages;
            m_daysToWilt = _daysToWilt;
            m_wiltedSprite = _wiltedSprite;

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
   
    /*

        sets up the current stage to zero, 
        then sets currentGrowth and lets the EndDay function advance it throught the stages.
        i the growth rate is out of range it ignores the call;

    
     */
    public void SetupGrowth(float _currentGrowth)
    {
        
        if(_currentGrowth <= 0 || _currentGrowth>100)
        {
            return;
        }
        m_isWatered = false;
        m_currentStage = 0;
        m_currentGrowth = _currentGrowth;
        EndDay();
        
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
    private void wilt() 
    {
        Debug.LogError("im wltingggg decayyyy");
        m_spriteRenderer.sprite = m_wiltedSprite;
    }
    public void EndDay()
    {
        Debug.LogError("EndDay Called");
        m_currentGrowth += m_dailyGrowth;

        //move the plant to the next stage if it passed its initial growth rate
        while ( (m_currentStage < m_stages.Count - 1) && (m_currentGrowth >= m_stages[m_currentStage + 1].m_startGrowthRate))
        {
            Debug.LogError("m_currentStage " + m_currentStage + "m_currentGrowth " + m_currentGrowth + "m_startGrowthRate " + m_stages[m_currentStage + 1].m_startGrowthRate);

            ++m_currentStage;
            m_spriteRenderer.sprite = m_stages[m_currentStage].m_sprite;
            Debug.LogError("changed sprite to "+m_stages[m_currentStage].m_sprite.name);
        }
        if (!m_isWatered)
        {
            m_daysNotWatered = 0;
        }
        else
        {
            Debug.LogError("m_daysToWilt = " + m_daysToWilt + " m_daysNotWatered = " + m_daysNotWatered);
            if (m_daysToWilt >= 0 && ++m_daysNotWatered >= m_daysToWilt)
            {
                wilt();
            }
        }
        m_isWatered = false;
        m_dailyGrowth = 0;
    }
}
