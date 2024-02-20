using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float baseMaxSpeed;
    private float baseMoveSpeed;
    private float speedMultiplier = 1f;

    public int coinsCollectedSinceLastMultiply;
    public float movementSpeed;
    public float maxSpeed;
    public float turnSpeed;
    public int coins;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI finalCoinsText;
    public GameObject restartButton;
    public GameObject quitButton;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        baseMaxSpeed = maxSpeed;
        baseMoveSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0, 0, movementSpeed * Time.deltaTime), ForceMode.Acceleration);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3, 3), transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector3(-turnSpeed * Time.deltaTime, 0, 0), ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector3(turnSpeed * Time.deltaTime, 0, 0), ForceMode.Acceleration);
        }

        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        coinsText.text = ("Coins: " + coins);

        if(coinsCollectedSinceLastMultiply >= 10)
        {
            speedMultiplier += 0.2f;
            maxSpeed = baseMaxSpeed * speedMultiplier;
            movementSpeed = baseMoveSpeed * speedMultiplier;
            coinsCollectedSinceLastMultiply = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(coinsText);
        finalCoinsText.text = ("You collected " + coins + " coins.");
        finalCoinsText.gameObject.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
    }
}
