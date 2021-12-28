using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityShape : MonoBehaviour {

    public static float G = 68.0f;

    public GameObject tapAnimator;
    public AudioClip tapSound;
    public float strength = 1.0f;
    public float mass = 1.0f;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTap()
    {
        GameObject ball = GameState.Instance.ball;
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        Vector2 diff = ball.transform.position - transform.position;
        //  F = Gm1m2/r2
        Vector2 force = (G * rb.mass * mass) / Vector2.Distance(ball.transform.position, transform.position) * Vector2.ClampMagnitude(diff, 1.0f);
        rb.AddForce(force * strength);
        tapAnimator.GetComponent<Animation>().Play();
        audioSource.Play();
    }
}
