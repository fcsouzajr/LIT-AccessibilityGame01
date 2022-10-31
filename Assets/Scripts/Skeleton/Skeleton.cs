using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{

	#region Public Variables
	public float attackDistance; //Distância mínima para ataque
	public float moveSpeed;
	public float timer; // Cooldown entre ataques
	
	public float hpSkel = 50f;
	public float dmgSkel = 30f;

	public GameObject hotZone;
	public GameObject triggerArea;
	[HideInInspector] public Transform target;
	[HideInInspector] public bool inRange; //checar se o player está perto
	#endregion

	#region Private Variables
	private Animator anim;
	private float distance; //Distância entre o inimigo e o player
	public bool attackMode;
	private float intTimer;

	GameObject player;
	#endregion

	void Awake() {
		intTimer = timer;
		anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update()
	{
		if (inRange)
		{
			EnemyLogic();
		}
	}

	void EnemyLogic()
	{
		distance = Vector2.Distance(transform.position, target.position);

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
			Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
			transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
		}
	}

	// ---------- Apenas para animação
	void Attack()
	{
		timer = intTimer; //reset timer
		attackMode = true;

		anim.SetInteger("Idle", 1);
		anim.SetBool("canWalk", false);
		anim.SetBool("Attack", true);
	}

	// -Desferir DANO
	public void DealDamage()
	{
		player.SendMessage("Damage", dmgSkel); //coisas dando errado aq...
	}

	// -Sofrer Dano
	void Hurt(float dmgPlayer) // ... e aqui
	{
		// hp -= dmgPlayer;

		// if(hp <= 0)
		// {
		// 	Destroy(gameObject);
		// }
	}

	void StopAttack()
	{
		attackMode = false;
		anim.SetBool("Attack", false);
	}

	// Verifica pra qual lado virar
	public void Flip()
	{
		Vector3 rotation = transform.eulerAngles;
		if(target.position.x < transform.position.x)
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