using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageUpdater : MonoBehaviour
{
    private Image m_image;
    private Sprite sprite;
    //public Sprite Sprite
    //{
    //    get { return sprite; }
    //    set
    //    {
    //        sprite = value;
    //        ReflectImage(Sprite);
    //    }
    //}

    private void Awake()
    {
        m_image = GetComponent<Image>();
    }

    public void ReflectImage(Sprite _sprite)
    {
        m_image.sprite = _sprite;
        m_image.SetNativeSize();
        m_image.color = Color.white;
    }

    //Sprite + Size
    public void ReflectImage(Sprite _sprite, Vector2 _bounds)
    {
        ReflectImage(_sprite);
        RectTransform rectTransform = m_image.gameObject.gameObject.GetComponent<RectTransform>();
        m_image.rectTransform.sizeDelta = new Vector2(_bounds.x, _bounds.y);
    }

    //Sprite + Position
    public void ReflectImage(Sprite _sprite, int _posX, int _posY)
    {
        ReflectImage(_sprite);
        RectTransform rectTransform = m_image.gameObject.gameObject.GetComponent<RectTransform>();
        m_image.gameObject.gameObject.GetComponent<RectTransform>().position = new Vector3(_posX, _posY);
    }

    //Sprite + Color
    public void ReflectImage(Sprite _sprite, Color32 _color)
    {
        ReflectImage(_sprite);
        m_image.color = _color;
    }

    //Sprite + Size + Position
    public void ReflectImage(Sprite _sprite, Vector2 _bounds, int _posX, int _posY)
    {
        ReflectImage(_sprite, _bounds);
        m_image.gameObject.gameObject.GetComponent<RectTransform>().position = new Vector3(_posX, _posY);
    }

    //Sprite + Size + Color
    public void ReflectImage(Sprite _sprite, Vector2 _bounds, Color32 _color)
    {
        ReflectImage(_sprite, _bounds);
        m_image.color = _color;
    }

    //Sprite + Size + Position + Color
    public void ReflectImage(Sprite _sprite, Vector2 _bounds, int _posX, int _posY, Color32 _color)
    {
        ReflectImage(_sprite, _bounds, _posX, _posY);
        m_image.color = _color;
    }

    public void ResetImage()
    {
        m_image.sprite = null;
        m_image.color = new Color32(0, 0, 0, 0);
    }
}
