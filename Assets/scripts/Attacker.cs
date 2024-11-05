using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Attacker : MonoBehaviour {

		public enum StateType {state_Wander,state_Chase,state_Eat};

		public StateType currState = StateType.state_Wander;


		public GameObject pug;
		public Transform target;
		NavMeshAgent pugNav;
		// Use this for initialization
		bool needWanderDestination =true;
		Animator PugAnimator;
    public int Health = 200;
    public int energy = 200;

    void Start () {
			//pugNav = target.transform.position;
			pugNav = GetComponent<NavMeshAgent> ();
			PugAnimator = GetComponent<Animator>();
			PugAnimator.SetBool("Walk", true);
        InvokeRepeating("Decrement", 3, 3);

	}

		// Update is called once per frame
	void Update () {
			UpdateState (currState);
			FindCow();
        if (Health <= 0)
        {
            death();
        }


	}
    void Decrement()
    {
        Health -= 5;
    }
   void death()
    {
        Destroy(gameObject);
    }

    void Wandering()
		{
			//generating random loaction

			if (needWanderDestination == true) {
				pugNav.SetDestination (new Vector3 (Random.Range (10, 100), 0, Random.Range (10, 100)));
				needWanderDestination = false;
			}
			//if distance between  our position and destination is smaller than some range
			//set destination to true
			if (Vector3.Distance (this.transform.position, pugNav.destination) < 2) {
				needWanderDestination = true;
			}
		}
		void UpdateState(StateType currState)
		{

			switch (currState) {


			case StateType.state_Wander:
				Wandering ();

				break;
			case StateType.state_Chase:
				ChangeState (StateType.state_Chase);
				chase ();

				break;
			}
		}
		private void ChangeState(StateType newState)
		{
			currState = newState;
			needWanderDestination = true;
		}
		void chase ()
		{
			if (Vector3.Distance (target.position, transform.position) < 2)
				pugNav.SetDestination (target.position);
		}


		public CowControl CowPug;

		void FindCow()
		{
			if (Vector3.Distance(this.transform.position, CowPug.gameObject.transform.position) <15)
			{
				pugNav.SetDestination(CowPug.transform.position);
			}
			if (Vector3.Distance(this.transform.position, CowPug.gameObject.transform.position) <5)
			{
				pugNav.SetDestination(CowPug.transform.position);
				//PugAnimator.SetBool("Walk", false);
				PugAnimator.SetBool("Attack", true);

				CowPug.HP -= 5 * Time.deltaTime;


			}
		}
}
