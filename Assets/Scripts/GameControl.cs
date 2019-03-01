using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static bool playerDead = true;
    public static int score;
    public Transform[] enemySpawn;
    public Transform[] UpgrderSpawn;
    public float enemySpawnTime = 30;
    public int maxEnemy = 5;
    public Transform playerSpawn;
    public GameObject player;
    public GameObject Upgrader;
    public GameObject enemy;
    public TextMesh scoreText;

    void Start()
    {
        maxEnemy = maxEnemy * 3;
        playerDead = false;
        score = 0;
        Instantiate(player, playerSpawn.position, Quaternion.identity);
        StartCoroutine(WaitEnemySpawn(enemySpawnTime));
    }

    IEnumerator WaitEnemySpawn(float t)
    {
        foreach (Transform obj in enemySpawn)
        {
            maxEnemy--;
            Instantiate(enemy, obj.position, Quaternion.identity);
        }
        foreach (Transform upgrader in UpgrderSpawn)
        {
            Instantiate(Upgrader, upgrader.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(t);
        if (maxEnemy > 0)
        {
            StartCoroutine(WaitEnemySpawn(enemySpawnTime));
        }
    }

    void TextPanel()
    {
        scoreText.text = score.ToString();
    }

    void Update()
    {
        TextPanel();
        if (playerDead)
        {
            playerDead = false;
            Instantiate(player, playerSpawn.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}