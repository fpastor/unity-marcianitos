using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Starship : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private Transform prefabShoot;
    public Text textLives;
    public Text textScore;
    public static int lives;
    public static int score;

    void Start()
    {
        lives = 3;
        score = 0;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -4.5)
            transform.position = new Vector3(-4.5f, transform.position.y, transform.position.z);
        if (transform.position.x > 4.5)
            transform.position = new Vector3(4.5f, transform.position.y, transform.position.z);

        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<AudioSource>().Play();
            Transform shoot = Instantiate(prefabShoot, transform.position, Quaternion.identity);
        }

        if (lives > 0)
        {
            textScore.text = "SCORE\n" + score.ToString().PadLeft(9, '0');
            textLives.text = "LIVES\n" + lives.ToString().PadLeft(3, '0');
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }

}
