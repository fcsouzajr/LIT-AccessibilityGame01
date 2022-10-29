using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
	#region Public Variables
	public Transform rayCast;
	public LayerMask raycastMask;
	public GameObject target;
	public float rayCastLength;
	public float attackDistance; //Distância mínima para ataque
	public float moveSpeed;
	public float timer; // Cooldown entre ataques
	public bool inRange; //checar se o player está perto
	#endregion

	#region Private Variables
	private RaycastHit2D hit;
	private Animator anim;
	private float distance; //Distância entre o inimigo e o player
	public bool attackMode;
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
		}


		//Quando o player for detectado
		if(hit.collider != null)
		{
			EnemyLogic();
		}
		// Se não tiver nada dentro do Raycast (área de detecção)
		else if(hit.collider == null)
		{
			inRange = false;
		}

		// Se o player sair da distância entre ele e o inimigo
		if (inRange == false)
		{
			anim.SetBool("canWalk", false);
			StopAttack();
			anim.SetInteger("Idle", 0);
		}
	}

	// --------- PRIMEIRA INTERAÇÃO
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			target = col.gameObject;
			inRange = true;
			Flip();
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
		anim.SetInteger("Idle", 1);
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

		anim.SetInteger("Idle", 1);
		anim.SetBool("canWalk", false);
		anim.SetBool("Attack", true);
	}

	void StopAttack()
	{
		attackMode = false;
		anim.SetBool("Attack", false);
	}

	// Detecta se o player está do outro lado
	void Flip()
	{
		Vector3 rotation = transform.eulerAngles;
		if(target.transform.position.x < transform.position.x)
		{
			rotation.y = 180f;
		}
		else
		{
			rotation.y = 0f;
		}

		transform.eulerAngles = rotation;
	}
}