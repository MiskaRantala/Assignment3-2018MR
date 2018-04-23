using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAwarder : MonoBehaviour {

    public float pointsAwarded = 0;


	public void Awake () {
        pointsAwarded = Random.Range(1, 100);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
