using UnityEngine;
using TMPro;
public class MyPlayerScore : MonoBehaviour
{
    public static int Scores = 0;
    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score:{Scores}";
    }
}
