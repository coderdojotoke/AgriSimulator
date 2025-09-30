using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public float speed = 0.1f;
    public float rotationSpeed = 1.0f;
    public float verticalInput;
    public float horizontalInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        //前後
        transform.Translate(Vector3.forward * speed * verticalInput);

        //左右
        transform.Rotate(Vector3.up, rotationSpeed * horizontalInput);

        if (transform.position.y < 0.5)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }

    }
     private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Foll")
        {
           transform.position = new Vector3(3.73f, 0.5f, 1.51f);
        }
    }
}
