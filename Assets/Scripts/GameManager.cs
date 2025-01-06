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
    private Ground _ground;
    private ScoreManager _scoreManager;
    private RetyButton _retyButton;
   
    private void Awake()  // Singelton Algortim
    {
        //MethodBase.GetCurrentMethod().Name;    // Hangi metod olduðumuzu gösterir.
       
        Debug.LogWarning(MethodBase.GetCurrentMethod().Name);

       _player = FindObjectOfType<PlayerMovement>();
        _spawner = FindObjectOfType<Spawner>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        _retyButton = FindObjectOfType<RetyButton>();


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
        NewGame();
    }

    private void NewGame()
    {
        
        _gameSpeed = _initialGameSpeed;   // Start game speed = InitialGameSpeed

        _spawner.gameObject.SetActive(true);
        _player.gameObject.SetActive(true);

        _player.transform.position = new Vector2(x: -15, y: -5.1f);

        _scoreManager._gameOverPanel.gameObject.SetActive( false);
        _retyButton.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        Obstacle[] _obstacle = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in _obstacle)
        {
            Destroy(obstacle);

        }

        _gameSpeed = 0;
        _gameSpeedIncrease = 0;

        _spawner.gameObject.SetActive(false);
        _player.gameObject.SetActive(false);

        _scoreManager._gameOverPanel.gameObject.SetActive(true);
        _retyButton.gameObject.SetActive(true);

    }

    private void OnEnable()
    {
        GameEvents.OnNewGame += NewGame;
        PlayerMovement.OnGameOver += GameOver;
        UIEvents.UIHandler += NewGame;
    }

    private void OnDisable()
    {
        PlayerMovement.OnGameOver -= GameOver;
        UIEvents.UIHandler -= NewGame;
        GameEvents.OnNewGame -= NewGame;
    }



    // Update is called once per frame
    void Update()
    {
        _gameSpeed += _gameSpeedIncrease * Time.deltaTime;  // Current Speed = Increase Speed
    }


}
