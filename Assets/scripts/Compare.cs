using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System;

public class Compare : MonoBehaviour
{
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
    public VideoPlayer VPlayer1;
    public VideoPlayer VPlayer2;
    public VideoPlayer VPlayer3;
    public GameObject Square;
    public GameObject Square2;
    public GameObject Square3;
    bool isPlay1;
    bool isPlay2;
    bool isPlay3;

    // Start is called before the first frame update
    void Start()
    {
        totalCountText.text = $"{count}/{totalQuestionsCount}";
        Square.SetActive(true);
        Square2.SetActive(false);
        Square3.SetActive(false);
        if (isPlay1)
            VPlayer1.Pause();
        else
            VPlayer1.Play();
        isPlay1 = !isPlay1;
    }

    public void Change()
    {
        if (!isNew)
            return;
        var input = field.text;
        try
        {
            var abc = input.Split('/');
            var res = 1.0 * Convert.ToInt32(abc[0]) / Convert.ToInt32(abc[1]);
            if (Math.Round(button.GetComponent<money>().probability, 3) == Math.Round(res, 3))
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
                    Square.SetActive(false);
                    Square2.SetActive(true);
                    Square3.SetActive(false);
                    if (isPlay2)
                        VPlayer2.Pause();
                    else
                        VPlayer2.Play();
                    isPlay2 = !isPlay2;
                    return;
                }
                else
                    button.GetComponent<money>().MakeNew();
                totalCountText.text = $"{count}/{totalQuestionsCount}";
            }
            else
            {
                field.text = "Неверно(";
                currientPoints -= 5;
                Square.SetActive(false);
                Square2.SetActive(false);
                Square3.SetActive(true);
                if (isPlay3)
                    VPlayer3.Pause();
                else
                    VPlayer3.Play();
            }
        }
        catch (Exception)
        {
            return;
        }
    }

}
