using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] Transform prefabExplosion;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 5)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // Instanciamos la explosi�n.
            Transform explosion = Instantiate(prefabExplosion, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(explosion.gameObject, 1f);
            Destroy(gameObject);
        }
    }
}
