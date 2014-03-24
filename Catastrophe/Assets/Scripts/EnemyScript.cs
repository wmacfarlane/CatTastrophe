﻿using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour
{
	private bool hasSpawn;
	private MoveScript moveScript;
	private WeaponScript[] weapons;
	
	void Awake()
	{
		// Retrieve the weapon only once
		weapons = GetComponentsInChildren<WeaponScript>();

		// Retrieve scripts to disable when not spawn
		moveScript = GetComponent<MoveScript>();
	}

	//Disable Everything
	void Start()
	{
		hasSpawn = false;
		collider2D.enabled = false;
		moveScript.enabled = false;
		foreach (WeaponScript weapon in weapons) 
		{
			weapon.enabled = false;
		}
	}
	
	void Update()
	{
		if (hasSpawn == false) 
		{
			if (renderer.IsVisibleFrom (Camera.main)) 
			{
				Spawn ();
			}
		} 
		else
		{
			foreach (WeaponScript weapon in weapons) 
			{
				// Auto-fire
				if (weapon != null && weapon.CanAttack && weapon.enabled) 
				{
					weapon.Attack (true);
				}
			}
		}
	}
	// 3 - Activate itself.
	private void Spawn()
	{
		hasSpawn = true;
		
		// Enable everything
		// -- Collider
		collider2D.enabled = true;
		// -- Moving
		moveScript.enabled = true;
		// -- Shooting
		foreach (WeaponScript weapon in weapons)
		{
			weapon.enabled = true;
		}
	}
}