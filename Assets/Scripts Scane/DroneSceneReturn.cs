using UnityEngine;
using UnityEngine.SceneManagement;
 
public class DroneSceneReturn : MonoBehaviour {
 
    public void OnClickStartButton()
    {
        CreateFloor.countField = 0;
        SceneManager.LoadScene("GameSelection");
    }
 
}

