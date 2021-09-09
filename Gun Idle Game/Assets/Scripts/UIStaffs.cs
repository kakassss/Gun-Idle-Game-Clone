using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[Serializable]
public class UIStaffs : MonoBehaviour
{
    [SerializeField] public Image lockImage;
    [SerializeField] public TextMeshProUGUI lockText;
    [SerializeField] public GameObject unlockButton;

    public static UIStaffs instance;
}
