using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapGen : MonoBehaviour
{
    public GameObject block;
    public GameObject[] map = new GameObject[1000];
    int i = 0;
    int y = 0;
    int lr = 0;
    int length = 0;
    int check = 0;
    int timer = 0;
    float first = 1000;
    int t = 0;
    public float speed = 2;
    public System.Random rnd = new System.Random();
    public int play = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Leveler")
        {
            t += 1;
            play = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (play == 1)
        {
            if (timer >= 1)
                timer += 1;
            if (timer == first)
            {
                first = 500;
                if (t >= 100)
                    first = 100;
                if (t >= 120)
                    first = 500;
                timer = 0;
            }
            if (timer == 0)
            {
                if (check == 1)
                {
                    Destroy(map[length]);
                    timer = 1;
                }
                lr = rnd.Next(10);
                if (lr < 5)
                {
                    map[length] = Instantiate(block, new Vector3(i + 1, 2.66f, y), Quaternion.identity);
                    i++;
                }
                if (lr >= 5)
                {
                    map[length] = Instantiate(block, new Vector3(i, 2.66f, y + 1), Quaternion.identity);
                    y++;
                }
                length++;
                if (length == 500)
                {
                    timer = 1;
                    length = 0;
                    check = 1;
                }
            }
        }
    }
}