using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int level = 1;
    const int DEFAULT_POINTS = 1;
    [SerializeField] Text scoreTxt;
    [SerializeField] Text levelTxt;
    [SerializeField] Text nameTxt;
    

    // Start is called before the first frame update
    void Start()
    {
        score = PersistenceData.Instance.GetScore();
        level = SceneManager.GetActiveScene().buildIndex;
        DisplayScore();
        DisplayLevel();
        DisplayName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(){
        UpdateScore(DEFAULT_POINTS);
    }

    public void UpdateScore(int addend){
        score += addend;
        //display score
        DisplayScore();
        PersistenceData.Instance.SetScore(score);
    }

    public void DisplayScore(){
        scoreTxt.text = "Score: " + score;
    }

    public void DisplayLevel()
    {
        int levelToDisplay = level;
        levelTxt.text = "Level: " + levelToDisplay;
    }

    public void DisplayName()
    {
        nameTxt.text = "Hi, " + PersistenceData.Instance.GetName();
    }
}
