using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
  private Skeleton enemyParent;

  private void Awake()
	{
		enemyParent = GetComponentInParent<Skeleton>();
	}

  void OnTriggerEnter2D(Collider2D collider)
  {
    enemyParent.DealDamage();
  }
}