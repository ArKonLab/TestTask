using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour
{

    public GameObject cube;
    public int rndMax = 2;
    private System.Random rnd = new System.Random();
    private Coroutine coroutine;
    private GameObject[,] allCube;
    private Glassful glassful;
    public float timer = 3;

    private int[,] pole = new int[,]
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0 },
    };

    void Start ()
    {
        coroutine = StartCoroutine(Timer());
        Fill();
        AddFigure(new Glassful());
        //AddFigure(new Line());
        AddFigure(new Square());

    } // void Start ()

    void Update ()
    {
        Draw();
    } // void Start ()

    void Fill()
    {
        allCube = new GameObject[17, 9];

        for (int y = 0; y < 17; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                
                allCube[y, x] = Instantiate(cube);
                allCube[y, x].transform.position = new Vector3(x, 16 - y, 0);
            }
        }
    } // void Fill()

    void Draw()
    {
        for (int y = 0; y < 17; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                if (pole[y, x] > 0)
                {
                    allCube[y, x].SetActive(true);
                }
                else
                {
                    allCube[y, x].SetActive(false);
                }
            }
        }
    } // void Draw()

    void NewFigure()
    {
        int i = rnd.Next(1, 3);
        switch(i)
        {
            case 1:
                AddFigure(new Square());
                break;
            case 2:
                AddFigure(new Line());
                break;
        }
    }

    void AddFigure(Figure f)
    {
        int rows = f.figSize.GetUpperBound(0) + 1;
        int columns = f.figSize.Length / rows;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                if (f.figForm[y, x] > 0)
                {
                    pole[y + f.yCord, x + f.xCord] = f.figForm[y, x];
                }
            }
        }
    } // void AddFigure(Figure f)

    void Replace()
    {
        for (int y = 0; y < 16; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (pole[y, x] == 1)
                {
                    pole[y, x] = 2;
                }
                else
                {
                    pole[y, x] = pole[y, x];
                }
            }
        }
        NewFigure();
    } // void Replace()

    void MoveDown()
    {
        int[,] tmp = new int[17, 9];

        for (int y = 16; y >= 0; y--)
        {
            for (int x = 0; x < 9; x++)
            {

                if (y > 0)
                {
                    if (pole[y, x] > 1)
                    {
                        Replace();
                    }
                }

                if (y < 16)
                {
                    if (pole[y, x] == 1)
                    {
                        tmp[y + 1, x] = 1;
                    }
                }

                if (pole[y, x] == 2)
                {
                    tmp[y, x] = 2;
                }

                if (pole[y, x] == 3)
                {
                    tmp[y, x] = 3;
                }
            }
        }

        pole = tmp;
    } // void MoveDown()

    IEnumerator Timer()
    {
        while (true)
        {
            MoveDown();
            print("tick");
            yield return new WaitForSeconds(timer);
        }
    } // IEnumerator Timer()
}
