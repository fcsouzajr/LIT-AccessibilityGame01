using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  //[Header("Components")]
  Rigidbody2D body;
  SpriteRenderer sprite;
  Animator anim;

  //[Header("Attack Variables")]
  public float attackDamage;
  public float delayAttackValue;
  private float delayAttack;
  private bool isDead = false;
  public float hp = 30f;
  GameObject player;

  //[Header("Move Variables")]
  public float speed;
  public float walkTime;
  private float timer;
  private bool walkRight;

  
}