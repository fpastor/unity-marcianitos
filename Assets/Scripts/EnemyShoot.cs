using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Transform prefabExplosion;
    private float velocidadDisparo = -5;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, velocidadDisparo, 0);
    }

    void Update()
    {
        if (transform.position.y < -5)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Starship")
        {
            Transform explosion = Instantiate(prefabExplosion, other.transform.position, Quaternion.identity);
            if (Starship.lives > 0)
            {
                Starship.lives -= 1;
                other.transform.SetPositionAndRotation(new Vector3(0, -2.5f, 0), Quaternion.identity);
            }
            Destroy(explosion.gameObject, 1f);
            Destroy(gameObject);
        }
    }
}
