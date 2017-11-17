﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockRunner : MonoBehaviour
{
	public GameObject prefab;

	GameObject[] birds;
	Boid[] boids;


	public int count = 200;

	void Start ()
	{
		boids = new Boid[count];
		birds = new GameObject[count];


		for (var i = 0; i < count; i++) {
			var boid = boids [i] = new Boid ();

			boid.setRandomPosition ();
			boid.setRandomVelocity ();
			boid.setAvoidWalls (true);
			boid.setWorldSize (500, 500, 400);

			var bird = birds [i] = GameObject.Instantiate (prefab);
		}
	}

	void Update ()
	{
		for (int i = 0; i < birds.Length; i++) {
			var boid = boids [i];
			var bird = birds [i];
			boid.run (boids);
			bird.transform.position = boid.position;
		}
	}
	 
}
