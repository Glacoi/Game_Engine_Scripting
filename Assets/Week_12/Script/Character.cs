using UnityEngine;

namespace CharacterEditor
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private MeshRenderer m_Head;
        [SerializeField] private MeshRenderer m_Body;
        [SerializeField] private MeshRenderer m_ArmR;
        [SerializeField] private MeshRenderer m_ArmL;
        [SerializeField] private MeshRenderer m_LegR;
        [SerializeField] private MeshRenderer m_LegL;

        private void Start()
        {
            Load();
        }

        public void Load()
        {
            
            int headId = PlayerPrefs.GetInt("HeadID", 2); 
            int bodyId = PlayerPrefs.GetInt("BodyID", 3);
            int armId = PlayerPrefs.GetInt("ArmID", 0); 
            int legId = PlayerPrefs.GetInt("LegID", 1); 

           
            m_Head.material = MaterialManager.Get(BodyTypes.Head, headId);
            m_Body.material = MaterialManager.Get(BodyTypes.Body, bodyId);
            m_ArmR.material = MaterialManager.Get(BodyTypes.Arm, armId);
            m_ArmL.material = MaterialManager.Get(BodyTypes.Arm, armId); 
            m_LegR.material = MaterialManager.Get(BodyTypes.Leg, legId);
            m_LegL.material = MaterialManager.Get(BodyTypes.Leg, legId); 
        }
    }
}