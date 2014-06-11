﻿using UnityEngine;
using System.Collections;

public class HashID : MonoBehaviour {

	public int hittedState;
	public int deadState;
	public int dieState;
	public int headJumpedState;
	public int spawnState;
	public int spawnProtectionState;
	public int idleState;
	public int runState;
	public int changeRunDirectionState;
	public int jumpState;
	
	public int hSpeedFloat;
	public int vSpeedFloat;
	public int changeRunDirectionTrigger;

	public int groundedBool;
	public int walledBool;

	public int hittedBool;
	public int gameOverBool;
	public int headJumpedBool;
	public int spawnBool;
	public int deadBool;
	public int hitTrigger;
	public int spawnProtectionBool;
	
	void Awake() {
		hittedState =			Animator.StringToHash("Base Layer.Hitted");
		deadState = 			Animator.StringToHash("Base Layer.Dead");
		dieState = 				Animator.StringToHash("Base Layer.Die");
		headJumpedState = 		Animator.StringToHash("Base Layer.HeadJumped");
		spawnState = 			Animator.StringToHash("Base Layer.Spawn");
		spawnProtectionState = 	Animator.StringToHash("Base Layer.SpawnProtection");
		idleState = 			Animator.StringToHash("Base Layer.Idle");
		runState = 				Animator.StringToHash("Base Layer.Run");
		changeRunDirectionState = Animator.StringToHash("Base Layer.ChangeRunDirection");
		jumpState = 			Animator.StringToHash("Base Layer.Jump");

		hSpeedFloat = Animator.StringToHash("hSpeed");
		vSpeedFloat = Animator.StringToHash("vSpeed");
		changeRunDirectionTrigger = Animator.StringToHash("ChangeRunDirection");

		groundedBool = Animator.StringToHash("Grounded");
		walledBool = Animator.StringToHash("Walled");

		hittedBool = Animator.StringToHash("Hitted");
		gameOverBool = Animator.StringToHash("GameOver");
		headJumpedBool = Animator.StringToHash("HeadJumped");
		spawnBool = Animator.StringToHash("Spawn");
		deadBool = Animator.StringToHash("Dead");
		hitTrigger = Animator.StringToHash("HitTrigger");
		spawnProtectionBool = Animator.StringToHash("SpawnProtection");
	}
}
