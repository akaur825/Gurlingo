using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    [Header("UI References")]
    public Text questionText;
    public Button[] answerButtons;
    public Text feedbackText;
    public GameObject feedbackPanel;
    public Button nextButton;
    public Slider progressSlider;

    [Header("Quiz Data")]
    private List<Question> questions;
    private int currentQuestionIndex = 0;
    private int score = 0;

    void Start()
    {
        // Temporary: load some test questions
        LoadDummyQuestions();

        // Setup slider
        progressSlider.minValue = 0;
        progressSlider.maxValue = 1;
        progressSlider.value = 0;

        ShowQuestion();
    }

    void LoadDummyQuestions()
    {
        // Replace this with real data later
        questions = new List<Question>
        {
            new Question("What is the sur after Re?", new string[] {"Ga", "Ma", "Ni", "Sa"}, 0),
            new Question("Which sur comes before Ma?", new string[] {"Ga", "Pa", "Re", "Ni"}, 0),
            new Question("What is the western name for Sa?", new string[] {"C", "D", "G", "A"}, 0),
        };
    }

    void ShowQuestion()
    {
        Question q = questions[currentQuestionIndex];
        questionText.text = q.text;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = q.choices[i];
            int index = i;
            answerButtons[i].interactable = true;
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => AnswerSelected(index));
        }

        feedbackPanel.SetActive(false);
        nextButton.gameObject.SetActive(false);

        // Animate progress bar
        float progress = (float)currentQuestionIndex / questions.Count;
        StartCoroutine(AnimateSlider(progress));
    }

    void AnswerSelected(int index)
    {
        bool correct = questions[currentQuestionIndex].correctIndex == index;

        // Disable buttons
        foreach (var btn in answerButtons)
        {
            btn.interactable = false;
        }

        feedbackText.text = correct ? "✅ Correct!" : "❌ Wrong!";
        feedbackPanel.SetActive(true);

        if (correct) score++;

        nextButton.gameObject.SetActive(true);
    }

    public void OnNextQuestion()
    {
        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Count)
        {
            ShowQuestion();
        }
        else
        {
            ShowResults();
        }
    }

    void ShowResults()
    {
        feedbackPanel.SetActive(true);
        questionText.text = "🎉 Quiz Complete!";
        feedbackText.text = $"You got {score} out of {questions.Count} right!";
        nextButton.gameObject.SetActive(false);

        // Fill slider to 100%
        StartCoroutine(AnimateSlider(1f));
    }

    IEnumerator AnimateSlider(float targetValue)
    {
        float start = progressSlider.value;
        float time = 0f;
        float duration = 0.3f;

        while (time < duration)
        {
            progressSlider.value = Mathf.Lerp(start, targetValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        progressSlider.value = targetValue;
    }
}

// Question class for dummy questions
[System.Serializable]
public class Question
{
    public string text;
    public string[] choices;
    public int correctIndex;

    public Question(string text, string[] choices, int correctIndex)
    {
        this.text = text;
        this.choices = choices;
        this.correctIndex = correctIndex;
    }
}
