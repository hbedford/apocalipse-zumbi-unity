using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(x, 0, z);
        

        transform.Translate(direction* Time.deltaTime * speed );

        bool isMoving = direction != Vector3.zero;
        GetComponent<Animator>().SetBool("Moving", isMoving);
    }
}
