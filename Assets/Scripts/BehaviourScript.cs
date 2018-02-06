using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Player
{
	public static class KeyboardController
	{
		public static void Move(Transform transform)
		{
			var velocity = new Vector3 ();
			var movement = new Vector3 ();

			var inAirMultiplier = 0.25f;
			var speed = 17f;

			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
			{
				var z = Input.GetKey(KeyCode.W) ? 1.0f : 0;
				z = Input.GetKey(KeyCode.S) ? -1.0f : z;

				var x = Input.GetKey(KeyCode.D) ? 1.0f : 0;
				x = Input.GetKey(KeyCode.A) ? -1.0f : x;

				movement.z = speed * z;
				movement.x = speed*x;

				//face movement dir
				Vector3 keyboardPosition = new Vector3(x, 0, z);
				transform.LookAt(transform.position + keyboardPosition);
			}

			velocity.y += Physics.gravity.y * Time.deltaTime;
			movement.x *= inAirMultiplier;
			movement.z *= inAirMultiplier;

			movement += velocity;
			movement += Physics.gravity;
			movement *= Time.deltaTime;
			transform.GetComponent<CharacterController>().Move(movement);
		}
	}
}
