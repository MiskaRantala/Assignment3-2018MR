using System;
using System.ComponentModel;
using System.Linq.Expressions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace TankGame
{
	public class Health : INotifyPropertyChanged
	{
		private int _currentHealth;
        private int _lives = 3;
        public int _originalHealth;
        public GameManager gm;

		public event Action< Unit > UnitDied;
		public event Action< Unit, int > HealthChanged;

		public int CurrentHealth
		{
			get { return _currentHealth; }
			protected set
			{
				_currentHealth = value;
				// HealthChanged event is raised every time the CurrentHealth property is set.
				if ( HealthChanged != null )
				{
					HealthChanged( Owner, _currentHealth );
				}
				OnPropertyChanged( () => CurrentHealth );
			}
		}
		public Unit Owner { get; private set; }

		public Health( Unit owner, int startingHealth )
		{
			Owner = owner;
			CurrentHealth = startingHealth;
            _originalHealth = startingHealth;
		}

		/// <summary>
		/// Applies damage to the Unit.
		/// </summary>
		/// <param name="damage">Amount of damage</param>
		/// <returns>True, if the unit dies. False otherwise</returns>
		public virtual bool TakeDamage( int damage )
		{
			CurrentHealth = Mathf.Clamp( CurrentHealth - damage, -10, CurrentHealth );
			bool PlayerDidDie = CurrentHealth == 0;
            bool didDie = CurrentHealth == -10;
            if (PlayerDidDie)
			{
                _lives--;
                if (_lives > 0)
                {
                    _currentHealth = _originalHealth;
                 //   gm.Respawner();
                    PlayerDidDie = false;
                }
                else
                {
                    SceneManager.LoadScene("PlayerLost");
                }
            }
            if (didDie)
            {
                _currentHealth = _originalHealth;
          //      gm.Respawner();
                didDie = false;
            }
			return didDie;
		}

		 protected void RaiseUnitDiedEvent()
		{
			if ( UnitDied != null )
			{
				UnitDied( Owner );
                
            }
		} 
        
        public void SetHealth( int health )
		{
			// TODO: What if the unit is dead
			CurrentHealth = health;

		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged< T >( Expression< Func< T > > propertyLambda )
		{
			if ( PropertyChanged != null )
			{
				PropertyChanged( this,
					new PropertyChangedEventArgs( Utils.Utils.GetPropertyName( propertyLambda ) ) );
			}
		}
	}
}
