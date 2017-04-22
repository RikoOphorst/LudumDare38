using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NotificationToastType
{
    NotificationToastPositive,
    NotificationToastNegative,
    NotificationToastWarning,
    NotificationToastNeutral
}

public class NotificationCenter : MonoBehaviour
{
    public NotificationToast toastPrefab;
    private Transform toastGroup;
    private List<NotificationToast> toasts;
    private int numTests;

	void Start ()
    {
        toasts = new List<NotificationToast>();

        toastGroup = transform.FindChild("NotificationToasts");
        CreateNotification("hello1", NotificationToastType.NotificationToastPositive);
        CreateNotification("hello2", NotificationToastType.NotificationToastPositive);
        CreateNotification("hello3", NotificationToastType.NotificationToastPositive);
        CreateNotification("hello4", NotificationToastType.NotificationToastPositive);
        CreateNotification("hello5", NotificationToastType.NotificationToastPositive);
        CreateNotification("hello6", NotificationToastType.NotificationToastPositive);
        CreateNotification("hello7", NotificationToastType.NotificationToastPositive);

        numTests = 0;
    }
	
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.J))
        {
            CreateNotification("This is test #" + ++numTests, NotificationToastType.NotificationToastPositive);
        }
	}

    public void CreateNotification(string text, NotificationToastType toastType)
    {
        for (int i = 0; i < toasts.Count; i++)
        {
            toasts[i].transform.localPosition += new Vector3(0.0f, 70.0f, 0.0f);
        }

        NotificationToast toast = Instantiate(toastPrefab, Vector3.zero, Quaternion.identity, toastGroup);
        toast.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        toast.transform.localPosition = new Vector3(0.0f, 5.0f, 0.0f);

        toasts.Add(toast);

        toast.SetText(text);

        if (toasts.Count > 5)
        {
            Destroy(toasts[0].gameObject);
            toasts.RemoveAt(0);
        }
    }
}
