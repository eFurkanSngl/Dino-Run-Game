using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    private void Awake()
    {
        int UnLockedLevel = PlayerPrefs.GetInt("UnLockedLevel", 4);

        for(int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = false;
        }
        for(int i = 0; i < UnLockedLevel; i++)
        {
            _buttons[i].interactable = true;
        }
    }
    public void OpenLevel(int levelId)
   {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
   }
}
