using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    private Vector3 direction;
    public LayerMask groundMask;
    public GameObject TextGameOver;
    public int health = 100;

    public InterfaceController  interfaceController;
    private MovementPlayerController movementPlayer;
    public AnimatorController animatorController;

    public AudioClip audioHit;
    void Start()
    {
        Time.timeScale = 1;
        movementPlayer = GetComponent<MovementPlayerController>();
        animatorController = GetComponent<AnimatorController>();

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        direction = new Vector3(x, 0, z);
        

        animatorController.Moving(direction.magnitude);
        if(health == 0)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("game");
            }
        }
    }

    void FixedUpdate(){
        
        movementPlayer.Move(direction, speed);

        movementPlayer.RotatePlayer(groundMask);
    }

    public void ReceiveDamage(int damage){

        health = health-damage<0?0:health-damage;
        interfaceController.UpdateLife();
        SoundController.instance.PlayOneShot(audioHit);
        if(health == 0){
            TextGameOver.SetActive(true);
            Time.timeScale = 0;
        }
        

    }
}
