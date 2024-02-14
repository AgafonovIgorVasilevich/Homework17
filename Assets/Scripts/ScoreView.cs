using UnityEngine.UI;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private Text _current;
    [SerializeField] private Text _record;
    [SerializeField] private SaveManager _saveManager;

    private void Start() => _record.text = _saveManager.GetRecord().ToString();

    private void OnEnable() => _score.ScoreChanged += ShowScore;

    private void OnDisable() => _score.ScoreChanged -= ShowScore;

    private void ShowScore(int score) => _current.text = score.ToString();
}