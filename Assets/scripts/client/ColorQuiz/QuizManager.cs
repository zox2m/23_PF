using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ColorQuiz{
    public class QuizManager : SingletonMonobehaviour<QuizManager>
    {
        [SerializeField] private List<Color> colors;
        [SerializeField] private List<string> texts;
        [SerializeField] private List<Button> buttons;
        private TMP_Text _text;

        public void Start()
        {
            Debug.Log(colors.Count);
            Debug.Log(buttons.Count);
            Debug.Log(texts.Count);
            _text = GetComponent<TMP_Text>();
            foreach (var element in colors)
            {
                int temp = colors.IndexOf(element);
                buttons[temp].onClick.AddListener(() => OnClick(element));
                buttons[temp].GetComponentInChildren<TMP_Text>().text = texts[temp];
            }
            // for (int i = 0; i < buttons.Count; i++)
            // {
            //     buttons[i].GetComponentInChildren<TMP_Text>().text = texts[i];
            //     Debug.Log(colors[i]);
            //     buttons[i].onClick.AddListener(() => OnClick(colors[i]));
            // }
            StartQuiz();
        }

        void StartQuiz()
        {
            _text.text = texts[Random.Range(0, texts.Count)];
            _text.color = colors[Random.Range(0, colors.Count)];
        }

        IEnumerator Correct()
        {
            _text.text = "정답입니다!";
            _text.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            StartQuiz();
        }

        void OnClick(Color color)
        {
            if (_text.color == color)
            {
                StartCoroutine(Correct());
            }
        }
    }
}