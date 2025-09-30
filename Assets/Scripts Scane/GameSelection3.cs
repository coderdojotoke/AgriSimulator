using UnityEngine;
using UnityEngine.SceneManagement;
 
public class GameSelection3 : MonoBehaviour {
 
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Mowing grass");
    }
 
}


