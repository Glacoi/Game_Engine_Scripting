using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

namespace Battleship
{

    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private int[,] grid = new int[,]
            {
            {1,1,0,0,1},
            {0,0,0,0,0},
            {0,0,1,0,1},
            {1,0,1,0,0},
            {1,0,1,0,1},
            };
        private bool[,] hits;
        private int nRows;
        private int nCols;
        private int row;
        private int col;
        private int score;
        private int time;

        [SerializeField] Transform gridRoot;
        [SerializeField] GameObject cellprefab;
        [SerializeField] GameObject winLabel;
        [SerializeField] TextMeshProUGUI timeLabel;
        [SerializeField] TextMeshProUGUI scoreLabel;

        private void Awake()
        {
            nRows= grid.GetLength(0);
            nCols= grid.GetLength(1);

            hits= new bool[nRows,nCols];

            for(int i = 0; i < nRows * nCols; i++) 
            { 
            
            Instantiate(cellprefab, gridRoot);
            
            
            
            }
            SelectCurrentCell();

            nRows = grid.GetLength(0);
            nCols = grid.GetLength(1);

            hits = new bool[nRows, nCols];

            for (int i = 0; i < nRows * nCols; i++)
            {

                Instantiate(cellprefab, gridRoot);

            }
            SelectCurrentCell();
            InvokeRepeating("IncreamentTime", 1f, 1f);
        }

        Transform GetCurrentCell()
        {


            int index = (row * nCols) + col;

            return gridRoot.GetChild(index);
        }

        void SelectCurrentCell()
        {

            Transform cell = GetCurrentCell();


            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(true);

        }

        void UnselectCurrentCell()
        {

            Transform cell = GetCurrentCell();
            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(false);

        }

        public void MoveHorizontal(int amt)
        {

            UnselectCurrentCell();

            col += amt;

            col = Mathf.Clamp(col, 0, nCols - 1);

            SelectCurrentCell();

        }

        public void MoveVertical(int amt)
        {

            UnselectCurrentCell();

            row += amt;

            row = Mathf.Clamp(row, 0, nRows - 1);

            SelectCurrentCell();

        }

        void ShowHit()
        {
            Transform cell = GetCurrentCell();
            Transform hit = cell.Find("Hit");
            hit.gameObject.SetActive(true);




        }

        void ShowMiss()
        {

            Transform cell = GetCurrentCell();
            Transform miss = cell.Find("Miss");
            miss.gameObject.SetActive(true);

        }

        void IncreamentScore()

        {

            score++;

            scoreLabel.text = string.Format("Score: {0}", score);

        }

        void IncreamentTime()

        {

            time++;

            timeLabel.text = string.Format("{0}:{1}", time / 60, (time % 60).ToString("00"));

        }

        public void Fire()
        {

            if (hits[row, col]) return;
            hits[row, col] = true;


            if (grid[row, col] == 1)
            {


                ShowHit();
                
                

            }
            else
            {

                ShowMiss();

            }
        

        }
         
        void TryEndGame()
        {

            for(int row = 0; row < nRows; row++)
            {

                for (int col = 0; col < nCols; col++)
                {

                    if (grid[row, col] == 0) continue;


                    if (hits[row, col]) continue;

                }


            }

        winLabel.SetActive(true);
        
            CancelInvoke("IncreamtTiome");
        
        
        
        
        
        
        
        
        
        
        }
        public class script : MonoBehaviour
        {
            public void Restart()
            {

                SceneManager.LoadScene("Battleship");

            }




        }


        public class RestartButton : MonoBehaviour
        {
            void Start()
            {
                
                Button restartButton = GameObject.Find("RestartButton").GetComponent<Button>();

                
                restartButton.onClick.AddListener(RestartGame);
            }

            void RestartGame()
            {
                
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }






        // Update is called once per frame
       
        
            void Update()
            {
                
            }


        
    }
}