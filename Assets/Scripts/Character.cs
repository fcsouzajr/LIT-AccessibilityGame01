using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public abstract class Character : MonoBehaviour {
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

  [Header("Attack Variables")]
  public float attackDamage; // Todos

  void Start()
  {
    body = GetComponent<Rigidbody2D>();
    sprite = GetComponent<SpriteRenderer>();
    player = GameObject.FindGameObjectWithTag("Player");
    anim = GetComponent<Animator>();
  }
}