using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
	#region Public Variables
	public Transform rayCast;
	public LayerMask raycastMask;
	public float rayCastLength;
	public float attackDistance; //Distância mínima para ataque
	public float moveSpeed;
	public float timer; // Cooldown entre ataques
	#endregion

	#region Private Variables
	private RaycastHit2D hit;
	private GameObject target;
	private Animator anim;
	private float distance; //Distância entre o inimigo e o player
	private bool attackMode;
	private bool inRange; //checar se o player está perto
	private bool cooling; //checar a parada do inimigo depois do ataque
	private float intTimer;
	#endregion

	void Awake() {
		intTimer = timer;
		anim = GetComponent<Animator>();
	}
	
	void Update() {
		if (inRange)
		{
			hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);
			// RaycastDebugger();
		}

		//Quando o player for detectado
		if(hit.collider != null)
		{
			EnemyLogic();
		}
		else if(hit.collider == null)
		{
			inRange = false;
		}

		if (inRange == false)
		{
			anim.SetBool("canWalk", false);
			StopAttack();
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			target = col.gameObject;
			inRange = true;
		}
	}

	void EnemyLogic()
	{
		distance = Vector2.Distance(transform.position, target.transform.position);

		if(distance > attackDistance)
		{
			Move();
			StopAttack();
		}
		else if(attackDistance >= distance)
		{
			Attack();
		}
	}

	void Move()
	{
		anim.SetBool("canWalk", true);
		if (!anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
		{
			Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
			transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
		}
	}

	void Attack()
	{
		timer = intTimer; //reset timer
		attackMode = true;

		anim.SetBool("canWalk", false);
		anim.SetBool("Attack", true);
	}

	void StopAttack()
	{
		attackMode = false;
		anim.SetBool("Attack", false);
	}

	// void RaycastDebugger()
	// {
	// 	if(distance > attackDistance)
	// 	{
	// 		Debug.DrawRay(rayCast.position. Vector2.left * rayCastLength, Color.red);
	// 	}
	// 	else if(attackDistance > distance)
	// 	{
	// 		Debug.DrawRay(rayCast.position. Vector2.left * rayCastLength, Color.green);
	// 	}
	// }
}