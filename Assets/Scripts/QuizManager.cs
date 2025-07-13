using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject quizPanel;
    public Slider progressBar;
    public TextMeshProUGUI progressText;
    public TextMeshProUGUI questionText;
    public Button[] answerButtons;
    public Button nextButton;

    [Header("Progress Bar Animation")]
    public float progressAnimationSpeed = 5f;

    private Question[] questions;
    private int currentQuestionIndex = 0;
    private bool answered = false;
    private Coroutine progressCoroutine;

    public enum QuizType
    {
        Raag,
        Sur
    }

    [Header("Quiz Settings")]
    public QuizType quizType = QuizType.Raag; // Default to Raag; change via Inspector or script


    void Start()
    {
        nextButton.interactable = false;
        nextButton.onClick.AddListener(NextQuestion);

    }

    void LoadQuestions()
    {
        if (quizType == QuizType.Raag)
        {
            questions = new Question[]
            {
                    new Question
                    {
                        questionText = "What is the definition of Raag?",
                        answers = new string[] { "A set of notes ascending and descending a scale that provoke a specific emotion.", "A style of Indian Classical music permormed at festivals.", "A sequence of noted used in Kirtan without any structure.", "A Tanti Saaj used in Kirtan to evoke certain emotions." },
                        correctAnswerIndex = 0
                    },
                    new Question
                    {
                        questionText = "How many Shudh Raags are there in Sri Guru Granth Sahib Ji?",
                        answers = new string[] { "68", "31", "25", "40" },
                        correctAnswerIndex = 1
                    },
                    new Question
                    {
                        questionText = "What is the term for the ascending scale of a Raag?",
                        answers = new string[] { "Avroh", "Raag", "Aroh", "Sur" },
                        correctAnswerIndex = 2
                    },
                    new Question
                    {
                        questionText = "What is the second most used Sur in a Raag",
                        answers = new string[] { "Vadi", "Anuvadi", "Vakrit Sur", "Samvadi" },
                        correctAnswerIndex = 3
                    },
                    new Question
                    {
                        questionText = "What is the term for notes that are forbidden in a Raag?",
                        answers = new string[] { "Varjit Surs", "Vakrit Surs", "Vadi", "Samvadhi" },
                        correctAnswerIndex = 0
                    },
                    new Question
                    {
                        questionText = "What is the term for the characteristic phrases of a Raag?",
                        answers = new string[] { "Thaat", "Jaati", "Mukh Ang", "Aroh" },
                        correctAnswerIndex = 2
                    },
                    new Question
                    {
                        questionText = "What is the correct order of the first five raags?",
                        answers = new string[] { "Shree, Maajh, Gauri, Asa, Gujri", "Asa, Nat Narayan, Todi, Malhaar, Basant", "Asa, Basant, Bhairav, Bilawal, Devgandharo", "Basant, Asa, Sarang, Bilwal, Malhaar" },
                        correctAnswerIndex = 0
                    },
                    new Question
                    {
                        questionText = "What is the term for the descending scale of a Raag?",
                        answers = new string[] { "Aroh", "Vadi", "Thaat", "Avroh" },
                        correctAnswerIndex = 3
                    },
                    new Question
                    {
                        questionText = "What is the term for the most used note of a Raag?",
                        answers = new string[] { "Samvadhi", "Vadi", "Thaat", "Jaati" },
                        correctAnswerIndex = 1
                    },
                    new Question
                    {
                        questionText = "What is the purpose of Raags in Sri Guru Granth Sahib Ji?",
                        answers = new string[] { "To provide a musical framework for Gurbani that helps evoke emotions.", "To entertain listners with melodies.", "To teach classical music techniques.", "To categorize Gurbani by music and ther authors." },
                        correctAnswerIndex = 0
                    }
            };
        }
        else if (quizType == QuizType.Sur)
        {
            questions = new Question[]
        {
            new Question
            {
                questionText = "What is a Sur?",
                answers = new string[] {
                    "A musical note",
                    "A rhythm pattern",
                    "A type of Raag",
                    "A tempo"
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "How many Shudh Surs are in an octave?",
                answers = new string[] {
                    "12",
                    "5",
                    "7",
                    "8"
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "Which of these is NOT a Sur in Gurmat Sangeet?",
                answers = new string[] {
                    "Sa",
                    "Do",
                    "Ni",
                    "Dha"
                },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "What is a Vakrit Sur?",
                answers = new string[] {
                    "A forbidden note in a Raag",
                    "The 20th Raag in Sri Guru Granth Sahib Ji",
                    "A type of Shudh Sur",
                    "A variation of a Shudh Sur"
                },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What are the two types of Vakrit Surs?",
                answers = new string[] {
                    "Teevar and Komal",
                    "Shree and Maajh",
                    "Achala and Jaati",
                    "Taal and Theka"
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "What are the 4 Komal Surs?",
                answers = new string[] {
                    "Sa, Ga, Ma, Pa",
                    "Pa, Dha, Ni, Sa",
                    "Re, Ga, Dha, Ni",
                    "Sa, Pa, Dha, Ni"
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What is the full name of Sa?",
                answers = new string[] {
                    "Shadaj",
                    "Sa",
                    "Sarang",
                    "Saaj"
                },
                correctAnswerIndex = 1
            },

        };
        }
    }
    public void StartRaagQuiz()
    {
        quizType = QuizType.Raag;
        LoadQuestions();
        StartQuiz();
    }

    public void StartSurQuiz()
    {
        quizType = QuizType.Sur;
        LoadQuestions();
        StartQuiz();
    }

    public void StartQuiz()
    {
        currentQuestionIndex = 0;
        quizPanel.SetActive(true);
        progressBar.maxValue = questions.Length;
        progressBar.value = 0;
        DisplayQuestion();
    }

    public void ExitQuiz()
    {
        quizPanel.SetActive(false);
    }


    void DisplayQuestion()
    {
        answered = false;
        nextButton.interactable = false;

        if (currentQuestionIndex == questions.Length - 1)
        {
            nextButton.GetComponentInChildren<TextMeshProUGUI>().text = "Finish!";
        }
        else
        {
            nextButton.GetComponentInChildren<TextMeshProUGUI>().text = "Next";
        }


        Question q = questions[currentQuestionIndex];
        questionText.text = q.questionText;
        progressText.text = $"Question {currentQuestionIndex + 1} / {questions.Length}";

        AnimateProgressBar(currentQuestionIndex);

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = q.answers[i];
            answerButtons[i].interactable = true;
            answerButtons[i].image.color = Color.white;  // reset color

            int index = i;  // capture local variable for closure
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
        }
    }

    void OnAnswerSelected(int selectedIndex)
    {
        if (answered) return;
        answered = true;

        Question q = questions[currentQuestionIndex];

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = false;
            if (i == q.correctAnswerIndex)
                answerButtons[i].image.color = new Color32(167, 255, 66, 255);  // A7FF42;  Correct answer highlight
            else if (i == selectedIndex)
                answerButtons[i].image.color = new Color32(255, 126, 71, 255);  // FF7E47;  Wrong answer highlight
        }

        nextButton.interactable = true;
        if (currentQuestionIndex == questions.Length - 1)
        {
            AnimateProgressBar(questions.Length);
        }

    }

    public GameObject quizEndPanel;

    void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex >= questions.Length)
        {
            quizPanel.SetActive(false);
            if (quizEndPanel != null)
                quizEndPanel.SetActive(true);
            Debug.Log("Quiz finished!");
            return;
        }
        DisplayQuestion();
    }


    void AnimateProgressBar(float targetValue)
    {
        if (progressCoroutine != null)
            StopCoroutine(progressCoroutine);

        progressCoroutine = StartCoroutine(AnimateProgressCoroutine(targetValue));
    }

    IEnumerator AnimateProgressCoroutine(float targetValue)
    {
        while (Mathf.Abs(progressBar.value - targetValue) > 0.01f)
        {
            progressBar.value = Mathf.Lerp(progressBar.value, targetValue, Time.deltaTime * progressAnimationSpeed);
            yield return null;
        }
        progressBar.value = targetValue;
    }
}

[System.Serializable]
public class Question
{
    public string questionText;
    public string[] answers;
    public int correctAnswerIndex;
}
