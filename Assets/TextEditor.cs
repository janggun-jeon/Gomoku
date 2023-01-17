using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEditor : MonoBehaviour
{
    public Text timer;
    public Text tern;

    private int time;

    public Go go;

    void Start()
    {
        time = 30;
        timer.text = "남은 턴 시간 : 30초";

        

        
    }


    void Update()
    {

    }

    public void Counting()
    {
        time--;
        timer.text = "남은 턴 시간 : " + time.ToString() + "초";

    }

    public void Turning()
    {
        time = 30;
        timer.text = "남은 턴 시간 : " + time.ToString() + "초";
        if (go.tern == 1)
        {
            tern.text = "흑돌";
        }
        else if (go.tern == 2)
        {
            tern.text = "백돌";
        }
    }
}
