using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemy
{
    public class InstantiateEnemy : Observer
    {
        private static int m_enemyCount = 5;
        
        [Tooltip("Check if the counting enemy works or not")]
        public int EnemyCount;

        #region Spawning Enemy variables
        [Header("Spawing Enemy")]
        public GameObject EnemyPrefab;
        private List<float> xPos01List = new List<float> {-11, -7, -3, 0, 4, 6, 9, 13};
        private List<float> zPos01List = new List<float> {-2, -1, 0, 1, 3, -14, -17, -20};
        private List<float> xPos02List = new List<float> {-22, -25, 22, 25, 28};
        private List<float> zPos02List = new List<float> {-5, -9, -12, -15, -20, -23, -25};
        private List<float> xPos03List = new List<float> {-12, -5, 0, 5, 12};
        private List<float> zPos03List = new List<float> {-33, -36};

        //Array contains xPos01List, xPos02List values which will be used to AddRange() to List
        float[] xPos01Value = new float[] { -11, -7, -3, 0, 4, 6, 9, 13 };
        float[] xPos02Value = new float[] { -22, -25, 22, 25, 28 };
        float[] xPos03Value = new float[] { -12, -5, 0, 5, 12 };
        #endregion

        public override void ReceiveSignal(SubjectOfObserver subject)
        {
            EnemyHealth countEnemy = subject.GetComponent<EnemyHealth>();
            if(countEnemy != null)
            {
                m_enemyCount = EnemyHealth.EnemyCount;
                if(m_enemyCount <= 0)
                {
                    StartCoroutine(SpawnEnemy());
                    
                }
            }
        }

        private void Update()
        {
            //Show static var in Inspector
            EnemyCount = m_enemyCount;
        }

        IEnumerator SpawnEnemy()
        {
            yield return new WaitForSeconds(3f);

            int indexOfX = Random.Range(0, xPos01List.Count);
            int indexOfZ = Random.Range(0, zPos01List.Count);
            Vector3 pos = new Vector3();

            //Spawn on 1st floor
            for (int i = 0; i < 6; i++)
            {
                indexOfX = Random.Range(0, xPos01List.Count);
                indexOfZ = Random.Range(0, zPos01List.Count);
                pos = new Vector3(xPos01List[indexOfX], 0, zPos01List[indexOfZ]);
                Instantiate(EnemyPrefab, pos, Quaternion.identity);
                EnemyHealth.EnemyCount++;
                m_enemyCount++;
                xPos01List.RemoveAt(indexOfX);
            }
            
            //Spawn on 2nd floor, left and right
            for (int i = 0; i < 5; i++)
            {
                indexOfX = Random.Range(0, xPos02List.Count);
                indexOfZ = Random.Range(0, zPos02List.Count);
                pos = new Vector3(xPos02List[indexOfX], 2.38f, zPos02List[indexOfZ]);
                Instantiate(EnemyPrefab, pos, Quaternion.identity);
                EnemyHealth.EnemyCount++;
                m_enemyCount++;
                xPos02List.RemoveAt(indexOfX);
            }
            
            //Spawn on 2nd floor, back
            for (int i = 0; i < 2; i++)
            {
                indexOfX = Random.Range(0, xPos03List.Count);
                indexOfZ = Random.Range(0, zPos03List.Count);
                pos = new Vector3(xPos03List[indexOfX], 2.38f, zPos03List[indexOfZ]);
                Instantiate(EnemyPrefab, pos, Quaternion.identity);
                EnemyHealth.EnemyCount++;
                m_enemyCount++;
                xPos03List.RemoveAt(indexOfX);
            }

            xPos01List.Clear();
            xPos02List.Clear();
            xPos03List.Clear();

            xPos01List.AddRange(xPos01Value);
            xPos02List.AddRange(xPos02Value);
            xPos03List.AddRange(xPos03Value);
        }
    }
}

/*check if array value can be the same
                int[] arrayInt = new int[] {27,27,27};
                print(arrayInt[0] + " " + arrayInt[1] + " " + arrayInt[2]);
            */

/*random specific number
     System.Random r = new System.Random();
     int[] priceArray = new int[] { 5, 7, 10, 15, 20 };
     int randomIndex = r.Next(priceArray.Length);            //random index num
     int randomPrice = priceArray[randomIndex];              //get value from the index that is previously randomed
     print("random price "+randomPrice);
*/

/* Random no repeated number
 List<int> possible = Enumerable.Range(1, 48).ToList(); //can I specify the num as the array
 List<int> listNumbers = new List<int>();

 for (int i = 0; i < 6; i++)
 {
     //how to use .Count
     int index = r.Next(0, possible.Count);              //random index num 
     listNumbers.Add(possible[index]);                   //get value from the index that is previously randomed
     possible.RemoveAt(index);                           //remove num at the index

 }
 string result = string.Join(",", listNumbers);
 string resultPossible = string.Join(",", possible);
 print($"RESULT: {result}");
 //print($"possible List: {resultPossible}");
*/

/*Test Random.Next
    //Random.Next --> maxValue will not be used in random. In this case is 2
    int myRand = r.Next(0,2);
    int myRand02 = r.Next(0,2);
    int myRand03 = r.Next(0,2);
    int myRand04 = r.Next(0,2);
    int myRand05 = r.Next(0,2);
    print($"myRand: {myRand}, {myRand02}, {myRand03}, {myRand04}, {myRand05}"); //There's no result of 2
*/

/*After spawning 5 enemies, set enemy amount to default value
//There should be a better way to count enemy that is spawned because if it's set
//like this, it's the fixed number, what if spawn more than this small amount.
//Result 1: put in the loop as Spawn on 1st and 2nd floor
EnemyHealth.EnemyCount = 5;
m_enemyCount = 5;
*/