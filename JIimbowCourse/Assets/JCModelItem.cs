using UnityEngine;
using System.Collections;
using Parse;
[System.Serializable]
[ParseClassName("Item")]
public class JCModelItem:ParseObject,IJCModelItem{
	[SerializeField]string _name;
	[SerializeField]string _description;
	[SerializeField]Sprite _icon;
	[SerializeField]int _amount;

	[ParseFieldName("name")]
	public string name{
	  	get{
	  		return _name;
	  	}set{
	  		SetProperty<string>(value,"name");
	  	 	_name=value;
	  	 }
	}
	[ParseFieldName("description")]
	public string description{
	  	get{
	  		return _description;
	  	}set{
	  		SetProperty<string>(value,"description");
	  	 	_description=value;
	  	 }
	}
	[ParseFieldName("icon")]
	public Sprite icon{
	  	get{
	  		return _icon;
	  	}set{
	  		SetProperty<string>(value.name,"icon");
	  	 	_icon=value;
	  	 }
	}
	[ParseFieldName("amount")]
	public int amount{
	  	get{
	  		return _amount;
	  	}set{
	  		SetProperty<int>(value,"amount");
	  	 	_amount=value;
	  	 }
	}
}
