using UnityEngine;

public class spawner : MonoBehaviour
{
    public board myBoard;
    public Transform spawnPoint;
    public GameObject[] pieces;

    private bool gameOver = false;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (gameOver) return;
        if (myBoard == null || spawnPoint == null || pieces == null || pieces.Length == 0) return;

        int index = Random.Range(0, pieces.Length);
        GameObject obj = Instantiate(pieces[index], spawnPoint.position, Quaternion.identity);

        piece p = obj.GetComponent<piece>();
        if (p == null)
        {
            Destroy(obj);
            return;
        }

        p.board = myBoard;
        p.spawner = this;

        if (!myBoard.isValid(obj.transform))
        {
            Debug.Log("GAME OVER");
            gameOver = true;

            MyGameManager.instance.ShowGameOver();
            AudioManager.instance.PlayGameOver();
            float restartDelay = 2f;
            restartDelay = AudioManager.instance.gameOverClip.length;
            AudioManager.instance.FadeMusicAndRestart(restartDelay);
            Destroy(obj);
        }
    }
}