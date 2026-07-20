using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    public Button quitButton, restartButton;
    public Canvas endingOverlay;
    public const int ending_church = 0, ending_warrior = 1, ending_pay = 2, ending_pass = 3;

    public TextMeshProUGUI endingDesc;
    public GameObject rogueText;
    void Start()
    {
        quitButton.onClick.AddListener(exitFunc);
        restartButton.onClick.AddListener(restartScene);
    }


    public void showEnding(int endingID, bool rogue) {
        endingOverlay.gameObject.SetActive(true);

        switch (endingID)
        {
            case ending_church: {endingDesc.text = "Концовка церкви\nВы спокойно прошли в город при помощи церкви. Вы уже и сами начинаете надумывать стать церковником..."; break;}
            case ending_warrior: {endingDesc.text = "Концовка воина\nДаже рота стражей не смогла оказать вам сопротивления. Больше никто не посмеет встать у вас на пути."; break;}
            case ending_pay: {endingDesc.text = "Концовка собирателя\nКаким-то образом вы смогли собрать необходимую сумму. Стражи удивлены, но всё же пропустили вас в город."; break;}
            case ending_pass: {endingDesc.text = "Концовка 'торговца'\nСтражи поверили вашему украденному пропуску и пропустили вас в город."; break;}
            default: {endingDesc.text="Вы прошли в город."; break;}
        }

        if (rogue) {
            rogueText.SetActive(true);
        }
    }

    void exitFunc() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    void restartScene() {
        SceneManager.LoadScene("SampleScene");
    }

}