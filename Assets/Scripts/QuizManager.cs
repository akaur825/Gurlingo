using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class QuizManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject quizPanel;
    public Slider progressBar;
    public TextMeshProUGUI progressText;
    public TextMeshProUGUI questionText;
    public AnswerOption[] answerOptions; // Replaces Button[] answerButtons
    public Button nextButton;

    [Header("Progress Bar Animation")]
    public float progressAnimationSpeed = 5f;

    private Question[] questions;
    private int currentQuestionIndex = 0;
    private bool answered = false;
    private Coroutine progressCoroutine;

    private int quizLevel = 1;
    private int correctAnswers = 0;


    public enum QuizType
    {
        Raag,
        Sur
    }

    [Header("Quiz Settings")]
    public QuizType quizType = QuizType.Raag;

    void Start()
    {
        nextButton.interactable = false;
        nextButton.onClick.AddListener(NextQuestion);
    }

    void LoadQuestions()
    {
        if (quizType == QuizType.Raag)
        {
            switch (quizLevel)
            {
                case 1: questions = GetRaagLevel1Questions(); break;
                case 2: questions = GetRaagLevel2Questions(); break;
                case 3: questions = GetRaagLevel3Questions(); break;
                case 4: questions = GetRaagLevel4Questions(); break;
                case 5: questions = GetRaagLevel5Questions(); break;
                case 6: questions = GetRaagLevel6Questions(); break;
                case 7: questions = GetRaagLevel7Questions(); break;
                case 8: questions = GetRaagLevel8Questions(); break;
                case 9: questions = GetRaagLevel9Questions(); break;
                case 10: questions = GetRaagLevel10Questions(); break;
                case 11: questions = GetRaagLevel11Questions(); break;
                default:
                    Debug.LogError("Invalid Raag level.");
                    questions = new Question[0];
                    break;
            }
        }
        else if (quizType == QuizType.Sur)
        {
            switch (quizLevel)
            {
                case 1: questions = GetSurLevel1Questions(); break;
                case 2: questions = GetSurLevel2Questions(); break;
                case 3: questions = GetSurLevel3Questions(); break;
                case 4: questions = GetSurLevel4Questions(); break;
                case 5: questions = GetSurLevel5Questions(); break;
                case 6: questions = GetSurLevel6Questions(); break;
                case 7: questions = GetSurLevel7Questions(); break;
                //case 8: questions = GetSurLevel8Questions(); break;
                //case 9: questions = GetSurLevel9Questions(); break;
                //case 10: questions = GetSurLevel10Questions(); break;
                //case 11: questions = GetSurLevel11Questions(); break;
                //case 12: questions = GetSurLevel12Questions(); break;
                default:
                    Debug.LogError("Invalid Sur level.");
                    questions = new Question[0];
                    break;
            }
        }
    }

    public void StartRaagQuiz(int level)
    {
        quizType = QuizType.Raag;
        quizLevel = level;
        LoadQuestions();
        StartQuiz();
    }

    public void StartSurQuiz(int level)
    {
        quizType = QuizType.Sur;
        quizLevel = level;
        LoadQuestions();
        StartQuiz();
    }

    public void StartQuiz()
    {
        correctAnswers = 0;
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

    public void RetryQuiz()
    {
        quizEndPanel.SetActive(false);
        StartQuiz();
    }
    public void LoadRaagMenu()
    {
        SceneManager.LoadScene("RaagLevelScene"); // Replace "MainMenu" with your actual scene name
    }

    public void LoadSurMenu()
    {
        SceneManager.LoadScene("RaagLevelScene");
    }

    void DisplayQuestion()
    {
        answered = false;
        nextButton.interactable = false;

        if (currentQuestionIndex == questions.Length - 1)
            nextButton.GetComponentInChildren<TextMeshProUGUI>().text = "Finish!";
        else
            nextButton.GetComponentInChildren<TextMeshProUGUI>().text = "Next";

        Question q = questions[currentQuestionIndex];
        questionText.text = q.questionText;
        progressText.text = $"Question {currentQuestionIndex + 1} / {questions.Length}";

        AnimateProgressBar(currentQuestionIndex);

        for (int i = 0; i < answerOptions.Length; i++)
        {
            var option = answerOptions[i];

            int index = i;

            option.answerButton.interactable = true;
            option.answerButton.image.color = Color.white;
            option.answerButton.onClick.RemoveAllListeners();
            option.answerButton.onClick.AddListener(() => OnAnswerSelected(index));

            option.playButton.onClick.RemoveAllListeners();
            option.playButton.onClick.AddListener(() => PlayAudio(index));

            if (q.isAudioQuestion)
            {
                // Set answer text to indicate audio
                option.answerButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Play Audio {i + 1}";

                // Assign audio clip dynamically
                if (q.answerAudioClips != null && i < q.answerAudioClips.Length)
                    option.audioSource.clip = q.answerAudioClips[i];
                else
                    option.audioSource.clip = null;

                option.playButton.gameObject.SetActive(true);
            }
            else
            {
                // Regular text answer
                option.answerButton.GetComponentInChildren<TextMeshProUGUI>().text = q.answers[i];

                // Hide play button if not audio
                option.playButton.gameObject.SetActive(false);

                // Optionally clear audio
                option.audioSource.clip = null;
            }
        }


    }


    void OnAnswerSelected(int selectedIndex)
    {
        if (answered) return;
        answered = true;

        Question q = questions[currentQuestionIndex];

        for (int i = 0; i < answerOptions.Length; i++)
        {
            answerOptions[i].answerButton.interactable = false;
            if (i == q.correctAnswerIndex)
                answerOptions[i].answerButton.image.color = new Color32(167, 255, 66, 255);
            else if (i == selectedIndex)
                answerOptions[i].answerButton.image.color = new Color32(255, 126, 71, 255);
        }

        if (selectedIndex == q.correctAnswerIndex)
        {
            correctAnswers++;
        }

        nextButton.interactable = true;
        if (currentQuestionIndex == questions.Length - 1)
            AnimateProgressBar(questions.Length);
    }

    public GameObject quizEndPanel;

    void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex >= questions.Length)
        {
            quizPanel.SetActive(false);
            if (quizEndPanel != null)
            {
                quizEndPanel.SetActive(true);
                float scorePercent = (float)correctAnswers / questions.Length;
                bool passed = scorePercent >= 0.75f;

                if (scorePercent >= 0.75f)
                {
                    int nextLevel = quizLevel + 1;
                    string key = quizType.ToString() + "_UnlockedLevel";

                    int currentUnlocked = PlayerPrefs.GetInt(key, 1); // defaults to level 1 unlocked

                    if (nextLevel > currentUnlocked)
                        PlayerPrefs.SetInt(key, nextLevel);
                }

                TextMeshProUGUI scoreText = quizEndPanel.transform.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
                if (scoreText != null)
                    scoreText.text = $"You scored {(scorePercent * 100):F0}%";

                // Optionally display the score
                Debug.Log($"Quiz finished! Score: {scorePercent * 100}%");

                // Enable/disable Main Menu button based on score
                Button menuButton = quizEndPanel.transform.Find("MainMenuButton").GetComponent<Button>();
                if (menuButton != null)
                    menuButton.interactable = passed;
            }
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

    // ========== RAAG LEVEL QUESTION BANKS ==========

    Question[] GetRaagLevel1Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "What is the definition of Raag?",
                answers = new string[] {
                    "A set of notes ascending and descending a scale that provoke a specific emotion.",
                    "A style of Indian Classical music performed at festivals.",
                    "A sequence of notes used in Kirtan without any structure.",
                    "A Tanti Saaj used in Kirtan to evoke certain emotions."
                },
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
                answers = new string[] { "Varjit Surs", "Vakrit Surs", "Vadi", "Samvadi" },
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
                answers = new string[] { "Shree, Maajh, Gauri, Asa, Gujri", "Asa, Nat Narayan, Todi, Malhaar, Basant", "Asa, Basant, Bhairav, Bilawal, Devgandhari", "Basant, Asa, Sarang, Bilwal, Malhaar" },
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
                answers = new string[] { "Samvadi", "Vadi", "Thaat", "Jaati" },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "What is the definition of a Thaat",
                answers = new string[] { "A parent scale or framework of notes used to classify Raags", "A specific Raag performed at a particular time of day", "A rhythmic cycle used to accompany vocal and instrumental music", "A type of musical instrument used in Gurmat Sangeet" },
                correctAnswerIndex = 0
            }
        };
    }
    Question[] GetRaagLevel2Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "What is the Aroh of Raag Bilaval",
                answers = new string[] {
                    "Sa Re Ga Ma Pa Dha Ni Sa'",
                    "Sa Ga Ma Pa Ni Sa'",
                    "Sa re ga ma dha ni Sa'",
                    "Sa Re Ma Ga Pa Sa'"
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "What kind of Surs are used in Raag Bilval?",
                answers = new string[] { "All Teevar", "All Komal", "All Shudh", "Komal and Teevar" },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What is the mood of Raag Bilaval?",
                answers = new string[] { "Sad", "Mysterious", "Devotional", "Joyful and Happy" },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What is the Avroh of Raag Bilaval?",
                answers = new string[] { "Sa' Ni Dha Pa Ma Ga Re Sa", "Sa' Dha Ma Pa Ga Re Sa", "Sa' Ni Dha Pa Ga Re Sa", "Sa Re Ga Pa Dha Sa'" },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "What is the Vadi of Raag Bilaval?",
                answers = new string[] { "Ga", "Pa", "Ni", "Ma" },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "What is the Samvadi of Raag Bilaval?",
                answers = new string[] { "Sa", "Dha", "Ni", "Pa" },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = " What time is Raag Bilaval sung",
                answers = new string[] { "3pm-6pm", "1pm-4pm", "6pm-9pm", "9am-12pm" },
                correctAnswerIndex = 3
            }
        };
    }
    Question[] GetRaagLevel3Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "What is the Avroh of Raag Gond?",
                answers = new string[] {
                    "Sa' ni Dha Pa ma ga Re sa",
                    "Sa' Ni Dha Ni Pa Ma Ga Re Sa",
                    "Sa' Dha Pa Ga Sa",
                    "ni dha Pa ma Ga Re Sa"
                },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "What kind of notes are used in Raag Gond?",
                answers = new string[] { "All Shudh", "All Komal", "All Teevar", "Komal and Teevar" },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "What is the Jaati of Raag Gond?",
                answers = new string[] { "Audav-Shaudav", "Audav", "Shaudav-Sampooran", "Sampooran Jaati" },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What is the Vadi of Raag Gond?",
                answers = new string[] { "Ga", "Ni", "Ma", "Pa" },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What is the Samvadi of Raag Gond?",
                answers = new string[] { "Sa", "Dha", "Ni", "Pa" },
                correctAnswerIndex = 0
            },
             new Question
            {
                questionText = "What is the Aroh of Raag Gond?",
                answers = new string[] { "Sa Ma Dha Ni", "Sa Re Ga Ma Pa Dha Ni Sa'", "Sa Re Ga Ma Pa Dha Ni Dha Ni Sa'", "Sa re Ga ma Pa dha Ni Sa'" },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What time is Raag Gond sung?",
                answers = new string[] { "3pm-6pm", "9am-12pm", "1pm-4pm", "6pm-9pm" },
                correctAnswerIndex = 1
            }
        };
    }
    Question[] GetRaagLevel4Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "What is the Aroh of Raag Basant?",
                answers = new string[] {
                    "Sa Ga Ma Dha Ni Sa'",
                    "Sa Re Ga Ma Pa Dha Ni Sa'",
                    "Sa Re Ma Pa Dha Sa'",
                    "Sa re ga Ma Pa dha Ni Sa'"
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "What time is Raag Basant sung?",
                answers = new string[] { "Fall", "12pm-3pm", "Spring", "6pm-9pm" },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What is the Jaati of Raag Basant?",
                answers = new string[] { "Audav-Shaudav", "Audav-Sampooran", "Shaudav-Sampooran", "Audav Jaati" },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "What is the Vadi of Raag Basant?",
                answers = new string[] { "Sa", "Ga", "Ni", "Pa" },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "What commonly heard Baani is under Raag Basant?",
                answers = new string[] { "Ardaas", "Basant Mehla Pehla", "Anand Sahib", "Basant Ki Vaar" },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What is the Avroh of Raag Basant?",
                answers = new string[] {
                    "Sa' Ni Dha Pa Ma Ga Re Sa",
                    "Sa' Dha Ma Ga Re Sa",
                    "Sa' Ni Dha Pa ma ga re Sa",
                    "Sa' ni dha ma ga re Sa"
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "What number Raag is Raag Basant?",
                answers = new string[] { "1st", "25th", "31st", "27th" },
                correctAnswerIndex = 1
            }
        };
    }
    Question[] GetRaagLevel5Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "What is the Samvadi of Raag Kalyan?",
                answers = new string[] {
                    "Sa",
                    "Re",
                    "Ni",
                    "Ma"
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What time is Raag Kalyan sung?",
                answers = new string[] { "Summer", "Early Morning", "12pm-3pm", "6pm-9pm" },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What is the Mishrat form of Raag Kalyan?",
                answers = new string[] { "Kalyam Bhupali", "Kalyan Maajh", "Kalyan Dakhani", "Kalyan Hindol" },
                correctAnswerIndex = 0
            },
             new Question
            {
                questionText = "What is the Avroh of Raag Kalyan?",
                answers = new string[] { "Sa' Dha Pa Ma Ga Re Sa", "Sa' Ni Pa Ga Sa", "Sa' Ni Dha Pa ma Ga Re Sa", "Sa' Ma Re Ga Sa" },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What is the Thaat of Raag Kalyan",
                answers = new string[] { "Asavari", "Kalyan", "Bilaval", "Todi" },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "What is the name of the Indian Classical version of Raag Kalyan?",
                answers = new string[] { "Raag Bmhimpilasi", "Raag Basant", "Raag Yaman", "Raag Khamaj" },
                correctAnswerIndex = 3
            },
             new Question
            {
                questionText = "What is the Aroh of Raag Kalyan?",
                answers = new string[] { "Sa Re Ga ma Pa Dha Ni Sa'", "Sa Ga Ma Pa Dha Ni Sa'", "Sa re Ma Pa Ni Dha Sa'", "Sa Re Ga Ma Pa Dha Sa'" },
                correctAnswerIndex = 0
            },
        };
    }
    Question[] GetRaagLevel6Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "What is the Thaat of Raag Maaroo",
                answers = new string[] {
                    "Bilaval",
                    "Todi",
                    "Bhairvi",
                    "Khamaaj"
                },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "When is Raag Maaroo sung?",
                answers = new string[] { "In times of War and Death", "During Marriage", "During Battle", "In times of Death" },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "What is the Vadi of Raag Maaroo?",
                answers = new string[] { "Sa", "Ga", "Todi", "Pa" },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "How many mishrat raags does Raag Maaroo have?",
                answers = new string[] { "0", "10", "1", "2" },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What is the Aroh of Raag Maaroo?",
                answers = new string[] { "Sa Ga Ma Pa Dha Ni Sa'", "Sa Re Ga Ma Pa Dha Ni Sa'", "Sa Ga Ma Pa Dha Sa'", "Sa ga ma Pa dha Ni Sa'" },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "What is the Jaati of Raag Maaroo?",
                answers = new string[] { "Shaudav Jaati", "Sampooran Jaati", "Shaudav-Sampooran", "Audav-Shaudav" },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What is the Avroh of Raag Maaroo?",
                answers = new string[] { "Sa' ni Dha Pa, ma Pa Dha ni Dha Pa, Ma Ga Re Sa", "Sa' ni Dha Pa, ma Pa dha Ni dha Pa, Ma Ga Re Sa", "Sa' Dha Pa Ga Re Sa", "Sa' Ni Dha Pa Ma Ga Re Sa" },
                correctAnswerIndex = 1
            }
        };
    }
    Question[] GetRaagLevel7Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "What is the Avroh of Shree Raag?",
                answers = new string[] {
                    "Sa' dha Pa ga re sa",
                    "Sa' Ni Dha Pa Ma Ga Re Sa",
                    "Sa re ma Pa Ni Sa'",
                    "Sa' Ni dha pa ma Ga re Sa"
                },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "When is Shree Raag sung?",
                answers = new string[] { "10am-1pm", "6pm-9pm", "Morning", "Midnight" },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "What is the Samvadi of Shree Raag?",
                answers = new string[] { "Pa", "Sa", "Ga", "Ma" },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "How many Mishrat Raags does Shree Raag have?",
                answers = new string[] { "11", "2", "0", "1" },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What is the Thaat of Shree Raag?",
                answers = new string[] { "Shree", "Bilaval", "Khamaaj", "Poorvi" },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What is the emotion of Shree Raag?",
                answers = new string[] { "Devotion", "Joy", "Sadness", "Anger" },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "What is the Aroh of Shree Raag",
                answers = new string[] { "Sa re Ma Pa Ni Sa'", "Sa Re Ga Pa Dha Sa'", "Sa Ma Pa Dha Ni Sa'", "Sa re ma Pa Ni Sa'" },
                correctAnswerIndex = 3
            }
        };
    }
    Question[] GetRaagLevel8Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "What is the Aroh of Raag Todi?",
                answers = new string[] {
                    "Sa re ga ma, Pa, ma dha Ni Sa'",
                    "Sa Ga Ma Pa Ni Sa'",
                    "Sa ga ma, Pa, ma dha ma Pa Ni Sa'",
                    "Sa' Ni dha pa ma Ga re Sa"
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "What is the Thaat of Raag Todi?",
                answers = new string[] { "Marva", "Bhairav", "Bilaval", "Todi" },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What is the Vadi of Raag Todi?",
                answers = new string[] { "ma", "dha", "Ga", "Sa" },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "What is the Avroh of Raag Todi?",
                answers = new string[] { "Sa' Ni dha, Pa, ma dha ma ga re Sa", "Sa' Dha Ma Re Sa", "Sa' Ni Dha Pa Ma Ga Re Sa", "Sa' ni dha Pa ma Ga re Sa" },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What is the emotion of Raag Todi?",
                answers = new string[] { "Calming", "Devotion", "Serious", "Uplifting" },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What time is Raag Todi Sung??",
                answers = new string[] { "6pm-9pm", "9am-6pm", "3am-12pm", "Dawn" },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "What is the Samvadi of Raag Todi?",
                answers = new string[] { "dha", "ga", "ma", "ni" },
                correctAnswerIndex = 1
            }
        };
    }
    Question[] GetRaagLevel9Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "What is the Avroh of Raag Sarang?",
                answers = new string[] {
                    "Sa' ni Dha Pa Ma Ga Re Sa",
                    "Sa Ga Ma Pa Ni Sa'",
                    "Sa' ni Pa Ma Re Sa.",
                    "Sa' Ni dha pa ma Ga re Sa"
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What is the Jaati of Raag Sarang?",
                answers = new string[] { "Shaudav-Sampooran", "Audav-Sampooran", "Sampooran Jaati", "Audav Jaati" },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What is the Samvadi of Raag Sarang?",
                answers = new string[] { "Re", "Pa", "Sa", "Ma" },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "What time is Raag Sarang sung?",
                answers = new string[] { "12pm-3pm", "6am-9am", "10am-11am", "12pm-3am" },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "What is the Vadi of Raag Sarang?",
                answers = new string[] { "Ma", "Sa", "Pa", "Re" },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What note has both forms used in Raag Sarang?",
                answers = new string[] { "Sa", "Ni", "Ga", "Ma" },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "What is the Aroh of Raag Sarang?",
                answers = new string[] { "Sa Ga Ma Pa Ni Sa'", "Sa Re Pa Dha Ni Sa'", "Sa Re Ma Pa Ni Sa'", "sa, re ga ma, re pa Ni dha ni sa'" },
                correctAnswerIndex = 2
            }
        };
    }
    Question[] GetRaagLevel10Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "What is the Aroh of Raag Malhaar?",
                answers = new string[] {"Sa Re Ga Ma Pa ni Dha Ni Sa'", "Sa Re Pa Dha Ni Sa'", "Sa, Re Ga Ma, Re Pa ni Dha Ni Sa'", "sa, re ga ma, re pa Ni dha ni sa'"},
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What is the Jaati of Raag Malhaar?",
                answers = new string[] { "Shaudav-Sampooran", "Audav-Sampooran", "Audav Jaati", "Sampooran Jaati" },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What is the Samvadi of Raag Malhaar?",
                answers = new string[] { "Sa", "Pa", "Ni", "Ma" },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "What time is Raag Malhaar sung?",
                answers = new string[] { "Summer", "Rainy Season", "Snowy Season", "6am-9am" },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "What is the Vadi of Raag Malhaar?",
                answers = new string[] { "ni", "Sa", "Ma", "Dha" },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What note has both forms used in the Avroh of Raag Malhaar?",
                answers = new string[] { "Ni", "Ni", "Ga", "Ma" },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "What is the Avroh of Raag Sarang?",
                answers = new string[] { "Sa Re Ga Ma Pa ni Dha Ni Sa'", "Sa' Dha Pa Ga Re Sa", "Sa' Ni Dha ni Pa Ma Ga Re Sa", "Sa' Dha ni Pa, Ga Ma Re Sa" },
                correctAnswerIndex = 3
            }
        };
    }
    Question[] GetRaagLevel11Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "What is the Aroh of Raag Bhairo?",
                answers = new string[] {
                    "Sa ni DHa Pa Ma Ga Re Sa",
                    "Sa Ga Ma Pa Ni Sa'",
                    "Sa re Ga Ma Pa dha Ni Sa'",
                    "Sa' Ni dha pa ma Ga re Sa"
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What is the Jaati of Raag Bhairo",
                answers = new string[] { "Shaudav-Sampooran", "Audav-Sampooran", "Audav Jaati", "Sampooran Jaati" },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What is the Thaat of Raag Bhairo?",
                answers = new string[] { "Bilval", "Bhairv", "Kalyan", "Bhairavi" },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "What time is Raag Bhairo sung?",
                answers = new string[] { "6am-9am", "12am-3pm", "10pm-11am", "12pm-3pm" },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "How many Mishrat Raags does Raag Bhairo have?",
                answers = new string[] { "1", "3", "0", "2" },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What is the Aroh of Raag Bhairo?",
                answers = new string[] { "Sa Re Ga ma Pa Dha Ni Sa'", "sa Re Ga Ma pa Dha Ni sa'", "Sa Re Ga Ma Pa Dha Ni Sa'", "Sa re Ga Ma Pa dha Ni Sa'" },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What is the Vadi of Raag Bhairo?",
                answers = new string[] { "re", "dha", "ma", "ga" },
                correctAnswerIndex = 1
            }
        };
    }




    // ========== SUR LEVEL QUESTION BANKS ==========

    Question[] GetSurLevel1Questions()
    {
        return new Question[]
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
            }
        };
    }
    Question[] GetSurLevel2Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            }
        };
    }
    Question[] GetSurLevel3Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            }
        };
    }
    Question[] GetSurLevel4Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            }
        };
    }
    Question[] GetSurLevel5Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            }
        };
    }
    Question[] GetSurLevel6Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            }
        };
    }
    Question[] GetSurLevel7Questions()
    {
        return new Question[]
        {
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "",
                answers = new string[] {
                    "",
                    "",
                    "",
                    ""
                },
                correctAnswerIndex = 0
            }
        };
    }


    public void PlayAudio(int index)
    {
        // Stop all other audio sources
        for (int i = 0; i < answerOptions.Length; i++)
        {
            if (i != index && answerOptions[i].audioSource != null)
            {
                answerOptions[i].audioSource.Stop();
            }
        }

        if (index >= 0 && index < answerOptions.Length)
        {
            AudioSource source = answerOptions[index].audioSource;

            if (source != null && source.clip != null)
            {
                source.Play();
            }
            else
            {
                Debug.LogWarning($"No audio clip found for answer index {index}");
            }
        }
    }

}

[System.Serializable]
public class Question
{
    public string questionText;
    public string[] answers;
    public int correctAnswerIndex;

    public bool isAudioQuestion;
    public AudioClip[] answerAudioClips;
}

[System.Serializable]
public class AnswerOption
{
    public Button answerButton;
    public Button playButton;
    public AudioSource audioSource;
}


