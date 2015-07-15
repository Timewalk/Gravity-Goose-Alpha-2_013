using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimateShield : MonoBehaviour {

    public float BumpAnimationSpeed = 1.0f;
    public Texture mat_1;
    public Texture mat_2;
    public Texture mat_3;
    public Texture mat_4;
    public Texture mat_5;
    public Texture mat_6;
    public Texture mat_7;
    public Texture mat_8;
    public Texture mat_9;
    public Texture mat_10;
    public Texture mat_11;
    public Texture mat_12;
    public Texture mat_13;
    public Texture mat_14;
    public Texture mat_15;
    public Texture mat_16;

    public Color ShieldsInActive;
    public Color ShieldsActive;

    public bool ShieldsHit = false;

    private List<Texture> _Mats = new List<Texture>();
    private float _idx = 0;
    private Color _shieldColor;


    // Use this for initialization
	void Start () {
        _Mats.Add(mat_1);
        _Mats.Add(mat_2);
        _Mats.Add(mat_3);
        _Mats.Add(mat_4);
        _Mats.Add(mat_5);
        _Mats.Add(mat_6);
        _Mats.Add(mat_7);
        _Mats.Add(mat_8);
        _Mats.Add(mat_9);
        _Mats.Add(mat_10);
        _Mats.Add(mat_11);
        _Mats.Add(mat_12);
        _Mats.Add(mat_13);
        _Mats.Add(mat_14);
        _Mats.Add(mat_15);
        _Mats.Add(mat_16);
        _shieldColor = ShieldsInActive;
	}
	
	// Update is called once per frame
    void OnGUI()
    {
        int count = Mathf.RoundToInt(_idx);
        _idx += Time.deltaTime * BumpAnimationSpeed;

        GetComponent<Renderer>().material.SetTexture("_BumpMap", _Mats[count]);
        GetComponent<Renderer>().material.color = _shieldColor;

        if (_idx >= 15.0f)
            _idx = 0;


        if (ShieldsHit == true)
        {
            if (_shieldColor != ShieldsActive)
                _shieldColor = Color.Lerp(_shieldColor, ShieldsActive, Time.deltaTime * 2);
        }

        else if (ShieldsHit == false)
        {
            if (_shieldColor != ShieldsInActive)
                _shieldColor = Color.Lerp(_shieldColor, ShieldsInActive, Time.deltaTime * 2);
        }

	}

}
