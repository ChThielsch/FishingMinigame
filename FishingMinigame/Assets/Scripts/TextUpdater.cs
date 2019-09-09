using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextUpdater : MonoBehaviour
{
    private TextMeshProUGUI m_TMPUGUI;

    private string text;
    //public string Text
    //{
    //    get { return text; }
    //    set
    //    {
    //        text = value;
    //        ReflectText(text);
    //    }
    //}

    private void Awake()
    {
        m_TMPUGUI = GetComponent<TextMeshProUGUI>();
    }

    //Plain Text
    public void ReflectText(string _text)
    {
        m_TMPUGUI.text = _text;
    }

    public void ReflectText(int _text)
    {
        m_TMPUGUI.text = _text.ToString();
    }

    public void ReflectText(float _text)
    {
        m_TMPUGUI.text = _text.ToString();
    }

    //Colored Text
    public void ReflectText(string _text, Color _color)
    {
        m_TMPUGUI.color = _color;
        ReflectText(_text);
    }

    public void ReflectText(int _text, Color _color)
    {
        ReflectText(_text.ToString(), _color);
    }

    public void ReflectText(float _text, Color _color)
    {
        ReflectText(_text.ToString(), _color);
    }

    //Colored32 Text
    public void ReflectText(string _text, Color32 _color)
    {
        m_TMPUGUI.color = _color;
        ReflectText(_text);
    }

    public void ReflectText(int _text, Color32 _color)
    {
        ReflectText(_text.ToString(), _color);
    }

    public void ReflectText(float _text, Color32 _color)
    {
        ReflectText(_text.ToString(), _color);
    }

    //Font Styled
    public void ReflectText(string _text, Color _color, FontStyles _fontStlye)
    {
        m_TMPUGUI.fontStyle = _fontStlye;
        ReflectText(_text, _color);
    }

    public void ReflectText(int _text, Color _color, FontStyles _fontStlye)
    {
        ReflectText(_text.ToString(), _color, _fontStlye);
    }

    public void ReflectText(float _text, Color _color, FontStyles _fontStlye)
    {
        ReflectText(_text.ToString(), _color, _fontStlye);
    }

    //Highlited Words
    public void ReflectText(string _text, Color _color, FontStyles _fontStyle, Color _highliteColor, params string[] _highlitedWords)
    {
        string hexColor = ColorUtility.ToHtmlStringRGBA(_highliteColor);
        foreach (string word in _highlitedWords)
        {
            string pattern = @"\w*" + word + @"\w*";
            _text = Regex.Replace(_text, pattern, "<color=#" + hexColor + ">" + word + "</color>");
        }

        ReflectText(_text, _color, _fontStyle);
    }

    public void ReflectText(int _text, Color _color, FontStyles _fontStyle, Color _highliteColor, params string[] _hightlightedWords)
    {
        ReflectText(_text.ToString(), _color, _fontStyle, _highliteColor, _hightlightedWords);
    }

    public void ReflectText(float _text, Color _color, FontStyles _fontStyle, Color _highliteColor, params string[] _hightlightedWords)
    {
        ReflectText(_text.ToString(), _color, _fontStyle, _highliteColor, _hightlightedWords);
    }
}
