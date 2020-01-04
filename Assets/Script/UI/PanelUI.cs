using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelUI : MonoBehaviour {

	public void HidePanel()
	{
		this.gameObject.SetActive(false);
	}

	public void ShowPanel()
	{
		this.gameObject.SetActive(true);
	}
}
