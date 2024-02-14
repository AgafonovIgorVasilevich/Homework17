using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private const string ScoreRecord = nameof(ScoreRecord);

    [SerializeField] private GameObject _recordIndicator;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable() => _scoreCounter.ScoreChanged += SaveRecord;

    private void OnDisable() => _scoreCounter.ScoreChanged -= SaveRecord;

    public int GetRecord() => PlayerPrefs.GetInt(ScoreRecord, 0);

    private void SaveRecord(int current)
    {
        if (current > GetRecord())
        {
            PlayerPrefs.SetInt(ScoreRecord, current);
            _recordIndicator.SetActive(true);
        }
    }
}