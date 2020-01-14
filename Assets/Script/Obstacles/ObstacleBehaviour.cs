using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleBehaviour : MonoBehaviour {

    [SerializeField] private SpriteRenderer image;
    List<Color> colors = new List<Color>();
    

	void Start () {
        setColor();
    }

    void SetColorList()
    {
        colors.Add(Color.cyan);
        colors.Add(Color.green);
        colors.Add(Color.grey);
        colors.Add(Color.blue);
        //colors.Add(Color.black);
    }

    public void setColor()
    {
        SetColorList();
        int colorIndex = Random.Range(0,colors.Count);
        if(colorIndex <colors.Count)
        {
            image.color = colors[colorIndex];
        }
    }

	
}
