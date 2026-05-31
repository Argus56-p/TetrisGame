using UnityEngine;
using System.Collections;

public class piece : MonoBehaviour
{
    public board board;
 public spawner spawner;
    TrailRenderer trail;


    private float fallTime;
    private float fastFallTime;

    private float timer = 0f;
    private bool locked = false;

    void Start()
    {
        SnapToGrid();
        fallTime = PlayerPrefs.GetFloat("fallTime");
        fastFallTime = PlayerPrefs.GetFloat("fastFallTime");

    }

    void Update()
    {
        if (locked) return;
        if (board == null || spawner == null) return;

        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Move(Vector3.left);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            Move(Vector3.right);

        if (Input.GetKeyDown(KeyCode.UpArrow))
            RotatePiece();

        float currentFallTime = Input.GetKey(KeyCode.DownArrow) ? fastFallTime : fallTime;



        if (timer >= currentFallTime)
        {
            timer = 0f;
            Fall();
        }
    }

    public void Fall()
    {
        transform.position += Vector3.down;
        SnapToGrid();

        if (!board.isValid(transform))
        {
            transform.position += Vector3.up;
            SnapToGrid();

            board.Lock(transform);
            int clearedLines = board.ClearLines();
            if (clearedLines > 0)
            {
                int points = 0;
                if (clearedLines == 1) points = 100;
                else if (clearedLines == 2) points = 300;
                else if (clearedLines == 3) points = 500;
                else if (clearedLines >= 4) points = 1000;

                MyGameManager.instance.AddScore(points);
                AudioManager.instance.PlayLineClear();
            }

            locked = true;
            enabled = false;
            StartCoroutine(SpawnNext());
        }
    }

    IEnumerator SpawnNext()
    {
        yield return null;
        if (spawner != null)
            spawner.Spawn();
    }

    public void Move(Vector3 dir)
    {
        transform.position += dir;
        SnapToGrid();

        if (!board.isValid(transform))
        {
            transform.position -= dir;
            SnapToGrid();
        }
    }

    public void RotatePiece()
    {
        transform.Rotate(0f, 0f, -90f);
        SnapToGrid();

        if (!board.isValid(transform))
        {
            transform.Rotate(0f, 0f, 90f);
            SnapToGrid();
        }
    }

    void SnapToGrid()
    {
        transform.position = new Vector3(
            Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y),
            0f
        );

        foreach (Transform block in transform)
        {
            block.position = new Vector3(
                Mathf.Round(block.position.x),
                Mathf.Round(block.position.y),
                0f
            );
        }
    }

}