using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteMaker : MonoBehaviour {
    [SerializeField] private Transform imageParentTransform;
    public List<string> choices;
    [SerializeField] private List<Color> rouletteColors;
    [SerializeField] private Image rouletteImage;
    [SerializeField] private RouletteController rController;
    private void Start () {
        float ratePerRoulette = 1 / (float) choices.Count;
        float rotatePerRoulette = 360 / (float) (choices.Count);
        for (int i = 0; i < choices.Count; i++)
        {
            var obj = Instantiate(rouletteImage, imageParentTransform);
            obj.color = rouletteColors[(choices.Count - 1 - i)];
            switch (i)
            {
                case 1:
                    obj.fillAmount = 0.97f;
                    break;
                case 2:
                    obj.fillAmount = 0.8f;
                    break;
                case 3:
                    obj.fillAmount = 0.5f;
                    break;
                case 4:
                    obj.fillAmount = 0.2f;
                    break;
                default:
                    obj.fillAmount = ratePerRoulette * (choices.Count - i);
                    break;
            }
            obj.GetComponentInChildren<Text>().text = choices[(choices.Count - 1 - i)];
            if (i == 0)
            {
                obj.transform.GetChild(0).transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(74.95f, 29.17f);
                obj.transform.GetChild(0).transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(-0.5f, 33f);
            }

            switch (i)
            {
                case 0:
                    obj.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 5.26f);
                    break;
                case 1:
                    obj.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 47.31f);
                    break;
                case 2:
                    obj.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 127.106f);
                    break;
                case 3:
                    obj.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, -122.989f);
                    break;
                case 4:
                    obj.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, -36f);
                    break;
                default:
                    obj.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, ((rotatePerRoulette / 2) + rotatePerRoulette * i));
                    break;
            }
        }
        rController.SetRoulette();
        rController.rMaker = this;
        rController.rotatePerRoulette = rotatePerRoulette;
        rController.roulette = imageParentTransform.gameObject;
    }
}