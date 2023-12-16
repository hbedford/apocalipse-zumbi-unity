
using System.Collections;
using UnityEngine;

public class ZombieController : MonoBehaviour, IHit
{

    public GameObject Player;
    private MovementController movementController;
    private AnimatorController animator;
    private StatusController statusController;
    bool isAttacking = false;
    public AudioClip AudioKill;
    private Vector3 randomPosition;
    private float counterRandomPosition = 0;
    private float  timeToRandomPosition = 5;
    private float percentagemGenerateMedicKit = 0.1f;
    public GameObject medicKit;
    private InterfaceController interfaceController;
    public GenerateZombieController myGenerate;


    Vector3 direction;
void Start()
    {
        Player = GameObject.FindWithTag("Player");
        RandomZumbie();
        movementController = GetComponent<MovementController>();
        animator = GetComponent<AnimatorController>();
        statusController = GetComponent<StatusController>();
        interfaceController = GameObject.FindObjectOfType(typeof(InterfaceController)) as InterfaceController;

    }


    void FixedUpdate(){

        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance > 10)
        {
            Walking();
            return;
        }

        if (distance >2.5 && distance <10 ){
            direction = Player.transform.position - transform.position;

            movementController.Move(direction, statusController.Speed);
            movementController.Rotate(direction);
            
            
            animator.Attack(false);
            isAttacking = false;


        }
        if(distance < 2.5)
        {
            animator.Attack(true);
            if (isAttacking) return;
            isAttacking = true;
            Invoke("AttackPlayer", 1);
        }
    }


     void AttackPlayer()
    {
        if (!isAttacking) return;
        Player.GetComponent<PlayerController>().Hit(10);

    }

    void RandomZumbie()
    {
        int randomType = Random.Range(1, 28);
        transform.GetChild(randomType).gameObject.SetActive(true);
    }

    public void Hit(int damage)
    {
        Die();
        SoundController.instance.PlayOneShot(AudioKill);
    }

    public void Die()
    {

        Destroy(gameObject);
        verifyGenerateMedicKit(percentagemGenerateMedicKit);
        interfaceController.UpdateAmountZombiesKilled();
        myGenerate.ZombieDie();
    }

    void verifyGenerateMedicKit(float percentage)
    {
        float random = Random.Range(0, 1.0f);
        if (random <= percentage)
        {
            Instantiate(medicKit, transform.position, Quaternion.identity);
        }
    }

    Vector3 RandomPosition()
    {
        Vector3 position = Random.insideUnitSphere * 10;

        position  += transform.position;
        position.y = 0;
        return position;

    }

    void Walking()
    {

        counterRandomPosition -= Time.deltaTime;

        if (counterRandomPosition <= 0)
        {
            randomPosition = RandomPosition();
            counterRandomPosition += timeToRandomPosition + Random.Range(-2f,2f);

           
        }

        bool ficouPertoOSuficiente = Vector3.Distance(transform.position, randomPosition) <= 0.5;

        if (ficouPertoOSuficiente == false)
        {
            direction = randomPosition - transform.position;
            movementController.Move(direction, statusController.Speed);
            movementController.Rotate(direction);
            

        }
    }
}

