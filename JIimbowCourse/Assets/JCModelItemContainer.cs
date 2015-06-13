using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;

public class JCModelItemContainer : MonoBehaviour {
	public List<JCModelItem> items;
	[ContextMenu("create")]
	void itemCreate(){
		var item=ParseObject.Create<JCModelItem>();
		// item.
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
}
