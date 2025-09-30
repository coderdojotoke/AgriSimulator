using UnityEngine;

public class NotDown : MonoBehaviour
{
    public float yRange = 0.35f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < yRange)
        {
            transform.position = new Vector3(transform.position.x,yRange,transform.position.z);
        }
    }
}