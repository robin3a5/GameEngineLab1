using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class GameController : MonoBehaviour
{
    public Text timeRemainingDisplayText;
    public GameObject questionDisplay;
    public GameObject roundOverDisplay;

    public Text scoreDisplayText;
    public Transform answerButtonParent;
    public Text questionText;
    public SimpleObjectPool answerButtonObjectPool;
    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;
        UpdateTimeRemainingDiplay();
        playerScore = 0;
        questionIndex = 0;
        ShowQuestion();
        isRoundActive = true;
    }

    private void ShowQuestion(){
        RemoveAnswerButtons();
        QuestionData questionData = questionPool[questionIndex];
        questionText.text = questionData.questionText;
        for(int i = 0; i < questionData.answers.Length; i++){
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            answerButtonGameObjects.Add(answerButtonGameObject);
            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
        }
    }
    private void RemoveAnswerButtons(){
        while(answerButtonGameObjects.Count > 0){
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect){
        if(isCorrect){
            playerScore+= currentRoundData.pointsAddedForCorrectAnswer;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
        }
        if(questionPool.Length > questionIndex + 1){
            questionIndex ++;
            ShowQuestion();
        }
        else{
            EndRound();
        }
    }

    public void EndRound(){
        isRoundActive = false;
        questionDisplay.SetActive(false);
        roundOverDisplay.SetActive(true);
    }

    public void ReturnToMenu(){
        SceneManager.LoadScene("MenuScreen");
    }
    private void UpdateTimeRemainingDiplay(){
        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if(isRoundActive){
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDiplay();

            if (timeRemaining <=0)
            {
                EndRound();
            }
        }
    }
}
