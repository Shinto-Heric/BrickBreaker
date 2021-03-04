using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f,10f)][SerializeField] float speed = 1f;
    // Start is called before the first frame update

    [SerializeField] int pointsPerBlock = 45;
    [SerializeField] int currectScore = 0;
    [SerializeField] bool isAutoPlayEnabled;
    [SerializeField] TextMeshProUGUI score;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        score.text = currectScore.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = speed;
    }
    public void AddScore()
    {
        currectScore += pointsPerBlock;
        score.text = currectScore.ToString();
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
