using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System;

public class compareMems : MonoBehaviour
{
    int testing;
    public InputField field;
    public GameObject button;
    public Text totalCountText;
    int count = 0;
    public bool isNew;
    int totalQuestionsCount = 5;
    public Text clockText;
    public Text question;
    public Text points;
    int currientPoints = 100;
    public VideoPlayer VideoWaiting;
    public VideoPlayer VideoSuccess;
    public VideoPlayer VideoUnfortune;
    public GameObject SquareWaiting;
    public GameObject SquareSuccess;
    public GameObject SquareUnfortune;
    public GameObject SquareHint;
    public GameObject HelpVkladka;
    public GameObject HelpTxt;
    public GameObject ClockTxt;
    public GameObject Chasy;
    bool isPlayWaiting;
    bool isPlaySuccess;

    // Start is called before the first frame update
    void Start()
    {
        totalCountText.text = $"{count}/{totalQuestionsCount}";
        SquareWaiting.SetActive(true);
        SquareSuccess.SetActive(false);
        SquareUnfortune.SetActive(false);
        SquareHint.SetActive(false);
        if (isPlayWaiting)
            VideoWaiting.Pause();
        else
            VideoWaiting.Play();
        isPlayWaiting = !isPlayWaiting;
    }

    public void Change()
    {
        if (!isNew)
            return;
        var input = field.text;
        try
        {
            var abc = input.Split('/');
            testing++;
            var res = 1.0 * Convert.ToInt32(abc[0]) / Convert.ToInt32(abc[1]);
            testing++;
            if (Math.Round(button.GetComponent<mem>().probability, 3) == Math.Round(res, 3))
            {
                field.text = "";
                isNew = false;
                count++;
                if (count == totalQuestionsCount)
                {
                    clockText.GetComponent<clock>().isStarted = false;
                    question.text = "";
                    count = 0;
                    totalCountText.text = "";
                    if (currientPoints <= 40)
                        points.text = "40/100";
                    else
                        points.text = $"{currientPoints}/100";
                    SquareWaiting.SetActive(false);
                    SquareSuccess.SetActive(true);
                    SquareUnfortune.SetActive(false);
                    SquareHint.SetActive(false);
                    HelpVkladka.SetActive(false);
                    HelpTxt.SetActive(false);
                    ClockTxt.SetActive(false);
                    Chasy.SetActive(false);
                    if (isPlaySuccess)
                        VideoSuccess.Pause();
                    else
                        VideoSuccess.Play();
                    isPlaySuccess = !isPlaySuccess;
                    return;
                }
                else
                    button.GetComponent<mem>().MakeNew();
                totalCountText.text = $"{count}/{totalQuestionsCount}";
            }
            else
            {
                field.text = "Неверно(";
                currientPoints -= 5;
                SquareWaiting.SetActive(false);
                SquareSuccess.SetActive(false);
                SquareUnfortune.SetActive(true);
                SquareHint.SetActive(false);
                VideoUnfortune.Play();
            }
        }
        catch (Exception)
        {
            field.text = testing.ToString();
            return;
        }
    }

}
