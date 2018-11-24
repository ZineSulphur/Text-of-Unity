using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 10;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float vor = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(hor, vor) * Time.deltaTime * speed);
    }
}
