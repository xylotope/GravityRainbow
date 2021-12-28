using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour {

    public Transform target;
    public float speed = 1.0f;

    private GameState gameState;

	// Use this for initialization
	void Start () {
        gameState = GameState.Instance;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 difference = target.position - transform.position;
        difference.y = target.position.y < gameState.ballFloor + 16.0f ? 0.0f : difference.y;
        difference.z = 0.0f;
        difference *= speed;
        transform.position = transform.position + difference;
	}
}
