using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonFunctions : MonoBehaviour
{
    [SerializeField] InputField playerNameInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Instructions()
    {
        SceneManager.LoadScene("instructions");
    }

     public void PlayGame()
    {
        string s = playerNameInput.text;
        PersistenceData.Instance.SetName(s);
        SceneManager.LoadScene("level1");

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void setting()
    {
        SceneManager.LoadScene("settings");
    }
}
