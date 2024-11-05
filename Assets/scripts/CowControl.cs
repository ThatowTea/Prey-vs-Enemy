using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class CowControl : MonoBehaviour
{
    //get a reference to all food objects
    //test to see if any of them are in range
    //set one of them that are in range to be our target
    //move towards food target
    //when in range of food target, call foods eatMe() function
    float sightRange = 120;
    public Grass foodTarget;
    Grass[] grasses;
    public int energy = 10;
	//public Lion lionToEvate;
	//Lion[] leos;
	public Transform eyes;
	public Grass foodTargetNotHit; 


	public enum StateType { state_SFF, state_Eat,state_RunAway };

    public StateType currState = StateType.state_SFF;
	public float HP = 100;
	public float hungerPerFrame = 5;
	public float hungerPerSecond = 5;
	public bool hasDest = false; 
	float runSpeed = 10;
	float walkSpeed = 4;

    //set to true when we need to generate a new destination
    bool needWanderDestination = true;
    public GameObject pos;
	NavMeshAgent cowNav;//a
    Animator anim;
    // Use this for initialization
    void Start()
    {
        cowNav = GetComponent<NavMeshAgent>();
		cowNav.speed = walkSpeed;
		anim = GetComponent<Animator>();
		InvokeRepeating ("HungerRepeater", 1, 1);    
        Move(new Vector3(0, 0, 0));
    }

    void Move(Vector3 target)
    {
        cowNav.SetDestination(target);
    }

    // Update is called once per frame
    void Update()
    {
		if (HP <= 0) {
			Destroy (gameObject);
			anim.SetBool ("Eat", true);
			anim.SetBool ("Dead", true);
			anim.SetBool ("isWalking", true);

			///Have to add desspawn cow after 5 seconds

		}
		else
        UpdateState(currState);
		if (foodTargetNotHit != null) {
			Vector3 DirTotarget = foodTargetNotHit.gameObject.transform.position = eyes.position;
			Debug.DrawRay (eyes.position, DirTotarget * 1000, Color.red); 
		}
    }


    void UpdateState(StateType currentState)
    {
        switch (currentState)
        {
            case StateType.state_RunAway:
                anim.Play("Run");
                anim.SetBool("isRunning", true);
                //if (!DetectEnemy())
                //{
                //    ChangeState(StateType.state_SFF);
                //    anim.SetBool("isRunning", false);
                //}
                //else
                //{
                //    cowNav.speed = runSpeed;
                //    Evade();
                //}
                break;

            case StateType.state_SFF:
			Wandering ();//actually moves our cow
			if (CheckFood ()) {
				// print("changingstate");
				ChangeState (StateType.state_Eat);
			} else if (CheckFood () == false) {
				energy--;
				if (energy <= 0) {
					anim.SetBool ("isWalking", false);
					anim.SetBool ("isDead", true);
					NavMeshAgent agent = GetComponent<NavMeshAgent> ();
					agent.Stop();

				}
			}
                   
			/*anim.SetBool ("isWalking", true);
			cowNav.speed = walkSpeed;
			if (DetectEnemy ()) {
				anim.SetBool ("isWalking", false);
				ChangeState (StateType.state_RunAway);
			} else if (FindFood ()) {
				ChangeState (StateType.state_Eat);
				hasDest = false;
				anim.SetBool ("isWalking", false);
			}
			Search ();*/

                break;
		case StateType.state_Eat:
			if (!foodTarget) {
				ChangeState (StateType.state_SFF);
			} else {
				Eat ();
			}

			/*
			anim.SetBool ("Eat", true);
			if (DetectEnemy ()) {
				anim.SetBool ("Eat", false);
				ChangeState (StateType.state_RunAway);
			}
			if (foodTarget = null) {
				anim.SetBool ("Eat", false);
				ChangeState (StateType.state_SFF);

			} else {
				Eat ();
			}*/
                break;
        }
    }

    //Hunger();
    void Decrement()
    {
        energy -= 15;
    }

    void Hunger()
	{
		if (currState != StateType.state_Eat) {
			HP = HP - hungerPerFrame * Time.deltaTime;
		}
	}

	void HungerRepeater()
	{
		if (currState != StateType.state_Eat) {
			HP -= hungerPerSecond;
		}
	}
    private void ChangeState(StateType newState)
    {
        print("Changing from" + currState + " to " + newState);
        currState = newState;
        needWanderDestination = true;
    }
	/*public Evade(){
		cowNav.SetDestination(RandomNavmeshHidelocation(lionToEvade.gameObject.transform.position));
	}*/
    private void Eat()
    {
        if (foodTarget)
            cowNav.SetDestination(foodTarget.gameObject.transform.position);
        //if we are close enough to the grass, eat it
        if (foodTarget)
            if (Vector3.Distance(transform.position, foodTarget.gameObject.transform.position) < 2)
            {
                foodTarget.EatMe(20);
            }

    }
    private void Evade()
    {
        cowNav.speed = 8;
        cowNav.SetDestination(new Vector3(Random.Range(10, 1000), 0, Random.Range(10, 1000)));
        cowNav.SetDestination(pos.gameObject.transform.position);
    }
    bool CheckFood()//checks for nearby food. If food is found return true, otherwise return false
    {

        grasses = FindObjectsOfType<Grass>();
        print("amount of grass in scene" + grasses.Length);
        //test to see if any of them are in range by looping through grasses array
        //set one of them that are in range to be our foodtarget
        foreach (Grass g in grasses)
        {
            //print(Vector3.Distance(g.gameObject.transform.position, transform.position));
            if (Vector3.Distance(g.gameObject.transform.position, transform.position) < sightRange)
            {
                foodTarget = g;
                print("Found food");
                return true;
                //will still work without this
            }
        }
        return false;
    }
    void Wandering()
    {
        //move to random location here!
        if (needWanderDestination == true)
        {
            cowNav.SetDestination(new Vector3(Random.Range(10, 1000), 0, Random.Range(10, 1000)));

            needWanderDestination = false;
        }
        //if distance between our position and destination is smaller than some range
        //set needWanderDestination to true
        if (Vector3.Distance(this.transform.position, cowNav.destination) < 2)
        {
            needWanderDestination = true;
        }
        //print(cowNav.destination);
		anim.SetBool("isWalking", true);
    }

	//private bool DetectEnemy()
 //   {

 //   }
	//private bool ChangeState(StateType newState)...
	//private bool (ResetVars)...
	//private bool Search()...
	//public RamdomweshLocation(float radius)...
	//public RamdomweshLocation(Vector3 enemyPos)... 


	/*private bool FindFood()
	{
		grasses = FindObjectOfType<Grass[]> ();

		foreach(Grass food in  grasses)
		{
			if (Vector3.Distance (this.transform.position, food.transform.position) < sightRange && food.beingEaten == false) { 
				foodTarget = food;
				return true;

			}
			}


	}*/



	/*void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Grass") {
			if (foodTarget == null || foodTarget.beingEaten) 
			{
				foodTarget = collision.GetComponent<Grass>();
			}

		}
	}*/

}
