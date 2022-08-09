using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
  //==== ATRIBUTOS GERAIS ----
  [Header("Components")]
  Rigidbody2D body;
  SpriteRenderer sprite;
  Animator anim;
  GameObject player;
  bool isDead = false;
  float hp; //(Player = 100f e private) - (Inimigo = 30f e public)

  [Header("Move Variables")]
  public float speed; // Todos
  //Player
  float moveX = 0;
  public bool canInteract = true;
  //Inimigo
  public float walkTime;
  private float timer;
  private bool walkRight;

  [Header("Attack Variables")]
  public float attackDamage; // Todos
  //Player
  public Transform enemyCheck;
  public float enemyCheckRadius;
  public LayerMask whatIsEnemy;
  //Inimigo
  public float delayAttackValue;
  private float delayAttack;


  //=== ATRIBUTOS ASSOCIADOS AO PLAYER ---
  [Header("UI")]
  public float maxHP;
  public float HP;
  public Slider HPBar;


  void Start()
  {
    body = GetComponent<Rigidbody2D>();
    sprite = GetComponent<SpriteRenderer>();
    player = GameObject.FindGameObjectWithTag("Player");
    anim = GetComponent<Animator>();
  }
}