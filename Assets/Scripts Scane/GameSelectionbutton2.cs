using UnityEngine;
using UnityEngine.SceneManagement;
 
public class GameSelectionbutton2 : MonoBehaviour {
 
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("drone");
    }
 
}

