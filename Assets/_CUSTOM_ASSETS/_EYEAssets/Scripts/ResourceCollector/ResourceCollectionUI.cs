using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceCollectionUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _gasText;
    [SerializeField] private TMP_Text _crystalText;
    [SerializeField] private TMP_Text _oreText;
    [SerializeField] private TMP_Text _cargoText;

    [SerializeField] private TMP_Text _cameraText;


    void Start()
    {

    }

    void Update()
    {

    }

    public void UpdateGasQuantity(int count)
    {
        _gasText.text = count.ToString();
    }

    public void UpdateCrystalQuantity(int count)
    {
        _crystalText.text = count.ToString();
    }

    public void UpdateOreQuantity(int count)
    {
        _oreText.text = count.ToString();
    }

    public void UpdateCargoCount(int amount)
    {
        _cargoText.text = amount.ToString();
    }

    public void UpdateCameraText(string cameraName)
    {
        _cameraText.text = cameraName;
    }
}
