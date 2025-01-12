using Assets.Scripts.Events;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; private set; }  // Singelton Instance
    public float InitialGameSpeed => _initialGameSpeed;  // Getter 
    public float GameSpeed => _gameSpeed;
    public float GameSpeedIncrease => _gameSpeedIncrease;

    [SerializeField] private float _initialGameSpeed = 5f; // Start Speed
    [SerializeField] private float _gameSpeed;
    [SerializeField] private float _gameSpeedIncrease = 0.2f;  // Increase Speed
    private PlayerMovement _player;
    private Spawner _spawner;
    [SerializeField] private GameObject _gameOverPanel;

    

    private void Awake()  // Singelton Algortim
    {
        //MethodBase.GetCurrentMethod().Name;    // Hangi metod olduðumuzu gösterir.
       
        Debug.LogWarning(MethodBase.GetCurrentMethod().Name);

        if (Instance)
        {
            Debug.LogWarning("Error");
           Destroy(Instance.gameObject);
            return;
        }
        Instance = this;

        //DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {

        _player = FindObjectOfType<PlayerMovement>();
        _spawner = FindObjectOfType<Spawner>();
        
     
        NewGame();
    }

    public void NewGame()
    {

        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        Time.timeScale = 1f;
        _gameSpeed = _initialGameSpeed;   // Start game speed = InitialGameSpeed

        _spawner.gameObject.SetActive(true);
        _player.gameObject.SetActive(true);
        _gameOverPanel.SetActive(false);

        ScoreManagerEvents.ScoreEventsDisable?.Invoke();
        
    }

    
    public void GameOver()
    {

        _gameSpeed = 0;
       
        
        //_spawner.gameObject.SetActive(false);
       Time.timeScale = 0f;
        _player.gameObject.SetActive(false);

        ScoreManagerEvents.ScoreEventsEnable?.Invoke();
       _gameOverPanel.SetActive(true);

     
    }

    private void OnEnable()
    {
        GameEvents.OnNewGame += NewGame;

        PlayerMovement.OnGameOver += GameOver;

        UIEvents.UIHandlerUpdate += NewGame;

        UIEvents.UIHandleIncrease += NewGame;

        
    }

    private void OnDisable()
    {
         GameEvents.OnNewGame -= NewGame;

        PlayerMovement.OnGameOver -= GameOver;

        UIEvents.UIHandlerUpdate -= NewGame;

        UIEvents.UIHandleIncrease -= NewGame;

       
    }

    private void IncreaseGameSpeed()
    {
        _gameSpeed += _gameSpeedIncrease * Time.deltaTime;  // Current Speed = Increase Speed

    }

    // Update is called once per frame
    void Update()
    {
        IncreaseGameSpeed();
    }


}
