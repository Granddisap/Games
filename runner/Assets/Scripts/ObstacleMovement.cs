using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
	public float force = 500f;
	// Скорость столкновения (X - угловой множитель)
	public Vector3 collisionVelocity = new Vector3(25f, 5f, 10f);

	private void OnCollisionEnter(Collision collision)
	{
		switch (collision.gameObject.tag)
		{
			case "Player":
				// Бросьте препятствие в воздух для драматического эффекта
				Rigidbody obstacle = GetComponent<Rigidbody>();
				obstacle.velocity = new Vector3(obstacle.velocity.x,
				                                collisionVelocity.y,
				                                collisionVelocity.z);
				obstacle.angularVelocity = obstacle.angularVelocity * collisionVelocity.x;

				FindObjectOfType<GameManager>().InitiateDeath();

				break;
			case "ObstacleWall":
				Destroy(gameObject);

				break;
		}
	}

	private void Update()
	{
		// Переместить препятствие по оси Z (к игроку)
		GetComponent<Rigidbody>().AddForce(0f, 0f, -force);
	}
}
