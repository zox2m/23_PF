using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameManager : MonoBehaviour
{
    [SerializeField] protected List<Button> buttons;
    [SerializeField] protected List<TMP_Text> texts;
    [SerializeField] protected Color changeColor;
    [SerializeField] protected TMP_Text stateText;
    private float _colorChangeDuration = 1;
    private int _patternLength = 4; 
    private int _patternIndex = 0;
    private List<Button> _pattern = new List<Button>();
    private bool _isPlayerTurn = false;

    public void Start()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
        StartCoroutine(ShowPattern());
    }

    public IEnumerator ShowPattern()
    {
        stateText.text = "순서를 잘 기억하세요";
        foreach (var element in texts)
        {
            element.gameObject.SetActive(false);
        }
        _pattern.Clear();
        foreach (var element in texts)
        {
            element.gameObject.SetActive(true);
            element.text = "X";
            Button selectedButton = GetRandomButton();
            _pattern.Add(selectedButton);
            selectedButton.image.color = changeColor;
            yield return new WaitForSeconds(_colorChangeDuration);
            selectedButton.image.color = Color.white;
            yield return new WaitForSeconds(_colorChangeDuration / 2);
        }
        stateText.text = "순서대로 버튼을 클릭하세요";
        _isPlayerTurn = true;
    }

    public void OnButtonClick(Button clickedButton)
    {
        if (_isPlayerTurn)
        {
            if (_pattern[_patternIndex] == clickedButton)
            {
                texts[_patternIndex].text = "O";
                _patternIndex++;
                if (_patternIndex >= _patternLength)
                {
                    _isPlayerTurn = false;
                    _patternIndex = 0;
                    StartCoroutine(ShowPattern());
                }
            }
        }
    }

    public Button GetRandomButton()
    {
        int randomIndex = Random.Range(0, buttons.Count);
        return buttons[randomIndex];
    }
}