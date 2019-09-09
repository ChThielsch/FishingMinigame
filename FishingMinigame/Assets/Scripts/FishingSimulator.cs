using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSimulator : MonoBehaviour
{

    private float m_fishSpawn;
    private float m_currentFishingTime;
    private float m_newFishingTime;
    private bool m_rodOut;
    private int m_score = 0;

    [HideInInspector]
    public int m_specialRolls = 0;

    private TextUpdater m_scoreUpdater;
    private TextUpdater m_speechbubbleUpdater;
    private ImageUpdater m_fishUpdater;
    private ImageUpdater m_fishermanUpdater;

    [Range(1, 10)]
    [Tooltip("The maximum time (in seconds) it can take for a fish to spawn")]
    public float m_maxFishSpawnTime = 10f;
    [Range(1, 10)]
    [Tooltip("The minimum time (in seconds) it can take for a fish to spawn")]
    public float m_minFishSpawn = 2f;
    [Range(1, 5)]
    [Tooltip("The time (in seconds) that the player got to catch the fish")]
    public float m_defaultFishingTime = 5f;

    [Space]
    public Sprite m_normalFisherman;
    public Sprite m_pulledInFisherman;
    public Sprite m_pulledOutFisherman;


    private void OnValidate()
    {
        if (m_maxFishSpawnTime <= m_minFishSpawn)
        {
            Debug.LogError("maxFishSpawn is smaller or equal to minFishSpawn and was reset to default");
            m_maxFishSpawnTime = 10f;
            m_minFishSpawn = 2f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_newFishingTime = m_defaultFishingTime;
        m_scoreUpdater = GameObject.Find("Text_Score").GetComponent<TextUpdater>();
        m_speechbubbleUpdater = GameObject.Find("Text_Speechbubble").GetComponent<TextUpdater>();
        m_fishUpdater = GameObject.Find("Image_FishSpawnPoint").GetComponent<ImageUpdater>();
        m_fishermanUpdater = GameObject.Find("Image_Fisherman").GetComponent<ImageUpdater>();
    }

    // Late or its too early for FishSpawner
    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump") && m_rodOut == false)
        {
            m_speechbubbleUpdater.ReflectText(". . .");
            m_fishSpawn = Random.Range(m_minFishSpawn, m_maxFishSpawnTime);
            m_currentFishingTime = m_newFishingTime;
            m_fishermanUpdater.ReflectImage(m_normalFisherman, new Vector2(100, 100));
            m_fishUpdater.ResetImage();
            m_rodOut = true;
        }

        if (m_rodOut == true)
        {
            Fishing();
        }



    }
    public bool Fishing()
    {
        if (m_fishSpawn > 0.0f)
        {
            m_fishSpawn -= Time.deltaTime;

            if (Input.GetButtonDown("Fire1")) //pull rod back in
            {
                m_rodOut = false;
                m_newFishingTime = m_defaultFishingTime;
                m_score = 0;
                m_specialRolls = 1;
                m_scoreUpdater.ReflectText("Score: " + m_score);
                m_speechbubbleUpdater.ReflectText("Too early!");
                m_fishermanUpdater.ReflectImage(m_pulledOutFisherman, new Vector2(100, 100));

            }
            return false;
        }
        else if (m_fishSpawn <= 0.0f && m_rodOut)
        {
            m_fishSpawn = 0.0f;
            m_speechbubbleUpdater.ReflectText("! ! !");
            m_fishermanUpdater.ReflectImage(m_pulledInFisherman, new Vector2(100, 100));

            if (Input.GetButtonDown("Fire1")) //pull rod back in
            {
                m_rodOut = false;
                if (m_currentFishingTime > 0)
                {
                    m_newFishingTime--;
                    m_score++;
                    if (m_score % 10 == 0) //everytime m_score is 10 more  
                    {
                        m_specialRolls++;                    
                    }
                    m_currentFishingTime = Mathf.Clamp(m_currentFishingTime, 0.15f, m_defaultFishingTime);
                    m_specialRolls = Mathf.Clamp(m_specialRolls, 1, 6);
                    m_speechbubbleUpdater.ReflectText("Got 'em!");
                    m_scoreUpdater.ReflectText("Score: " + m_score);
                    m_fishermanUpdater.ReflectImage(m_pulledOutFisherman, new Vector2(100,100));

                    return true;
                }
                else
                {
                    m_newFishingTime = m_defaultFishingTime;
                    m_score = 0;
                    m_specialRolls = 1;
                    m_scoreUpdater.ReflectText("Score: " + m_score);
                    m_speechbubbleUpdater.ReflectText("Got away...");
                    m_fishermanUpdater.ReflectImage(m_pulledOutFisherman, new Vector2(100, 100));

                    return false;
                }
            }
            m_currentFishingTime -= Time.deltaTime;
            return false;
        }
        else
        {
            m_newFishingTime = m_defaultFishingTime;
            return false;
        }
    }
}
