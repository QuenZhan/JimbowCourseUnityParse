﻿using UnityEngine;
using TRNTH;
public class TrnthFxShake:MonoBehaviour{
	public Transform target;
	public string findTarget;
	public bool reversed=true;
	public bool hasOrinPos=true; 
	public bool loop=false;
	public float time=0.1f;
	public float value=0.3f;
	public float noise=0.0f;
	public Space space=Space.Self;
	public AnimationCurve curve;
	public void play(){
		enabled=true;
		_value=value+(Random.value)*noise;
		switch(space){
		case Space.World:posOrin=target.position;break;
		}
		if(!loop)Invoke("end",time);
	}
	// [SerializeField]
	Vector3 posOrin;
	float _value=0;
	void end(){
		enabled=false;
		if(!target)return;
		if(hasOrinPos){
			switch(space){
			case Space.Self:target.localPosition=posOrin;break;
			case Space.World:target.position=posOrin;break;
			}
		}
	}
	void Awake(){
		if(!target){
			var go=GameObject.Find(findTarget);
			if(go)target=go.transform;
		}
		if(!target)target=transform;
		switch(space){
		case Space.Self:posOrin=target.localPosition;break;
		}
	}
	void Start(){
		play();
	}
	void OnEnable(){
		play();
	}
	void OnDisable(){
		end();
	}
	void Update(){		
		Vector3 vec=Random.insideUnitSphere*_value*Time.timeScale;
		//*curve.Evaluate(reversed?(1-a.rate):a.rate)*_value*Time.timeScale;
		if(hasOrinPos){
			switch(space){
			case Space.Self:target.localPosition=posOrin+vec;break;
			case Space.World:target.position=posOrin+vec;break;
			}
		}else{
			target.position+=vec;
		}
	}
}