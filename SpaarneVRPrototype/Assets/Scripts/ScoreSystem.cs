using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{

    public class Step
    {
        public int id;
        public bool completed = false;
        public float timeForStep = 0;

        public Step(int identifier)
        {
            id = identifier;
        }
    }

    [Header("Player Data")]
    public FailureCounter data;

    [Header("Quest settings")]
    public QuestOne questOne;
    private bool questCompleted = false;

    [Header("Timer settings")]
    private float timePerTask = 20f;
    private Timer scoreTimer;
   // private bool timerSet = false;

    [Header("step settings")]
    public int currentStep = 0;
    public int finalStep;

    [Header("Score settings")]
    public float timesFailed = 0;
    private float finalScore = 0;


    public List<bool> steps;

    public List<Step> stepList = new List<Step>();

    void Start()
    { 
        // create profile for the one playing otherwise
        // load profile that created
        timesFailed = data.counter;
        scoreTimer = new Timer();
        steps = questOne.questSteps;
        GenerateList(questOne.questSteps);
        InvokeTimer();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            ResetKnop();
        }

        CurrentStep();
        scoreTimer.Update();
    }

    private void GenerateList(List<bool> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Step x = new Step(i);
            stepList.Add(x);
        }

        finalStep = list.Count-1;
        Debug.Log("steps in the quest: " + stepList.Count);
    }

    private void CurrentStep()
    {
        if (questCompleted) return;

        if (questOne)
        {
            steps = questOne.questSteps;
        }

        if (steps[currentStep])
        {
            if (currentStep == finalStep)
            {
                scoreTimer.TimerStop();
                Step test = stepList.Find(Step => Step.id == finalStep);
                test.timeForStep = scoreTimer.GetTime();
                CalculateFinalScore();
            }
            if (currentStep == 0)
            {
                scoreTimer.TimerStop();
                Step test = stepList.Find(Step => Step.id == currentStep);
                Debug.Log(test);
                test.timeForStep = scoreTimer.GetTime();
                currentStep++;
                Invoke("InvokeTimer", .1f);
            }
            else if (currentStep > 0 && steps[currentStep - 1])
            {

                if (currentStep < finalStep)
                {
                    scoreTimer.TimerStop();
                    Step test = stepList.Find(Step => Step.id == currentStep);
                    test.timeForStep = scoreTimer.GetTime();
                    currentStep++;
                    Invoke("InvokeTimer", .1f);
                }
            }
        }

        if (currentStep > 0 && !steps[currentStep - 1])
        {
            currentStep--;
        }

    }

    public void ResetKnop()
    {
        // failure += 1;
        SceneManager.LoadScene(1);
        data.counter += 1;
    }

    private void CalculateFinalScore()
    {
        questCompleted = true;
        foreach (Step s in stepList)
        {
            float score = 1000 / s.timeForStep;
            finalScore += score;
        }

        finalScore -= (timesFailed * 5);
        Debug.Log("Final score is: " + finalScore);
    }

    private void InvokeTimer()
    {
        scoreTimer.TimerStart();
    }

    public class Timer : MonoBehaviour
    {
        private bool isRunning = false;
        private float currentTime = 0;

        public void TimerStart()
        {
            isRunning = true;
            currentTime = 0;
        }

       public void Update()
        {
            if (!isRunning) return;
            currentTime += 1 * Time.deltaTime;
        }

        public void TimerStop()
        {
            isRunning = false;   
        }

        public float GetTime()
        {
            Debug.Log("time taken for this step: " + currentTime);
            return currentTime;
        }
    }



}


