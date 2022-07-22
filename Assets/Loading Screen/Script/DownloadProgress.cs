using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baccarat
{
    /// <summary>  
    /// This function is used to counting progress of addressables.
    /// </summary>
    public class DownloadProgress : MonoBehaviour
    {

        #region Variables

        public int downloadProgressInput;
        public int downloadProgressOutput;
        private int cachedDownloadProgressInput;


        #endregion

        #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            downloadProgressOutput = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (cachedDownloadProgressInput != downloadProgressInput)
            {
                downloadProgressOutput = downloadProgressInput;
                cachedDownloadProgressInput = downloadProgressInput;
            }
        }


        #endregion
    }
}