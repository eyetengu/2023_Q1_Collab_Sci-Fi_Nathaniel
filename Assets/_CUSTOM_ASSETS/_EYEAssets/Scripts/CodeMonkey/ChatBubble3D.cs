using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class ChatBubble3D : MonoBehaviour
{
    public static void Create(Transform parent, Vector3 localPosition, IconOverlayType iconType, string text)
    {
        //Transform chatBubbleTransform = Instantiate(GameAssets.i.pfChatBubble, parent);
        //chatBubbleTransform.localPosition = localPosition;

        //chatBubbleTransform.GetComponent<ChatBubble3D>().Setup(iconType, text);

        //Destroy(chatBubbleTransform.gameObject, 6f);
    }

    public enum IconType
    {
        Happy,
        Neutral,
        Angry
    }

    [SerializeField] private Sprite happyIconSprite = null;
}
