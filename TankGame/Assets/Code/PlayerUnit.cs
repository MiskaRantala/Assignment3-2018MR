using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TankGame
{
	public class PlayerUnit : Unit
	{
		[SerializeField]
		private string _horizontalAxis = "Horizontal";
		[SerializeField]
		[Tooltip("The name of the vertical axis")]
		private string _verticalAxis = "Vertical";

        public PointAwarder pointawarder;

        public float collectedPoints = 0;


		protected override void Update()
		{
			var input = ReadInput();
			Mover.Turn( input.x );
			Mover.Move( input.z );

			// TODO: Refactor me! Extract method. 
			bool shoot = Input.GetButton( "Fire1" );
			if ( shoot )
			{
				Weapon.Shoot();
			}
		}

		private Vector3 ReadInput()
		{
			float movement = Input.GetAxis( _verticalAxis );
			float turn = Input.GetAxis( _horizontalAxis );
			return new Vector3(turn, 0, movement);
		}

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Collectable"))
            {
                other.gameObject.SetActive(false);
                Debug.Log("got em");
                collectedPoints += pointawarder.pointsAwarded;

                if (collectedPoints > 300)
                {
                    SceneManager.LoadScene("PlayerWon");
                }
            }
            Debug.Log("wut");
        }
    }
}
