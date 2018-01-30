using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    public Sprite frontSide; 
    public Sprite backSide;
    public Sprite sunShine;

    Sprite tmpFront;

    private GameObject obj;
    private Image tmpImage;
    private bool flagAngle;
    private bool flagStop;

    private float angleDelta;
    private float delta;

    // Use this for initialization
    void Start () {
        obj = GameObject.Find("agent").gameObject as GameObject;
        tmpImage = obj.GetComponent<Image> ();
        tmpFront = frontSide;
        flagAngle = true;
        flagStop = false;
        delta = Time.deltaTime * 100;
        angleDelta = delta;
}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(0, angleDelta, 0);

        if(transform.localEulerAngles.y >= 90f && flagAngle)
        {
            tmpImage.sprite = backSide;
            Vector3 scale = transform.localScale;
            scale.x = -scale.x;
            //transform.Rotate(0, 180f, 0);
            transform.localScale = scale;
            flagAngle = false;
        }

        
        if(transform.localEulerAngles.y >= 270f && !flagAngle)
        {
            tmpImage.sprite = tmpFront;
            flagAngle = true;
            Vector3 scale = transform.localScale;
            scale.x = -scale.x;
            //transform.Rotate(0, 180f, 0);
            transform.localScale = scale;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // アプリケーション終了
            Application.Quit();
        }


    }

    public void ChangeImage() {

        
        if (!flagStop)
        {
            angleDelta = 0f;
            flagStop = true;
        }
        else
        {
            angleDelta = delta;
            flagStop = false;
        }
        
    }

    public void Sunshine()
    {
        if(flagAngle) tmpImage.sprite = sunShine;
        tmpFront = sunShine;
    }

    
}
