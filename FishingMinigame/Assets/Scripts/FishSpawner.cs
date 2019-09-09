 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishSpawner : MonoBehaviour
{
    [Range(1,4096)]
    public int m_specialOdds = 4096;

    [Range(1,99)]
    public int m_fish02Odds = 5;

    [Space]
    public Sprite m_Fish01;
    public Sprite m_Fish02;
    public Sprite m_FishSpecial01;
    public Sprite m_FishSpecial02;

    private int m_fishOdds;
    private int m_specialSpawns;
    private FishingSimulator m_fishingSimulator;
    private ImageUpdater m_imageUpdater;

    // Start is called before the first frame update
    void Start()
    {
        m_imageUpdater = GameObject.Find("Image_FishSpawnPoint").GetComponent<ImageUpdater>();
        m_fishingSimulator = GameObject.Find("FishingSimulator").GetComponent<FishingSimulator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_fishingSimulator.Fishing())
        {
            CreateFish(m_fishingSimulator.m_specialRolls);
        }
    }

    public void CreateFish(int _rolls)
    {
        m_fishOdds = Random.Range(1, 100);

        if (m_fishOdds > m_fish02Odds)
        {
            if(specialRolls(_rolls))
            {
                //Spawn special Fish 1
                m_imageUpdater.ReflectImage(m_FishSpecial01);
            }
            else
            {
                //Spawn Fish 1
                m_imageUpdater.ReflectImage(m_Fish01);
            }

        }
        else
        {
            if (specialRolls(_rolls))
            {
                //Spawn special Fish 2
                m_imageUpdater.ReflectImage(m_FishSpecial02);
            }
            else
            {
                //Spawn Fish 2
                m_imageUpdater.ReflectImage(m_Fish02);
            }

        }
    }

    private bool specialRolls(int _rolls)
    {
        for (int i = 0; i < _rolls; i++)
        {
            m_specialSpawns = Random.Range(1, m_specialOdds);
            if (m_specialSpawns == 1)
            {
                return true;
            }
        }
        return false;
    }
}
