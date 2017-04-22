using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationToast : MonoBehaviour
{

    public Text textComponent;
    public Image iconComponent;

	void Awake ()
    {
        textComponent = GetComponentInChildren<Text>();
        iconComponent = GetComponentInChildren<Image>();
	}
	
	void Update ()
    {
		
	}

    public void SetText(string text)
    {
        textComponent.text = text;
    }
}
