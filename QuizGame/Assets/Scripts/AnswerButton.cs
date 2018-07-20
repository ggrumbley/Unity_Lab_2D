using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Text AnswerText;

    private AnswerData answerData;


    void Start()
    {

    }

    void Update()
    {

    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        AnswerText.text = answerData.answerText;
    }

}
