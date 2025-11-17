using UnityEngine;

public class CubeMoveDrone : MonoBehaviour
{
    //public float speed = 0.1f;
    //public float updownSpeed = 10.0f;
    public float rotationSpeed = 1.0f;
    public float verticalInput;
    public float horizontalInput;
    public float jumpInput;
    public float fieldINput = 0.5f;
    public GameObject projectilePrefab;
    public float xzRange = 10.0f;
    public float yRange = 4.0f;
    public AudioClip upSound;
    private AudioSource cubeAudio;
    public bool soundBool;
    public float speed = 0.1f;
    public float updownSpeed = 0.01f; 
    public float targetHeight = 4.0f;       // 上昇目標
    public float fallTargetHeight = 1.0f;   // 下降目標
    private bool isRising = false;
    private bool isFalling = false;

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundBool = false;
        cubeAudio = GetComponent<AudioSource>();
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
        //上
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            if (soundBool == false)
            {
                soundBool = true;
                cubeAudio = gameObject.AddComponent<AudioSource>();
                cubeAudio.clip = upSound;
                cubeAudio.loop = true; 
                cubeAudio.Play();
            }

            transform.Translate(Vector3.up * updownSpeed);
        }*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRising = true;
            isFalling = false;

            if (!soundBool)
            {
                soundBool = true;
                cubeAudio = gameObject.AddComponent<AudioSource>();
                cubeAudio.clip = upSound;
                cubeAudio.loop = true;
                cubeAudio.Play();
            }
        }

        //下
        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.Translate(Vector3.down * updownSpeed);
            soundBool = false;
            cubeAudio.Stop();
        }*/
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isFalling = true;
            isRising = false;

            soundBool = false;
            cubeAudio.Stop();
        }
        //追加
        if (isRising && transform.position.y < targetHeight)
        {
            float newY = Mathf.MoveTowards(transform.position.y, targetHeight, updownSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }

        // ゆっくり下降
        if (isFalling && transform.position.y > fallTargetHeight)
        {
            float newY = Mathf.MoveTowards(transform.position.y, fallTargetHeight, updownSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
　　　　　//追加終了

        //落とす
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xzRange)
        {
            transform.position = new Vector3(xzRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
        if (transform.position.z > xzRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, xzRange);
        }
         if (transform.position.y < 0.5)
        {
            transform.position = new Vector3(transform.position.x, 1,transform.position.z);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange,transform.position.z);
        }
 
    }
}
