using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundControl : MonoBehaviour {

	public float ScrollSpeed = 0.1f;
	public Renderer myRender = null;

	// Use this for initialization
	void Start () {

		myRender = GetComponent<MeshRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {

		myRender.material.SetTextureOffset("_MainTex", new Vector2(0.0f, Time.time * ScrollSpeed));
		
	}
}
