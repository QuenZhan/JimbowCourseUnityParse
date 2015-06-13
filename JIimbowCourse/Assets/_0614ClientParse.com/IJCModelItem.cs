using UnityEngine;
using System.Collections;

public interface IJCModelItem{
	string name{get;set;}
	string description{get;set;}
	Sprite icon{get;set;}
	int amount{get;set;}
}
