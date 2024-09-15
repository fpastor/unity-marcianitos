using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Starship prefavStarship;
    [SerializeField] private Transform prefabExplosion;
    private float velocidadDisparo = 5;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, velocidadDisparo, 0);
    }

    void Update()
    {
        if (transform.position.y > 5)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Transform explosion = Instantiate(prefabExplosion, other.transform.position, Quaternion.identity);
            Starship.score += 10;
            Destroy(other.gameObject);
            Destroy(explosion.gameObject, 1f);
            Destroy(gameObject);
        }
    }
}
