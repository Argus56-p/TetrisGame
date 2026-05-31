using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class board : MonoBehaviour
{
    public int width = 10;
    public int height = 20;
    public AudioSource rowsound;

    private Transform[,] grid;

    void Awake()
    {
        grid = new Transform[width, height];
    }

    Vector2Int WorldToCell(Vector3 worldPos)
    {
        Vector3 local = worldPos - transform.position;

        return new Vector2Int(
            Mathf.RoundToInt(local.x),
            Mathf.RoundToInt(local.y)
        );
    }

    public bool isValid(Transform piece)
    {
        foreach (Transform block in piece)
        {
            Vector2Int cell = WorldToCell(block.position);

            if (cell.x < 0 || cell.x >= width || cell.y < 0)
                return false;

            if (cell.y >= height)
                continue;

            if (grid[cell.x, cell.y] != null)
                return false;
        }

        return true;
    }

    public void Lock(Transform piece)
    {
        foreach (Transform block in piece)
        {
            Vector2Int cell = WorldToCell(block.position);

            if (cell.x < 0 || cell.x >= width || cell.y < 0 || cell.y >= height)
                continue;

            grid[cell.x, cell.y] = block;
        }
    }


    public int ClearLines()
    {
        int cleared = 0;
        int[] lines = new int[height];
        for (int y = 0; y < height; y++)
        {
            if (IsLineFull(y))
            {
                //DeleteLine(y);
                //MoveLinesDown(y + 1);
                //y--;
                lines[cleared] = y;
                cleared++;
                rowsound.Play();

            }
        }

        if (cleared > 0)
        {
            //CameraShake01.instance.Shake(0.12f, 0.08f);
            StartCoroutine(ClearWithEffect(lines, cleared));
        }
        return cleared;
    }


    IEnumerator ClearWithEffect(int[] lines, int count)
    {

        for (int i = 0; i < count; i++)
        {
            Debug.Log("Leitud!");
            int y = lines[i];

            for (int x = 0; x < width; x++)
            {


                if (grid[x, y] != null)

                {

                    var sr = grid[x, y].GetComponent<SpriteRenderer>();

                    if (sr != null)
                        Debug.Log("Leitud!");
                    sr.color = Color.green;
                }
            }
        }

        yield return new WaitForSeconds(0.5f);
        // Rea kustutamine
        for (int i = 0; i < count; i++)
        {
            int y = lines[i];
            for (int x = 0; x < width; x++)
            {
                Destroy(grid[x, y].gameObject);
                grid[x, y] = null;
            }
        }


        for (int i = count - 1; i >= 0; i--)
        {
            MoveLinesDown(lines[i] + 1);
        }
    }

    /*void CollapseBoard()
    {
        int emptyRowsBelow = 0;

        for (int y = 0; y < height; y++)
        {
            bool rowEmpty = true;

            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] != null)
                {
                    rowEmpty = false;
                    break;
                }
            }

            if (rowEmpty)
            {
                emptyRowsBelow++;
            }
            else if (emptyRowsBelow > 0)
            {
                for (int x = 0; x < width; x++)
                {
                    if (grid[x, y] != null)
                    {
                        grid[x, y - emptyRowsBelow] = grid[x, y];
                        grid[x, y] = null;

                        grid[x, y - emptyRowsBelow].position += Vector3.down * emptyRowsBelow;
                    }
                }
            }
        }
    }*/

    bool IsLineFull(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, y] == null)
                return false;
        }
        return true;
    }

    void DeleteLine(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, y] != null)
            {
                Destroy(grid[x, y].gameObject);
                grid[x, y] = null;
            }
        }
    }

    void MoveLinesDown(int fromY)
    {
        for (int y = fromY; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].position += Vector3.down;
                }
            }
        }
    }
}