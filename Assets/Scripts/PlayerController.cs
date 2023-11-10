using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    public GameObject rocketPrefab;
    private GameObject tmpRocket;
    private Coroutine powerupCountdown;
    private float speed = 5f;
    private float forwardInput;
    private float powerUpStrength = 15f;
    public bool hasPowerup = false;

    public PowerUpType currentPowerUp = PowerUpType.none;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position - new Vector3(0, 0.5f, 0);

        if (currentPowerUp == PowerUpType.Rockets && Input.GetKeyDown(KeyCode.F)){
            LaunchRockets();
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("PowerUp")){
            hasPowerup = true;
            currentPowerUp = other.gameObject.GetComponent<PowerUp>().powerUpType;
            Destroy(other.gameObject);

            if (powerupCountdown != null){
                StopCoroutine(powerupCountdown);
            }
            powerupCountdown = StartCoroutine(PowerupCountdownRoutine());

            //StartCoroutine(StartPowerUpCountDown());
            //powerupIndicator.SetActive(true);       
        }
    }

    IEnumerator PowerupCountdownRoutine(){
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        currentPowerUp = PowerUpType.none;
        powerupIndicator.gameObject.SetActive(false);
    }

    IEnumerator StartPowerUpCountDown() {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);

    }

    void LaunchRockets(){
        foreach (var enemy in FindObjectsOfType<Enemy>()){
            tmpRocket = Instantiate(rocketPrefab, transform.position + Vector3.up, Quaternion.identity);
            tmpRocket.GetComponent<RocketBehaviour>().Fire(enemy.transform);
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy") && currentPowerUp == PowerUpType.PushBack) {
            Debug.Log("Have collieded with " + collision.gameObject.name + " and has powerup " + hasPowerup.ToString());
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log("player collided with :" + collision.gameObject.name + " with powerup set to " + currentPowerUp.ToString());
        }
        
    }
}
