using UnityEngine;
using System.Collections;
namespace MainGameplay
{

    public class LoaderBehavior : MonoBehaviour
    {
        public string targetScene;
        public SpriteRenderer loadObject;
        public Vector2 speed;
        private float counter = 0;

        // Use this for initialization
        void Start()
        {
            //variabel global yang menyatakan scene tujuan
            //this.targetScene = globalTargetScene;
            this.targetScene = ScreenTransitionManager.targetName;
            speed = new Vector2(10f, 0f);
            loadObject.rigidbody2D.velocity = speed;
        }

        // Update is called once per frame
        void Update()
        {
            counter += Time.deltaTime;
            if (loadObject.transform.position.x < -8f)
            {
                loadObject.transform.localScale = new Vector3(10f, 10f, 1f);
                loadObject.rigidbody2D.velocity = speed;
            }
            if (loadObject.transform.position.x > 8f)
            {
                loadObject.transform.localScale = new Vector3(-10f, 10f, 1f);
                loadObject.rigidbody2D.velocity = speed * -1;
            }
            if (counter >= 2)
            {
                Application.LoadLevel(targetScene);
            }
            //Debug.Log(loadObject.transform.position.x);
            //if (Application.GetStreamProgressForLevel(targetScene) == 1)
            //{
            //    Application.LoadLevel(targetScene);
            //}
        }
    }
}