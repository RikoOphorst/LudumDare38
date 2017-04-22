using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class CountryHighlighter : MonoBehaviour
{
    private Camera mainCamera;
    private PolygonCollider2D countryCollider;
    public GameObject countryHighlighter;

	void Start ()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        countryCollider = GetComponent<PolygonCollider2D>();
        countryHighlighter.SetActive(false);
    }
	
	void Update ()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(mainCamera.ScreenToWorldPoint(Input.mousePosition).x, mainCamera.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0);

        if (hit && hit.collider == countryCollider)
        {
            countryHighlighter.SetActive(true);
        }
        else
        {
            countryHighlighter.SetActive(false);
        }
	}
}
