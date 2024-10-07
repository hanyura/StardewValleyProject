using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBirdMove : MonoBehaviour
{
    public GameObject clouds;
    public GameObject bird_L;
    public GameObject bird_R;
    private float cloudspeed = 0.01f;
    private float birdspeed = 0.1f;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        clouds.transform.Translate(Vector2.left * cloudspeed * Time.deltaTime);
        bird_L.transform.Translate(Vector2.left * birdspeed * Time.deltaTime);
        bird_R.transform.Translate(Vector2.left * birdspeed * Time.deltaTime);
    }
}
