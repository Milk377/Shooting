using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour  // PlayerControl 은 monobehaviour 기능을 사용한다!
{

	//플레이어 비행체의 이동 속도. 노출됨
	public float Speed = 100.0f;

	public GameObject BulletPrefab = null;

	//플레이어 게임 오브젝트의 트랜스폼 컴퍼넌트. 포지션,로테이션, 스케일
	private Transform myTransform = null;


	
	// Use this for initialization
	void Start ()  // Update가 호출되기전에 딱 한번만 호출됨. 
	{
		myTransform = GetComponent<Transform>();
		//myTransform = GetComponent("Transform") as Transform;
	}
	
	// Update is called once per frame
	void Update () { // Update는 초당 30프레임

		// Input Class 에서 "Horizontal" 을 가져오는 것!
		// Project Setting 에서 확인 가능함
		float axis = Input.GetAxis("Horizontal");
		//Debug.Log(axis);

		Vector3 moveAmount = axis * Speed * new Vector3(1,0,0) * Time.deltaTime;

		// Vector3.right = +x
		// Vector3.left = -x
		// Vector3.up = +y 
		// Vector3.down = -y
		// Vector3.forward = +z
		// Vector3.back = -z

		/*
		  
		* 첫번째 방식 - 현재 위치를 저장을 하고, 현재 위치에서 이동 거리만큼 추가해주는 방식을 사용
		
		* 현재의 위치에 이동 위치를 추가하는 방식으로써, 회전에 상관없이 원하는 방향으로 이동
		Vector3 moveAmount = axis * Speed * new Vector3(1,0,0) * Time.deltaTime;
		Vector3 tempTrans = myTransform.position;
		myTransform.position = tempTrans + moveAmount;
		
		*/

		// 두번쨰 방식은 회전을 고려해야함. 오브젝트가 틀어지지 않았다면 이동했을 방향으로 이동. 
		myTransform.Translate(moveAmount, Space.World);
		
		// Space.World 를 해주면 방향을 뒤집지 않아도 된다. 기준이 World 기준이므로.

		if(Input.GetKeyDown(KeyCode.Space) == true)
		{
			//Debug.Log("Space");
			Instantiate(BulletPrefab, myTransform.position, Quaternion.identity);

		}



	}
}
