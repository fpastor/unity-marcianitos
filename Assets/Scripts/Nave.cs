using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField] private float velocidad = 6;
    private float velocidadDisparo = 2;
    [SerializeField] private Transform prefabDisparo; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            Transform disparo = Instantiate(prefabDisparo, transform.position, Quaternion.identity);
            disparo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, velocidadDisparo, 0);
        }
    }

}
