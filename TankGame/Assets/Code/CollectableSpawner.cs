using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TankGame
{

    public class CollectableSpawner : MonoBehaviour
    {


        public GameObject CollectablePrefab;

        public Vector3 center;
        public Vector3 size;
        public int posY = 1;
        public int points;

        // Use this for initialization
        void Start()
        {
            SpawnCollectibles();
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.frameCount % 300 == 0)
            {
                SpawnCollectibles();
            }
        }


        public void SpawnCollectibles()
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), posY, Random.Range(-size.z / 2, size.z / 2));

            points = Random.Range(0, 100);

            Instantiate(CollectablePrefab, pos, Quaternion.identity);
        }

        /*
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawCube(center, size);
        }
        */
    }
}