using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Appearance : MonoBehaviour
{
    [Header("Character Selection")]
    [SerializeField] private bool _isMale;
    [SerializeField] private GameObject[] _maleCharacterSelection;
    [SerializeField] private GameObject[] _femaleCharacterSelection;

    [Header("Outfits")]
    [SerializeField] private Material[] _outfits;
    private SkinnedMeshRenderer _renderer;
    private int _materialID;

    [Header("Gender Specific")]
    [SerializeField] private GameObject[] _beards;
    [SerializeField] private GameObject _beardTransform;

    [Header("Hair Attributes")]
    [SerializeField] private bool _showHair;
    [SerializeField] private Transform _hairline;
    [SerializeField] private GameObject[] _hairstyles;
    [SerializeField] private GameObject[] _hats;
    [SerializeField] private GameObject[] _glasses;

    [Header("Choose Random Attributes")]
    [SerializeField] private bool _character;
    [SerializeField] private bool _outfitChoice;
    [SerializeField] private bool _toupee;
    [SerializeField] private bool _hat;
    [SerializeField] private bool _glassesChoice;
    [SerializeField] private bool _beard;


    void Start()
    {
        _renderer = GetComponentInChildren<SkinnedMeshRenderer>();

        TruthChecks();
        RandomizeEverything();
    }

    private void Update()
    {
        TruthChecks();
        CheckUserInput();
    }

    void TruthChecks()
    {
        //Hair
        if(_hairline!= null)
        {
            if (_showHair)
                _hairline.gameObject.SetActive(true);
            else
                _hairline.gameObject.SetActive(false);
        } 
        if(_beardTransform!= null)
        {
            //Beards
            if (_isMale)
                _beardTransform.SetActive(true);
            else
                _beardTransform.SetActive(false);
        }
    }

    void CheckUserInput()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            RandomizeEverything();
        }
    }

    void RandomizeEverything()
    {
        Debug.Log("Randomizing Everything");
        if(_character)
            ChooseRandomCharacter();
        if(_outfitChoice)
            ChooseRandomOutfit();
        if(_toupee)
            ChooseRandomToupee();
        if(_hat)
            ChooseRandomHat();
        if(_glassesChoice)
            ChooseRandomGlasses();
        if(_beard)
            ChooseRandomBeard();
    }

    void ChooseRandomCharacter()
    {
        var randomMaleCharacter = Random.Range(0, _maleCharacterSelection.Length-1);
        var randomFemaleCharacter = Random.Range(0, _femaleCharacterSelection.Length-1);

        if (_isMale)
        {
            ClearOutAllCharacters();

            //make the currently selected female character active
            _maleCharacterSelection[randomMaleCharacter].SetActive(true);

        }
        else
        {
            ClearOutAllCharacters();

            //make the currently selected female character active
            _femaleCharacterSelection[randomFemaleCharacter].SetActive(true);
        }
    }

    void ClearOutAllCharacters()
    {
        //set all male and female characters inactive
        foreach (var character in _maleCharacterSelection)
            character.SetActive(false);
        foreach (var character in _femaleCharacterSelection)
            character.SetActive(false);
    }

    void ChooseRandomOutfit()
    {
        if (_outfits != null)
        {
            var randomFinish = Random.Range(0, _outfits.Length - 1);
            _materialID = randomFinish;

            _renderer.material = _outfits[_materialID];
        }
    }

    void ChooseRandomToupee()
    {
        if (_hairstyles != null)
        {
            foreach (var style in _hairstyles)
            {
                style.gameObject.SetActive(false);
            }

            //_hairstyles[Random.Range(0, _hairstyles.Length)].SetActive(true);
        }
    }

    void ChooseRandomHat()
    {
        if (_hats != null)
        {
            foreach (var style in _hats)
            {
                style.gameObject.SetActive(false);
            }

            _hats[Random.Range(0, _hats.Length - 1)].SetActive(true);
        }
    }

    void ChooseRandomGlasses()
    {
        if(_glasses != null)
        {
            foreach (var style in _glasses)
            {
                style.gameObject.SetActive(false);
            }

            _glasses[Random.Range(0, _glasses.Length)].SetActive(true);
        }
    }

    void ChooseRandomBeard()
    {
        if (_beards != null)
        {
            foreach (var style in _beards)
            {
                style.gameObject.SetActive(false);
            }

            _beards[Random.Range(0, _beards.Length)].SetActive(true);
        }
    }
}

