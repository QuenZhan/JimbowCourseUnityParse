using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class JCControllerItemCell : MonoBehaviour {
	public new Text name;
	public Text description;
	public Image icon;
	public Text amount;
	public void apply(JCModelItem model){
		this.name.text=model.name;
		this.description.text=model.description;
		this.icon.sprite=model.icon;
		this.amount.text=model.amount.ToString();
	}
}
