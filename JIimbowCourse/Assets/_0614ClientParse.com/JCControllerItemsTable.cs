using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Parse;
using TRNTH;

public class JCControllerItemsTable : MonoBehaviour {
	static JCControllerItemsTable instance; 

	[SerializeField]JCControllerItemCell prefab;
	[SerializeField]Transform groupWrapper;
	[SerializeField]public List<JCModelItem> items;
	[SerializeField]JCRescouceManager resourceManger;

	[ContextMenu("create")]
	void itemCreate(){
		var item=ParseObject.Create<JCModelItem>();
		item.name=U.choose("旅人救世劍","林大嬸婆糙","安安雷好");
		item.amount=U.choose(1,2,3);
		item.icon=resourceManger.spriteRandom;
		item.description=U.choose<string>("安安安安","這是一堆描述","是不是");
		item.SaveAsync();
		items.Add(item);
	}
	[ContextMenu("delete")]
	void itemDelete(){
		if(items.Count<1)return;
		var item=items[0];
		item.DeleteAsync();
		items.Remove(item);
	}

	[ContextMenu("download")]
	public void download(){
		Debug.Log("download");
		var query =new ParseQuery<JCModelItem>();
		// var str;
		query.FindAsync().ContinueWith(t =>
		{
			// Debug.Log(t.Exception.ToString());
		    var items=new List<JCModelItem>(t.Result);
		    foreach(var e in items){
		    	e.init();
		    }
		    // str
		    JCControllerItemsTable.instance.items=items;
		});
	}
	[ContextMenu("upload")]
	public void upload(){
		ParseObject.SaveAllAsync(items);
	}
	void Awake(){
		instance=this;
		ParseObject.RegisterSubclass<JCModelItem>();
	}
	[ContextMenu("refresh view")]
	void execute () {
		// 清除所有 Cell 
		foreach(Transform e in groupWrapper){
			Destroy(e.gameObject);
		}
		// 根據 model 創建 view 物件
		foreach(var e in items){
			var cell=Instantiate(prefab) as JCControllerItemCell;
			cell.apply(e);
			cell.transform.SetParent(groupWrapper);
		}
	}

}
