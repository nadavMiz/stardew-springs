using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPlant : MonoBehaviour, Ipickable
{
    public float m_growthRate = 10f;
    [SerializeField] public List<PlantImp.StageData> m_stages;
    public ItemMetadata m_fruit;
    private PlantImp m_plantImp;
    private SpriteRenderer m_spriteRenderer;

    private void Awake()
    {
        m_plantImp = GetComponent<PlantImp>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_plantImp.Init(m_growthRate, m_stages);
    }
    private void Start()
    {

        EventManager.Subscribe(TimeEvent.END_OF_DAY, m_plantImp.EndDay);
    }

    public ItemMetadata pick()
    {
        //don't do enything if not at the latest stage
        if (m_plantImp.m_currentStage != m_plantImp.m_stages.Count - 1) {
            return null;
        }

        int previousStage = m_plantImp.m_currentStage - 1;
        Debug.Log(m_plantImp.m_stages[previousStage].m_sprite);
        m_plantImp.m_currentGrowth = m_plantImp.m_stages[previousStage].m_startGrowthRate;
        m_spriteRenderer.sprite = m_plantImp.m_stages[previousStage].m_sprite;
        m_plantImp.m_currentStage = previousStage;
        return m_fruit;
    }

    public void Water()
    {
        m_plantImp.WaterImp();
    }
}
