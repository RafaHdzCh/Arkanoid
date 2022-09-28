using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArkanoidUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lives;
    [SerializeField] TextMeshProUGUI blocks;
    public int blocksInGame;
    public GameObject[] blocksArray;
    [SerializeField] GameObject victoryGO;
    [SerializeField] Ball ball;

    public bool isTheGameOver = false;

    public int liveCounter = 3;

    void Start()
    {
        blocksArray = GameObject.FindGameObjectsWithTag("Block");
        blocksInGame = blocksArray.Length;
        CountLivesAndBlocks();
    }

    private void Update()
    {
        CountLivesAndBlocks();
        if(blocksInGame == 0)
        {
            victoryGO.SetActive(true);
            Destroy(ball.gameObject);
        }
    }

    private void CountLivesAndBlocks()
    {
        lives.text = liveCounter.ToString();
        blocks.text = blocksInGame.ToString();
    }
}
