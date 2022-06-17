using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float force = 200f;

	private void FixedUpdate()
	{
		Rigidbody player;

		player = GetComponent<Rigidbody>();

		// Переместить игрока по оси Z (в сторону)
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			player.AddForce(force * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
		}

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			player.AddForce(-force * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
		}
	}
}
