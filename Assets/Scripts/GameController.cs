using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI _text;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI countdownText;
    public TMP_InputField inputField;
    public Button verifyButton;

    private int randomNumber;
    private int lives = 3;
    private int currentLives;

    public float countdownTime = 5f;

    void Start()
    {
        StartGame();
        currentLives = lives;
        UpdateCountdownText();
        InvokeRepeating("UpdateTimer", 1f, 1f);
    }

    void StartGame()
    {
        randomNumber = Random.Range(1, 11);
        lives = 3;
        _text.text = "Guess the number (between 1 and 10).";
        
        livesText.text = "Remaining attempts: " + lives;    
        verifyButton.interactable = true;
        inputField.text = "";
    }

    public void VerifyNumber()
    {
        int tries;
        //convert string to int
        if (int.TryParse(inputField.text, out tries))
        {
            if (tries == randomNumber)
            {
                _text.text = "Correct! You guessed the number.";
                verifyButton.interactable = false;

                CancelInvoke("UpdateTimer");
            }
            else
            {
                currentLives--;
                if (currentLives > 0)
                {
                    _text.text = "Incorrect number.";
                    livesText.text = "Remaining attempts:" + currentLives;
                    countdownTime = 5f;
                }
            }
        }
        else
        {
            _text.text = "Please enter a valid number.";
            countdownTime = 5f;
            UpdateCountdownText();
        }
    }

    void UpdateTimer()
    {
        if (countdownTime > 0)
        {
            countdownTime -= 1f;
            UpdateCountdownText();            
        }
        else
        {
            countdownTime = 0;
            LoseLife();
        }
    }

    void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            livesText.text = "Remaining attempts:" + currentLives;
        }

        if (currentLives <= 0)
        {
            _text.text = "You lost! The correct number was: " + randomNumber + ".";
            verifyButton.interactable = false;
            currentLives = 0;
        }
        else
        {
            //restart timer and continue
            countdownTime = 5f;
        }
    }
    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(countdownTime / 60f);
        int seconds = Mathf.FloorToInt(countdownTime % 60f);
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        countdownText.text = formattedTime;
    }

    void RestartGame()
    {
        currentLives = lives;  
        countdownTime = 5f;
        StartGame();
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
