using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    private Vector3 direction;
    public LayerMask groundMask;
    public GameObject TextGameOver;
    public bool IsLive = true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        direction = new Vector3(x, 0, z);
        

        bool isMoving = direction != Vector3.zero;
        GetComponent<Animator>().SetBool("Moving", isMoving);
        if(!IsLive)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("game");
            }
        }
    }

    void FixedUpdate(){
        
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direction * Time.deltaTime * speed));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        RaycastHit rayHit;

        if(Physics.Raycast(ray, out rayHit, 100,groundMask))
        {
            Vector3 playerDirectionPosition = rayHit.point - transform.position;
            playerDirectionPosition.y = transform.position.y;

            Quaternion newRotation = Quaternion.LookRotation(playerDirectionPosition);
            GetComponent<Rigidbody>().MoveRotation(newRotation);

        }
    }
}
