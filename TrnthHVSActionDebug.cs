﻿using UnityEngine;
using System.Collections;

public class TrnthHVSActionDebug : TrnthHVSAction {
	public string text;
	protected override void _execute(){
		Debug.Log("TrnthHVSActionDebug : "+text,transform);
	}
}
