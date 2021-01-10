using System;
using UnityEngine;
using UnityEngine.UI;

public class ScorePrinter : MonoBehaviour
{
    public Animator _animator = null;
    public Text _timeText = null;
    public Text _scoreText = null;

    void Update()
    {
        float previousTime = ScoreInstance.instance.timeElapsed;
        ScoreInstance.instance.timeElapsed += Time.deltaTime;

        float modTimeElapsed = ScoreInstance.instance.timeElapsed % 10f;
        float modPrevTime = previousTime % 10f; 

        if (modTimeElapsed < modPrevTime && modPrevTime < 10f && modTimeElapsed >= 0f)
        {
            _animator.SetTrigger("Jiggle");
        }

        UpdateText();
    }

    void UpdateText()
    {
        _timeText.text = String.Format("{0:00}:{1:00}:{2:00}", (int)(ScoreInstance.instance.timeElapsed / 60), (int)(ScoreInstance.instance.timeElapsed % 60f), (int)((ScoreInstance.instance.timeElapsed % 1f) * 100f));
        _scoreText.text = ScoreInstance.instance.score.ToString();
    }
}