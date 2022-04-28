using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacketLayoutQuestionController : MonoBehaviour
{
    private RacketLayoutQuestion[] _Questions;
    private VerticalLayoutGroup _LayoutGroup;
    public Scrollbar scrollbar;
    public RacketLayoutButton button;

    private void Awake()
    {
        _Questions = transform.GetComponentsInChildren<RacketLayoutQuestion>();
        _LayoutGroup = GetComponent<VerticalLayoutGroup>();
    }

    public void CheckIfAllQuestionsAreAnswered()
    {
        foreach (var item in _Questions)
        {
            if (item.gameObject.activeSelf)
                if (!item.answered)
                {
                    button.SetUncomplete();
                    return;
                }
        }

        button.SetCompleted();
    }

    public void RefreshLayoutGroup()
    {
        StartCoroutine(RefreshLayoutGroupCoroutine());
    }

    private IEnumerator RefreshLayoutGroupCoroutine()
    {
        var value = scrollbar.value;

        yield return new WaitForEndOfFrame();
        _LayoutGroup.enabled = false;
        scrollbar.value = value;

        yield return null;

        scrollbar.value = value;
        _LayoutGroup.enabled = true;
        yield return new WaitForEndOfFrame();
        scrollbar.value = value;
    }
}
