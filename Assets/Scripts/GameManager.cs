using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // GameManager should be a singletion
    public static GameManager Instance { get; private set; }

    // System references
    [SerializeField] WallGenerator m_WallGenerator;
    [SerializeField] HealthManager m_HealthManager;
    [SerializeField] ScoreManager m_ScoreManager;

    // Gameplay relate information
    [SerializeField] GameObject StartLocationObj;
    [SerializeField] GameObject EndLocationObj;
    // If it is countdown mode, the end of the game will be judged based on the end of the countdown or the player's health value returning to zero.
    // If it is not countdown mode, then need to configure the total number of generated walls.
    [SerializeField] private bool IsCountDownMode = false;
    // How many walls will be generated in this game, the game will end when all walls are generated.
    [SerializeField] private int TotalNumberOfWalls = 0;
    // Target area
    [SerializeField] private GameObject TargetArea;

    [SerializeField] private int MaxHealth;
    [SerializeField] private int DamagePerTime;

    private int CurrentWallIndex = 0;

    private bool IsGameStart = false;

    [SerializeField] private float SpawnWallDelay = 0;

    private float CurrentTickDuration = 0;

    // Game timer
    // Delay before game start
    [SerializeField] float StartTime;
    // How long the game will end
    [SerializeField] float EndTime;
    [SerializeField] LevelTimer StartTimer;
    [SerializeField] LevelTimer GameTimer;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Init the game
        StartTimer.UpdateExplanation("Game Start in: ");
        StartTimer.SetMaxDuration(StartTime);
        StartTimer.SetCallback(StartGame);
        StartTimer.StartTimer();

        // Init Wall Generator
        m_WallGenerator.Init(TargetArea);

        // Init Health Manager
        m_HealthManager.Init(MaxHealth);

        // Init Score Manager
        m_ScoreManager.Init();
    }

    public void EndGame()
    {
        Debug.Log("Game End!");
        IsGameStart = false;
    }

    void StartGame()
    {
        Debug.Log("Game Start!");
        IsGameStart = true;
        CurrentTickDuration = 0;
        if (IsCountDownMode)
        {
            GameTimer.UpdateExplanation("Game End in: ");
            GameTimer.SetMaxDuration(EndTime);
            GameTimer.SetCallback(EndGame);
            GameTimer.StartTimer();
        }
        else 
        {
            CurrentWallIndex = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameStart)
        {
            CurrentTickDuration += Time.deltaTime;
            if (CurrentTickDuration >= SpawnWallDelay)
            {
                // Spawn a new wall
                m_WallGenerator.GenerateNewWall(StartLocationObj.transform.position, EndLocationObj.transform.position);
                CurrentTickDuration = 0;
                if (!IsCountDownMode)
                {
                    CurrentWallIndex++;
                    if (CurrentWallIndex >= TotalNumberOfWalls) 
                    {
                        EndGame();
                    }
                }
            }

        }
    }

    public void UpdateNewPerformance(E_PerformanceLevel i_NewLevel)
    {
        m_ScoreManager.UpdateScore(i_NewLevel);
        if (i_NewLevel == E_PerformanceLevel.Bad)
        {
            m_HealthManager.UpdateHealth(DamagePerTime);
        }
    }
}
