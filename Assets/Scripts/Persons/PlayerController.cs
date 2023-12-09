using UnityEngine;

public class PlayerController : MonoBehaviour, IHit
{
    private Vector3 direction;
    public LayerMask groundMask;
    public GameObject TextGameOver;
    public InterfaceController  interfaceController;
    private MovementPlayerController movementPlayer;
    public AnimatorController animatorController;
    public StatusController statusController;

    public AudioClip audioHit;
    void Start()
    {
        Time.timeScale = 1;
        movementPlayer = GetComponent<MovementPlayerController>();
        animatorController = GetComponent<AnimatorController>();
        statusController = GetComponent<StatusController>();

    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        direction = new Vector3(x, 0, z);
        

        animatorController.Moving(direction.magnitude);
        if(statusController.Health == 0)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("game");
            }
        }
    }

    void FixedUpdate(){
        
        movementPlayer.Move(direction, statusController.Speed);

        movementPlayer.RotatePlayer(groundMask);
    }

   

    public void Hit(int damage)
    {
        statusController.LoseHealth(damage);
        interfaceController.UpdateLife();
        SoundController.instance.PlayOneShot(audioHit);
        if (statusController.Health == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        TextGameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
