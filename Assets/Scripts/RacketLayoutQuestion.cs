using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacketLayoutQuestion : MonoBehaviour
{
    public bool answered;

    private List<RacketLayoutChoiceButton> _ChoiceButtons = new List<RacketLayoutChoiceButton>();
    public List<GameObject> choice1;
    public List<GameObject> choice2;
    public List<GameObject> choice3;

    private Condition _QuestionCondition = Condition.NoConditionSetYet;
    private RacketLayoutQuestionController _Controller;
    private RacketLayoutExtraEffect _ExtraEffect;

    private void Awake()
    {
        _Controller = transform.parent.GetComponent<RacketLayoutQuestionController>();
        _ExtraEffect = transform.GetComponent<RacketLayoutExtraEffect>();
    }
    private void Start()
    {
        ClearChoices(); ;
    }

    public void AddButton(RacketLayoutChoiceButton button)
    {
        _ChoiceButtons.Add(button);
    }
    public void ClearOtherSelectedButtons(RacketLayoutChoiceButton button)
    {
        foreach (var item in _ChoiceButtons)
        {
            if (item != button)
                item.SetUnselected();
        }
    }
    public void OnButtonChoiceClick(Condition condition)
    {
        _QuestionCondition = condition;

        // Reset choices state
        ClearChoices();

        SetChoices();

        // If extra effect scripts are added to gameobject, they activate now
        if (_ExtraEffect)
            _ExtraEffect.OnClickEffect();

        _Controller.RefreshLayoutGroup();

        // Check all answeres
        _Controller.CheckIfAllQuestionsAreAnswered();
    }

    private void ClearChoices()
    {
        foreach (var item in choice1)
        {
            item.SetActive(false);
        }
        foreach (var item in choice2)
        {
            item.SetActive(false);
        }
        foreach (var item in choice3)
        {
            item.SetActive(false);
        }

    }
    private void SetChoices()
    {
        switch (_QuestionCondition)
        {
            case Condition.ConditionOne:
                foreach (var item in choice1)
                {
                    item.SetActive(true);
                }
                break;
            case Condition.ConditionTwo:
                foreach (var item in choice2)
                {
                    item.SetActive(true);
                }
                break;
            case Condition.ConditionThree:
                foreach (var item in choice3)
                {
                    item.SetActive(true);
                }
                break;
            default:
                break;
        }
    }

    private void OnEnable()
    {
        if (!answered)
            ClearChoices();
        if (answered)
            SetChoices();
    }

    public void ResetQuestion()
    {
        answered = false;

        foreach (var item in _ChoiceButtons)
        {
            item.SetUnselected();
        }
    }
    public Condition GetCurrentCondition() => _QuestionCondition;
}