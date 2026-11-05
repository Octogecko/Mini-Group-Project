using TMPro;
using UnityEngine;

public class scoreAdding : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private int scoring;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoring.ToString();
    }
}
