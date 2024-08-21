using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EYE_Assets;

namespace EYE_Assets 
{


    public class Character_Creator : MonoBehaviour
    {
        [SerializeField] Foosball_UI_Manager _uiManager;

        [SerializeField] GameObject _characterModel;

        [SerializeField] GameObject[] _characterTypes;
        [SerializeField] Material[] _clothingColor;
        [SerializeField] GameObject[] _hairItems;
        [SerializeField] GameObject[] _faceItems;

        SkinnedMeshRenderer _SkinnedRenderer;


        [SerializeField] Transform _hairGrip;
        [SerializeField] Transform _facialHairGrip;
        [SerializeField] Transform _eyesGrip;

        int _changeSomethingID;

        int _characterID;
        int _clothingID;
        int _wigID;
        int _facialHairID;
        int _eyewearID;
        string _message;


        void Start()
        {
            _SkinnedRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _changeSomethingID--;

                if (_changeSomethingID < 0)
                    _changeSomethingID = 4;

                switch (_changeSomethingID)
                {
                    case 0:
                        _message = "Character " + _characterTypes[_characterID];
                        break;
                    case 1:
                        _message = "Clothing Color " + _clothingColor[_clothingID]; 
                        break;
                    case 2:
                        _message = "Eyewear " + _faceItems[_facialHairID];
                        break;
                    case 3:
                        _message = "Facial Plume " + _faceItems[_facialHairID];
                        break;
                    case 4:
                        _message = "Wig " + _hairItems[_wigID];
                        break;

                    default:
                        break;
                }
                Debug.Log("Changing: " + _message);
                _uiManager.UpdatePlayerMessage($"Changing {_message}");
            }



            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (_changeSomethingID == 0)
                {
                    //Change Character
                    _characterID++;
                
                    if (_characterID > _characterTypes.Length - 1)
                        _characterID = 0;

                    DisplayCurrentCharacter();

                }
                else if (_changeSomethingID == 1)
                {
                    //Change Clothing Color
                    _clothingID++;

                    if (_clothingID > _clothingColor.Length - 1)
                        _clothingID = 0;

                    _SkinnedRenderer.material = _clothingColor[_clothingID];
                }

                else if (_changeSomethingID == 2)
                {
                    //Change Eyewear
                    _eyewearID++;

                    if (_eyewearID > _faceItems.Length - 1)
                        _eyewearID = 0;

                    foreach (var eyes in _faceItems)
                        eyes.SetActive(false);

                    _faceItems[_eyewearID].SetActive(true);
                }
                else if (_changeSomethingID == 3)
                {
                    //Change Facial Hair
                }
                else if (_changeSomethingID == 4)
                {
                    //Change Hair/Helmet
                    _wigID++;

                    if (_wigID > _hairItems.Length - 1)
                        _wigID = 0;

                    foreach (var hair in _hairItems)
                        hair.SetActive(false);

                    _hairItems[_wigID].SetActive(true);
                }

            }
        }

        void DisplayCurrentCharacter()
        {
            _characterModel = _characterTypes[_characterID];

            foreach (var model in _characterTypes)
                model.SetActive(false);
            _characterModel.SetActive(true);


        }

    }
}