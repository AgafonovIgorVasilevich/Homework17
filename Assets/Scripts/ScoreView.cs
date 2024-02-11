using UnityEngine.UI;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private Text _text;

    private void OnEnable() => _score.ScoreChanged += ShowScore;

    private void OnDisable() => _score.ScoreChanged -= ShowScore;

    private void ShowScore(int score) => _text.text = score.ToString();
}