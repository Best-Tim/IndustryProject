using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
        
    public void LoadLevel(TextMeshProUGUI text)
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadTutorial(TextMeshProUGUI text)
    {
        SceneManager.LoadScene("Feature-tutorial");
    }
    public void ExitGame()
    {
        Application.Quit();
    }    
}
