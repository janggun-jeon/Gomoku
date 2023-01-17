using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go : MonoBehaviour
{
    private GameObject black;
    private GameObject white;
    public int tern = 1;
    private int[,] table = new int[19, 19];

    public TextEditor textEditor;
    private float time;
    private int clock;


    void Start()
    {
        
        black = Resources.Load("black", typeof(GameObject)) as GameObject;
        white = Resources.Load("white", typeof(GameObject)) as GameObject;

        time = 30f;
        clock = 29;

    }

    void Update()
    {
        time -= Time.deltaTime;
        if ((float)clock >= time )
        {
            if (clock <= -1)
            {
                time = 30f;
                clock = 29;
                tern = 3 - tern;
                textEditor.Turning();
            }
            textEditor.Counting();
            clock--;

        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float x = (float)((int)worldPoint.x);
            float y = (float)((int)worldPoint.y);

            if (table[(int)x + 9, (int)y + 9] == 0)
            {
                GameObject clone;
                if (tern == 1)
                {
                    clone = Instantiate(black);
                    time = 30f;
                    clock = 29;  
                    tern++;
                    textEditor.Turning();
                    table[(int)x + 9, (int)y + 9] = 1;
                }
                else
                {
                    clone = Instantiate(white);
                    time = 30f;
                    clock = 29;
                    tern--;
                    textEditor.Turning();
                    table[(int)x + 9, (int)y + 9] = 2;
                }
                clone.transform.position = new Vector3(x, y, -1);
                check((int)x + 9, (int)y + 9, tern);
            }
        }
    }
    
    public void message(int color)
    {
        if (color == 2)
        {
            Debug.Log("black win!");
        }
        else
        {
            Debug.Log("white win!");
        }
    }

    public void check(int a, int b, int color)
    {
        int valid = 0;
        for (int itr = (0 > a-4 ? 0 : a-4); itr < (18 < a+5 ? 18 : a+5); itr++)
        {
            if (table[itr, b] == 3 - color)
            {
                valid++;
            }
            else if (table[itr, b] == color){
                valid = 0;
            }
            if (valid == 5)
            {
                message(color); 
                return;
            }
        }

        valid = 0;
        for (int itr = (0 > b - 4 ? 0 : b - 4); itr < (18 < b + 5 ? 18 : b + 5); itr++)
        {
            if (table[a, itr] == 3 - color)
            {
                valid++;
            }
            else if (table[a, itr] == color)
            {
                valid = 0;
            }
            if (valid == 5)
            {
                message(color);
                return;
            }
        }

        valid = 0;
        int itr_a = (0 > a - 4 ? 0 : a - 4); int itr_b = (0 > b - 4 ? 0 : b - 4);
        for (; itr_a < (18 < a + 5 ? 18 : a + 5) && itr_b < (18 < b + 5 ? 18 : b + 5); itr_a++, itr_b++)
        {
            if (table[itr_a, itr_b] == 3 - color)
            {
                valid++;
            }
            else if (table[itr_a, itr_b] == color)
            {
                valid = 0;
            }
            if (valid == 5)
            {
                message(color);
                return;
            }
        }

        valid = 0;
        itr_a = (0 > a - 4 ? 0 : a - 4); itr_b = (18 < b + 4 ? 18 : b + 4);
        for (; itr_a < (18 < a + 5 ? 18 : a + 5) && itr_b > (-1 > b - 5 ? -1 : b - 5); itr_a++, itr_b--)
        {
            if (table[itr_a, itr_b] == 3 - color)
            {
                valid++;
            }
            else if (table[itr_a, itr_b] == color)
            {
                valid = 0;
            }
            if (valid == 5)
            {
                message(color);
                return;
            }
        }
    }

   
}