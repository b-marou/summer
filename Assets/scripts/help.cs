using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class help : MonoBehaviour
{
    public GameObject button;
    public Text helpText;
    bool isPushed;
    public VideoPlayer WaitingVideo;
    public VideoPlayer HintVideo;
    public GameObject SquareWaiting;
    public GameObject SquareSuccess;
    public GameObject SquareUnfortune;
    public GameObject SquareHint;
    bool isPlayWaiting;
    bool isPlayHint;

    void OnMouseDown()
    {
        if (isPushed)
        {
            helpText.text = "";
            SquareWaiting.SetActive(true);
            SquareHint.SetActive(false);
            if (isPlayWaiting)
                WaitingVideo.Pause();
            else
                WaitingVideo.Play();
            if (isPlayHint)
                HintVideo.Pause();
            else
                HintVideo.Play();
            isPlayHint = !isPlayHint;
        }
        else
        {
            helpText.text = "Приветики! Меня зовут Джейс," +
                            " и я здесь для того, чтобы разрядить обстановку во время решения задач. Смотри, " +
                            "часы сверху показывают время, за которое ты решишь 5 задач (для запуска нажми на них). " +
                            "Вводи ответ в виде обыкновенной дроби!" +
                            "На белой закладке написано количество решенных задач. Нажми на красную, если хочешь " +
                            "вернуться в меню и выбрать другой тип задач. Удачки";
            SquareWaiting.SetActive(false);
            SquareSuccess.SetActive(false);
            SquareUnfortune.SetActive(false);
            SquareHint.SetActive(true);
        }
        isPushed = !isPushed;
    }
}
