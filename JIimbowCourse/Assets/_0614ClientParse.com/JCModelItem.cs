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
	public int cost{
		get{
			return 0;
		}
		set{
			;
		}
	}
	public void init(){
		this._name=GetProperty<string>("name");
		this._description=GetProperty<string>("description");
		this._amount=GetProperty<int>("amount");
		var spriteName=GetProperty<string>("icon");
		this._icon=JCRescouceManager.instance.spriteByName(spriteName);
	}
}
