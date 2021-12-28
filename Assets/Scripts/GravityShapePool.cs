using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityShapePool : MonoBehaviour {

    #region Singleton
    public static GravityShapePool Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }
    #endregion Singleton

    public GameObject prefab;
    public int count = 1;

    private Queue<GameObject> pool;

	// Use this for initialization
	void Start () {
        pool = new Queue<GameObject>();
        for(int i=0; i<count; i++)
        {
            GameObject c = Instantiate(prefab);
            c.SetActive(false);
            pool.Enqueue(c);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject Spawn()
    {
        GameObject c = pool.Dequeue();
        c.SetActive(true);
        pool.Enqueue(c);
        return c;
    }
}
