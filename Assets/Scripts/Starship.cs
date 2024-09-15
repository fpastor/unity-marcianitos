using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Starship : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private Transform prefabShoot;

    void Start()
    {
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<AudioSource>().Play();
            Transform shoot = Instantiate(prefabShoot, transform.position, Quaternion.identity);
        }
    }

}
