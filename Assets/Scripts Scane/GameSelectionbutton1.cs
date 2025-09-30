using UnityEngine;
using UnityEngine.SceneManagement;
 
public class GameSelectionbutton1 : MonoBehaviour {
 
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("SunlightSimulator");
    }
 
}

