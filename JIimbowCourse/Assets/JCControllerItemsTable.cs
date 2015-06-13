using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Parse;

public class JCControllerItemsTable : MonoBehaviour {
	public JCControllerItemCell prefab;
	public Transform groupWrapper;
	public List<JCModelItem> items;
	[ContextMenu("create")]
	void itemCreate(){
		var item=ParseObject.Create<JCModelItem>();
		item.name="";
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
	}
	[ContextMenu("upload")]
	public void upload(){
	}
	void Awake(){
		ParseObject.RegisterSubclass<JCModelItem>();
	}
	[ContextMenu("execute")]
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
