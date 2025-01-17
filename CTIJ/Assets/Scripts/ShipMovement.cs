using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed = 2;

    //private SpriteRenderer shipSprite;

    // Start is called before the first frame update
    void Start()
    {
        //shipSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //shipSprite.sprite = 
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag == "Boundary")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y-1, transform.position.z);
            moveSpeed *= -1;
        }
    }
}
