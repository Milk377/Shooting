using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

	public float EnemySpeed = 50.0f;
	private Transform myTransform = null;
	public GameObject Explosion = null;

	void Start()
	{
		myTransform = GetComponent<Transform>();
	}

	void Update()
	{
		Vector3 moveAmount = EnemySpeed * Vector3.down * Time.deltaTime;
		myTransform.Translate(moveAmount, Space.World);

		if(myTransform.position.y < -50.0f)
		{
			myTransform.position = new Vector3(Random.Range(-60.0f,60.0f), 60.0f, 0f);

		}


	}

	/// <summary>
	/// 내 위치를 초기화 해 주는 함수
	/// </summary>
	/// <param name="a"></param>
	void InitPosition(int a)
	{
		if(a == 1)
		{
			myTransform.position = new Vector3(Random.Range(-60.0f, 60.0f), 60.0f, 0f);

		}
		else if( a == 2)
		{
			myTransform.position = new Vector3(0f, 60.0f, 0f);

		}
	}

	// 총알에 닿았다면
	//coll = 닿은 오브젝트, 
	private void OnTriggerEnter(Collider coll)
	{


		// coll.CompareTag("Bullet") 이런식도 가능

		if (coll.tag == "Bullet")
		{
			MainControl.Score += 100;
			Debug.Log("Bullet Hit from coll.tag");
			Instantiate(Explosion, myTransform.position, Quaternion.identity);
			InitPosition(1);
			Destroy(coll.gameObject);
		}
	}


}
