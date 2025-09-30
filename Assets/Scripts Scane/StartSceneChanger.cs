using UnityEngine;
using UnityEngine.SceneManagement;
 
public class StartSceneChanger : MonoBehaviour {
 
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("GameSelection");
    }
 
}

