﻿using UnityEngine;
using System.Collections;

public class TrnthHVSActionSendMessage : TrnthHVSAction {
	[HideInInspector]public string findTarget;
	public GameObject target;
	public string methodName;
	public void find(){
		if(target)return;
		var go=GameObject.Find(findTarget);
		target=go;
	}
	protected override void _execute(){
		if(!target)find();
		if(target.activeInHierarchy)target.SendMessage(methodName);
		else Debug.LogWarning("Target is deactive",transform);
	}
}
