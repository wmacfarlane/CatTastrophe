using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour
{
	private bool hasSpawn;
	private MoveScript moveScript;
	private WeaponScript[] weapons;
<<<<<<< HEAD
	static int enemyCount;
	void Awake()
	{
		enemyCount = 0;
=======
	static int enemyid = 0;
	void Awake()
	{
		enemyid = 0;
>>>>>>> c7f51c5054e2d0a70c6e79f42c350320f2a82088
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
					weapon.Attack (true, this.name);
				}
			}
		}
	}
	// 3 - Activate itself.
	private void Spawn()
	{
		name = "enemy" + enemyCount++;
		hasSpawn = true;
		
		this.name = "enemy"+enemyid;
		
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