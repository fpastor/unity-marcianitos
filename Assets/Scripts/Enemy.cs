using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform prefabEnemyShoot;
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

    IEnumerator Shoot()
    {
        float pause = Random.Range(5.0f, 11.0f);
        yield return new WaitForSeconds(pause);
        Transform shoot = Instantiate(prefabEnemyShoot, transform.position, Quaternion.identity);
        StartCoroutine(Shoot());
    }
}
