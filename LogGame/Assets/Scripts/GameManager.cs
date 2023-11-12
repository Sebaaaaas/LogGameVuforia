using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.ParticleSystemJobs;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Text scoreTxt;
    [SerializeField] private ParticleSystem ps;
    int score;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0; // Disable V-Sync
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addScore(int i)
    {
        score += i;
        string scoretxt = "Score: " + score;
        scoreTxt.text = scoretxt;
    }

    public void resetScore()
    {
        score = 0;
        string scoretxt = "Score: " + score;
        scoreTxt.text = scoretxt;
        ps.Play();
    }
}
