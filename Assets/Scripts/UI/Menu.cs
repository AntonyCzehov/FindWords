using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    [SerializeField] SaveData saveData;

    [SerializeField] private Text litterCounter;
    [SerializeField] private Text wordCounter;

    [SerializeField] private GameObject levelContainer;
    [SerializeField] private Sprite[] levelPlayer;
    [SerializeField] private Sprite[] levelPlayerBackground;
    [SerializeField] private float[] levelPoint;

    [SerializeField] private GameObject[] levelEndObj;
    [SerializeField] private GameObject continueButton;

    private void Update()
    {

        litterCounter.text = "" + saveData.litterCounter;
        wordCounter.text = "" + saveData.wordCounter;
        MoveLevel();
    }

    private void MoveLevel()
    {
        float movePoint = (saveData.point) / levelPoint[saveData.level];

        

        levelContainer.transform.GetChild(0).GetComponent<Image>().sprite = levelPlayerBackground[saveData.level];
        levelContainer.transform.GetChild(1).GetComponent<Image>().sprite = levelPlayer[saveData.level];


        levelContainer.transform.GetChild(1).GetComponent<Image>().fillAmount = movePoint;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(saveData.scene);
    }

    public void MoveLevelEnd()
    {
        for(int i = 0; i < levelEndObj.Length; i++)
        {
            levelEndObj[i].SetActive(true);
        }

        continueButton.SetActive(false);
    }
}
