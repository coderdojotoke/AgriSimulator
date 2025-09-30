using UnityEngine;
using UnityEngine.SceneManagement;
 
public class GrassSceneReturn : MonoBehaviour {
 
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("GameSelection");
    }
 
}
