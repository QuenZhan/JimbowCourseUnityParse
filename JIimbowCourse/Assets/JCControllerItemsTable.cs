using UnityEngine;
using System.Collections;

public class JCControllerItemsTable : MonoBehaviour {
	public JCControllerItemCell prefab;
	public Transform groupWrapper;
	public JCModelItemContainer model;
	[ContextMenu("execute")]
	void execute () {
		// 清除所有 Cell 
		foreach(Transform e in groupWrapper){
			Destroy(e.gameObject);
		}
		// 根據 model 創建 view 物件
		foreach(var e in model.items){
			var cell=Instantiate(prefab) as JCControllerItemCell;
			cell.apply(e);
			cell.transform.SetParent(groupWrapper);
		}
	}
}
