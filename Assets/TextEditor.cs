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
        timer.text = "���� �� �ð� : 30��";

        

        
    }


    void Update()
    {

    }

    public void Counting()
    {
        time--;
        timer.text = "���� �� �ð� : " + time.ToString() + "��";

    }

    public void Turning()
    {
        time = 30;
        timer.text = "���� �� �ð� : " + time.ToString() + "��";
        if (go.tern == 1)
        {
            tern.text = "�浹";
        }
        else if (go.tern == 2)
        {
            tern.text = "�鵹";
        }
    }
}
