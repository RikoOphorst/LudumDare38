using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfPointsBar : MonoBehaviour {

    public int total;
    public int spending;
    public int income;

    public int total_width = 1000;
    private Vector2 start_position_;
    private float total_height_ = 200;

	// Use this for initialization
	void Start ()
    {
        spending_bar_ = (RectTransform)transform.FindChild("Spending");
        income_bar_ = (RectTransform)transform.FindChild("Income");
        total_bar_ = (RectTransform)transform.FindChild("Total");

        start_position_ = spending_bar_.rect.position;
        total_height_ = total_bar_.rect.height;

        //total_bar_.sizeDelta = new Vector2(total_width, total_height_);
    }
	
	// Update is called once per frame
	void Update ()
    {
        SetBar(total, spending, income);
	}

    void SetBar(int total, int spending, int income)
    {
        //amount of pixels per influence point
        float percent_coeff = total_width / total;

        float spending_pixels = spending * percent_coeff;
        spending_bar_.sizeDelta = new Vector2(spending_pixels, total_height_);

        float income_pixels = income * percent_coeff;
        income_bar_.sizeDelta = new Vector2(income_pixels, total_height_);

        //most rightest between spending and income
        float max_pixels = Mathf.Max(income_pixels, spending_pixels);
        float unspent_pixels = total_width - max_pixels;
        total_bar_.anchoredPosition = start_position_ + new Vector2(max_pixels, 0);
        total_bar_.sizeDelta = new Vector2(unspent_pixels, total_height_);
    }

    private RectTransform spending_bar_;
    private RectTransform income_bar_;
    private RectTransform total_bar_;



}
