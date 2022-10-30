using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour
{
    public Button btn;
    public Button btn2;
    public CharacterController controller;
    public float speed;
    public Vector3 md;
    public float gravity = -9.81f;
    Vector3 velocity;
    Vector3 turn = new Vector3(0, 0, -90);
    Quaternion rot = new Quaternion(0, 0, 0,0);
    public int i = 0;
    public Text play;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0 && speed < 5)
            speed += 0.0001f;
        btn.onClick.AddListener(Play);
        float x = Input.GetAxis("Horizontal");
        btn2.onClick.AddListener(Chdir);
        if (Input.GetKeyDown("space"))
            if (i == 1)
                i = 0;
            else if (i == 0)
                i = 1;
        if (i == 1)
            md = -transform.right;
        if (i == 0)
            md = transform.forward;
        controller.Move(md * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if (!controller.isGrounded)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }
    void Play()
    {
        speed = 3;
        play.gameObject.SetActive(false);
        btn2.gameObject.SetActive(true);
        btn.gameObject.SetActive(false);
    }
    void Chdir()
    {
        if (i == 1)
            i = 0;
        else if (i == 0)
            i = 1;
    }
}
