using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Baccarat
{
    /// <summary>  
    /// This function is used to counting progress of addressables.
    /// </summary>
    public class UILoadingSpinner : MonoBehaviour
    {

        #region Variables

        public RectTransform loadingBar;
        public float speed;
        public TextMeshProUGUI loadingPercent;
        public DownloadProgress downloadProgress;

        private int percentComplete;
        private int cachedPercentComplete;

        #endregion

        #region Life Cycle

        void OnEnable()
        {
            percentComplete = 0;
        }

        #endregion

        #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            percentComplete = 0;
        }

        // Update is called once per frame
        void Update()
        {
            loadingBar.Rotate(new Vector3(0, 0, -speed * Time.deltaTime));
        }

        #endregion
    }
}