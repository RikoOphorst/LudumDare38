using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfPointsBar : MonoBehaviour {

    public int total_width = 10000;
    private int total_height = 200;

	// Use this for initialization
	void Start ()
    {
        spending_bar_ = transform.FindChild("Spending");
        income_bar_ = transform.FindChild("Income");
        total_bar_ = transform.FindChild("Total");

        total_bar_.localScale = new Vector3(total_width, total_height, 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetBar(int total, int spending, int growth)
    {
        float percent_coeff = total / total_width;
        //Set total behind bar

    }

    private Transform spending_bar_;
    private Transform income_bar_;
    private Transform total_bar_;



}
