using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CharacterEditor
{
    public class CharacterEditor : MonoBehaviour
    {
        [SerializeField] Button nextMaterial;
        [SerializeField] Button nextBodyPart;
        [SerializeField] Button loadGame;

        [SerializeField] Character character;

        int id;
        BodyTypes bodyType = BodyTypes.Head;

        private void Awake()
        {
            nextMaterial.onClick.AddListener(NextMaterial);
            nextBodyPart.onClick.AddListener(NextBodyPart);
            loadGame.onClick.AddListener(LoadGame);
        }

        void NextMaterial()
        {
            id = (id + 1) % 3;

            switch (bodyType)
            {
                case BodyTypes.Head:
                    PlayerPrefs.SetInt("HeadMaterial", id);
                    break;
                case BodyTypes.Body:
                    PlayerPrefs.SetInt("BodyMaterial", id);
                    break;
                case BodyTypes.Leg:
                    PlayerPrefs.SetInt("LegsMaterial", id);
                    break;
            }

            character.Load();
        }

        void NextBodyPart()
        {
            switch (bodyType)
            {
                case BodyTypes.Head:
                    bodyType = BodyTypes.Body;
                    break;
                case BodyTypes.Body:
                    bodyType = BodyTypes.Leg;
                    break;
                case BodyTypes.Leg:
                    bodyType = BodyTypes.Head;
                    break;
            }

            id = PlayerPrefs.GetInt(bodyType.ToString() + "Material", 0); 
        }

        void LoadGame()
        {
            SceneManager.LoadScene("Game");
        }
    }
}