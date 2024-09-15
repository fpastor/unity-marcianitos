using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform prefabEnemyShoot;
    [SerializeField] private Transform prefabExplosion;
    private float velocidadX = 2;
    private float velocidadY = -1.1f;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        transform.Translate(velocidadX * Time.deltaTime,velocidadY * Time.deltaTime, 0);

        if ((transform.position.x < -4) || (transform.position.x > 4))
            velocidadX = -velocidadX;
        if ((transform.position.y < -2.5) || (transform.position.y > 2.5))
            velocidadY = -velocidadY;

        if (Input.GetButtonDown("Fire2"))
        {
            //GetComponent<AudioSource>().Play();
            Transform shoot = Instantiate(prefabEnemyShoot, transform.position, Quaternion.identity);
        }
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

    IEnumerator Shoot()
    {
        float pause = Random.Range(3.0f, 30.0f);
        yield return new WaitForSeconds(pause);
        Transform shoot = Instantiate(prefabEnemyShoot, transform.position, Quaternion.identity);
        StartCoroutine(Shoot());
    }
}
