using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] TextMeshProUGUI scoreText;
    private int score = 0;
    private Color color = new Color(241, 71, 73, 255);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    private void Start()
    {
        scoreText.text = string.Format($"{score}");
        scoreText.gameObject.SetActive(true);
        StartCoroutine(ScoreCoroutine());
    }

    public void ScorePlus()
    {
        ++score;
        scoreText.text = string.Format($"{score}");
        StartCoroutine(PlusRoutine());
    }

    private IEnumerator PlusRoutine()
    {
        scoreText.transform.DOScale(new Vector3(.65f, .65f, .65f), .1f);
        yield return new WaitForSeconds(.2f);
        scoreText.transform.DOScale(new Vector3(.5f, .5f, .5f), .1f);

    }
    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator ScoreCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            ScorePlus();
        }
    }
}