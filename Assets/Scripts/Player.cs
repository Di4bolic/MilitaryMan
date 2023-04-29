using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Rigidbody2D rb;

    private float speed = 30f;

    [SerializeField]
    private GameObject prefabBomb;

    public float range = 1;
    public bool shield = false;

    private bool isActivated = false;
    private float chronoShieldMax = 1f;
    private float chronoShield;

    // Start is called before the first frame update
    void Start()
    {
        chronoShield = chronoShieldMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Move(Vector2.up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector2.down);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Move(Vector2.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector2.right);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnBomb();
        }

        if (isActivated)
        {
            if (chronoShield > 0)
            {
                chronoShield -= Time.deltaTime;
            }
            else
            {
                shield = false;
            }
        }
    }

    private void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed, ForceMode2D.Force);
    }

    private void SpawnBomb()
    {
        var createdBomb = Instantiate(prefabBomb, new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y)), Quaternion.identity);
        createdBomb.GetComponent<Bomb>().range = range;
    }

    public void activateShield()
    {
        isActivated = true;
    }
}
